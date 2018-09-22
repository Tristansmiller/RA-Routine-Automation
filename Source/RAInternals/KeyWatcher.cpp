#include "stdafx.h"
#include "KeyWatcher.h"

static KeyWatcher* selfRef = nullptr;
KeyWatcher::KeyWatcher()
{
	ctrlDown = false;
	escapeSequence = false;
	externalEscape = false;
	selfRef = this;
}
KeyWatcher::KeyWatcher(HANDLE h) {
	logHandle = h;
	KeyWatcher();
}


KeyWatcher::~KeyWatcher()
{
}

LRESULT CALLBACK KeyWatcher::hookProcess(int code, WPARAM wParam, LPARAM lParam) {
	KBDLLHOOKSTRUCT* pKeyboardStruct = (KBDLLHOOKSTRUCT *)lParam;
	if (pKeyboardStruct != NULL && pKeyboardStruct->flags != LLKHF_INJECTED) {
		UINT VK = MapVirtualKey(pKeyboardStruct->scanCode, MAPVK_VSC_TO_VK);
		char key = MapVirtualKey(MapVirtualKey(pKeyboardStruct->scanCode, MAPVK_VSC_TO_VK), MAPVK_VK_TO_CHAR);
		int keyNum = (int)key;
		if (wParam == WM_KEYDOWN) {
			for (int i = 0;i < 4;i++) {
				if (selfRef->macroKeys[i] == (int)VK) {
					selfRef->keysDown[i] = true;break;
				}
			}
			selfRef->escapeSequence = selfRef->keysDown[0] && selfRef->keysDown[1] && selfRef->keysDown[2] && selfRef->keysDown[3];
			if (selfRef->escapeSequence || selfRef->externalEscape) { UnhookWindowsHookEx(selfRef->logHook); ExitThread(selfRef->logThread); }
		}
		if (wParam == WM_KEYUP) {
			for (int i = 0;i < 4;i++) {
				if (selfRef->macroKeys[i] == (int)VK) {
					selfRef->keysDown[i] = false;break;
				}
			}
		}
	}
	return CallNextHookEx((selfRef->logHook), code, wParam, lParam);
}

DWORD WINAPI KeyWatcher::log(LPVOID param) {
	HINSTANCE hInstance = GetModuleHandle(NULL);
	logHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcess, hInstance, NULL);
	MSG message;

	while (GetMessage(&message, NULL, 0, 0)&&!escapeSequence) {
		TranslateMessage(&message);
		DispatchMessage(&message);
	}
	UnhookWindowsHookEx(logHook);
	return 0;
}



