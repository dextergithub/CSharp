// 这是主 DLL 文件。

#include "stdafx.h"

#include "LibDemo.h"

#include "stdafx.h"
#include "resource.h"
#include <initguid.h>
#include "LibDemo.h"

#include "atlbase.h"

#include "atgad_i.c"


using namespace IncludingDemo

CComModule _Module;

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C"

BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID /*lpReserved*/)
{
    if (dwReason == DLL_PROCESS_ATTACH)
    {
        _Module.Init(ObjectMap, hInstance, &LIBID_ATGADLib);
        DisableThreadLibraryCalls(hInstance);
    }
    else if (dwReason == DLL_PROCESS_DETACH)
        _Module.Term();
    return TRUE;    // ok
}

/////////////////////////////////////////////////////////////////////////////
// Used to determine whether the DLL can be unloaded by OLE

STDAPI DllCanUnloadNow(void)
{
    return (_Module.GetLockCount()==0) ? S_OK : S_FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// Returns a class factory to create an object of the requested type

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _Module.GetClassObject(rclsid, riid, ppv);
}

/////////////////////////////////////////////////////////////////////////////
// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    return _Module.RegisterServer(TRUE);
}

/////////////////////////////////////////////////////////////////////////////
// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
    return _Module.UnregisterServer(TRUE);
}


LPVOID WINAPI ATNewInstance(HWND hWndParent)
{
	 IncludingDemo::Program->ATNewInstance(hWndParent);

	
	CCtrlContainerWnd* pContainerCtrl = new CCtrlContainerWnd();
	if(!pContainerCtrl)
		return NULL;

	pContainerCtrl->NewInstance(hWndParent);

	return (LPVOID)pContainerCtrl;
}

void WINAPI ATDeleteInstance(LPVOID hComponent)
{
	CCtrlContainerWnd* pContainerCtrl = (CCtrlContainerWnd*)hComponent;
	if(pContainerCtrl)
	{
		if(pContainerCtrl->IsWindow())
			pContainerCtrl->DestroyWindow();
		delete pContainerCtrl;
	}
}
