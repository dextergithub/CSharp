// AtGADCtrl.cpp : Implementation of CAtGADCtrl

#include "StdAfx.h"
#include "AtGADCtrl.h"
#include "atkbctl.h"

//
////////////////////////////////////////////////////////////////////////////
// CCtrlContainerWnd
//
CCtrlContainerWnd::CCtrlContainerWnd()
{
    m_idTimer = 0;
	m_hWndParent = NULL;
	m_bmpGAD = NULL;

	m_rcLast.bottom	= 0;
	m_rcLast.left	= 0;
	m_rcLast.right	= 0;
	m_rcLast.top	= 0;
}

CCtrlContainerWnd::~CCtrlContainerWnd()
{
}

BOOL CCtrlContainerWnd::NewInstance(HWND hWndParent)
{
    m_hWndParent = hWndParent;
    ::GetClientRect(m_hWndParent, &m_rcLast);

    return Create(hWndParent, m_rcLast) != NULL;
}

LRESULT CCtrlContainerWnd::OnCreate(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
    DefWindowProc(nMsg, wParam, lParam);

	m_bmpGAD = ::LoadBitmap(_Module.GetModuleInstance(), MAKEINTRESOURCE(IDB_GAD));

    m_idTimer = ::SetTimer(m_hWnd, 100, 100, NULL);
    bHandled = TRUE;
    return 0;
}

LRESULT CCtrlContainerWnd::OnDestroy(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
    KillTimer(m_idTimer);

	if( m_bmpGAD )
	{
		DeleteObject( m_bmpGAD );
		m_bmpGAD = NULL;
	}

    DefWindowProc(nMsg, wParam, lParam);
    bHandled = TRUE;
    return 0;
}

LRESULT CCtrlContainerWnd::OnTimer(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
    if(m_hWndParent && ::IsWindow(m_hWndParent))
    {
        RECT rc;
        ::GetClientRect(m_hWndParent, &rc);
        if((rc.right - rc.left != m_rcLast.right - m_rcLast.left) ||
            (rc.bottom - rc.top != m_rcLast.bottom - m_rcLast.top))
        {
            ::MoveWindow(m_hWnd, rc.left, rc.top,
                rc.right - rc.left, rc.bottom - rc.top, TRUE);

            CopyRect(&m_rcLast, &rc);
        }
    }

    bHandled = TRUE;
    return 0;
}

LRESULT CCtrlContainerWnd::OnActivate(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	if(LOWORD(wParam) != WA_INACTIVE)
	{
		::SetFocus(m_hWnd);
		KbSetDialogFocus(m_hWnd);
	}
	else
	{
		KbSetDialogFocus(NULL);
	}

	return 0;
}

LRESULT CCtrlContainerWnd::OnSize(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	RECT rc;
	GetClientRect(&rc);
	
	bHandled = FALSE;
	return 0;
}

LRESULT CCtrlContainerWnd::OnLButtonDown(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	::MessageBox(NULL, _T("OnLButtonDown"), _T("Message Test"), MB_OK);

	::SetFocus(m_hWnd);
	KbSetDialogFocus(m_hWnd);

	bHandled = FALSE;
	return 0;
}

LRESULT CCtrlContainerWnd::OnKeyDown(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	::MessageBox(NULL, _T("OnKeyDown"), _T("Message Test"), MB_OK);

	bHandled = FALSE;
	return 0;
}

LRESULT CCtrlContainerWnd::OnPaint(UINT nMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
{
	PAINTSTRUCT ps;
	HDC hPainDC = BeginPaint(&ps);

	RECT rcClient;
	GetClientRect(&rcClient);

	FillRect(hPainDC, &rcClient, (HBRUSH)GetStockObject(WHITE_BRUSH));
	InflateRect(&rcClient, -8, -8);
	FillRect(hPainDC, &rcClient, (HBRUSH)GetStockObject(DKGRAY_BRUSH));

	int nWidth = 530;
	int hHeight = 343;
	int nLeft = (rcClient.right - rcClient.left - nWidth)/2;
	int nTop = (rcClient.bottom - rcClient.top - hHeight)/2;

	HDC memdc; 
	memdc = CreateCompatibleDC(hPainDC); 
	SelectObject(memdc, m_bmpGAD); 
	BitBlt(hPainDC, nLeft, nTop, nWidth, hHeight, memdc, 0, 0, SRCCOPY); 
	DeleteDC(memdc);

	EndPaint(&ps);

	bHandled = FALSE;
	return 0;
}