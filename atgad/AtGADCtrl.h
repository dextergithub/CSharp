// AtGADCtrl.h : Declaration of the CAtGADCtrl

#ifndef __ATGADCTRL_H_
#define __ATGADCTRL_H_

#include "resource.h"   // main symbols

/////////////////////////////////////////////////////////////////////////////
// CCtrlContainerWnd
//
class CCtrlContainerWnd : public CWindowImpl<CCtrlContainerWnd>
{
public :
	CCtrlContainerWnd();
    virtual ~CCtrlContainerWnd();

    BOOL NewInstance(HWND hWndParent);

	BEGIN_MSG_MAP(CCtrlContainerWnd)
        MESSAGE_HANDLER(WM_CREATE, OnCreate)
		MESSAGE_HANDLER(WM_SIZE, OnSize)
		MESSAGE_HANDLER(WM_PAINT, OnPaint)
		MESSAGE_HANDLER(WM_KEYDOWN, OnKeyDown)
		MESSAGE_HANDLER(WM_ACTIVATE, OnActivate)
		MESSAGE_HANDLER(WM_LBUTTONDOWN, OnLButtonDown)
        MESSAGE_HANDLER(WM_TIMER, OnTimer)
        MESSAGE_HANDLER(WM_DESTROY, OnDestroy)
	END_MSG_MAP()

	LRESULT OnSize(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
	LRESULT OnPaint(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
	LRESULT OnKeyDown(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
	LRESULT OnLButtonDown(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
    LRESULT OnCreate(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
    LRESULT OnDestroy(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
    LRESULT OnTimer(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);
    LRESULT OnActivate(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled);

protected :
    HWND m_hWndParent;
    UINT m_idTimer;
    RECT m_rcLast;

	HBITMAP	m_bmpGAD;
};

#endif //__ATgadCTRL_H_
