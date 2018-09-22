#include "stdafx.h"
#include "MouseLogger.h"

static MouseLogger* selfRef = nullptr;
MouseLogger::MouseLogger()
{
	head = new Logger::LogNode("", 0);
	curr = new Logger::LogNode("", 0);
	mousePos = new Coord();
	escapeSequence = false;
	selfRef = this;
}

MouseLogger::MouseLogger(HANDLE h) {
	logHandle = h;
	MouseLogger();
}

MouseLogger::~MouseLogger()
{
}

LRESULT CALLBACK MouseLogger::hookProcess(int code, WPARAM wParam, LPARAM lParam) {
	MOUSEHOOKSTRUCT* pMouseStruct = (MOUSEHOOKSTRUCT *)lParam;
	selfRef->strStream.str("");
	if (pMouseStruct != NULL) {
		if (wParam == WM_LBUTTONDBLCLK) {
			selfRef->strStream << "MCLX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else if (wParam == WM_RBUTTONDBLCLK) {
			selfRef->strStream << "MCRX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else if (wParam == WM_LBUTTONDOWN) {
			selfRef->strStream << "MCLDX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else if (wParam == WM_LBUTTONUP) {
			selfRef->strStream << "MCLUX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else if (wParam == WM_RBUTTONDOWN) {
			selfRef->strStream << "MCRDX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else if (wParam == WM_RBUTTONUP) {
			selfRef->strStream << "MCRUX";
			selfRef->strStream << pMouseStruct->pt.x;
			selfRef->strStream << "Y";
			selfRef->strStream << pMouseStruct->pt.y;
		}
		else {
			if (selfRef->mousePos->x != pMouseStruct->pt.x || selfRef->mousePos->y != pMouseStruct->pt.y) {
				selfRef->strStream << "MMX";
				selfRef->strStream << pMouseStruct->pt.x;
				selfRef->strStream << "Y";
				selfRef->strStream << pMouseStruct->pt.y;
				selfRef->mousePos->x = pMouseStruct->pt.x;
				selfRef->mousePos->y = pMouseStruct->pt.y;
			}
		}
		if (selfRef->strStream.str() != "") {
			double time = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
			selfRef->strStream << "T" << std::fixed << time;
			LogNode* newNode = new LogNode(selfRef->strStream.str(), time);
			if (selfRef->head->next == NULL) {
				selfRef->head->next = newNode;
			}
			else {
				selfRef->curr->next = newNode;
			}
			selfRef->curr = newNode;
		}
	}
	return CallNextHookEx((selfRef->logHook), code, wParam, lParam);
}

DWORD WINAPI MouseLogger::log(LPVOID param) {
	HINSTANCE hInstance = GetModuleHandle(NULL);
	logHook = SetWindowsHookEx(WH_MOUSE_LL, hookProcess, hInstance, NULL);
	MSG message;
	while (GetMessage(&message, NULL, 0, 0)&&!escapeSequence) {
		TranslateMessage(&message);
		DispatchMessage(&message);
	}
	UnhookWindowsHookEx(logHook);
	return 0;
}
