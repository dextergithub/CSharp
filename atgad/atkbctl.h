/*-------------------------------------------------------------------------*/
/*                                                                         */
/* Keyboard control                                                        */
/*                                                                         */
/* ATKBCTL.H															   */
/*                                                                         */
/* Copyright (C) ActiveTouch Inc.                                          */
/* All rights reserved                                                     */
/*																		   */
/* Author                                                                  */
/*      Guanghong Yang (kelveny@activetouch.com)                           */
/*                                                                         */
/* History                                                                 */
/*      08/27/98                Create                                     */
/*      10/29/98                Seperate Keyboard control into a DLL       */
/*                                                                         */
/*-------------------------------------------------------------------------*/

#ifndef __ATKBCTL_H__
#define __ATKBCTL_H__

#include <windows.h>

#ifdef __cplusplus
extern "C" {
#endif

/////////////////////////////////////////////////////////////////////////////
// Keyboard control running environment
//
typedef enum 
{
    KBENV_MSIE      = 0,
    KBENV_NETSCAPE  = 1,
    KBENV_UNKNOWN   = 2
} KBENVIRONMENT;

/////////////////////////////////////////////////////////////////////////////
// Keyboard API functions
//
BOOL WINAPI KbInstallFocusControl();
void WINAPI KbUninstallFocusControl();
void WINAPI KbSetFocus(HWND hWnd);
void WINAPI KbSetDialogFocus(HWND hWnd);
HWND WINAPI KbGetFocus();
void WINAPI KbSetEnvironment(KBENVIRONMENT env);

#ifdef __cplusplus
};
#endif

#endif

