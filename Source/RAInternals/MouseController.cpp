#include "stdafx.h"
#include "MouseController.h"
using namespace std;

#pragma region Constructors
MouseController::MouseController()
{
}

MouseController::MouseController(int delay) {
	clickDelay = delay;
}

MouseController::~MouseController()
{
}
#pragma endregion

#pragma region Lower Level Mouse Input Functions
int MouseController::sendMouseEvent(DWORD flags) {
	INPUT inputEvent;
	inputEvent.type = INPUT_MOUSE;
	inputEvent.mi.dx = getMouseX();
	inputEvent.mi.dy = getMouseY();
	inputEvent.mi.mouseData = 0;
	inputEvent.mi.dwFlags = flags;
	inputEvent.mi.time = 0;
	SendInput(1, &inputEvent, sizeof(INPUT));
	return 0;
}
int MouseController::pressMouse(char button) {
	//Sleep(clickDelay);
	if (button == 'p') {
		sendMouseEvent(MOUSEEVENTF_LEFTDOWN);
	}
	else if (button =='s') {
		sendMouseEvent(MOUSEEVENTF_RIGHTDOWN);
	}
	else if (button == 't') {
		sendMouseEvent(MOUSEEVENTF_MIDDLEDOWN);
	}
	return 0;
}
int MouseController::releaseMouse(char button) {
	//Sleep(clickDelay);
	if (button == 'p') {
		sendMouseEvent(MOUSEEVENTF_LEFTUP);
	}
	else if (button =='s') {
		sendMouseEvent(MOUSEEVENTF_RIGHTUP);
	}
	else if (button =='t') {
		sendMouseEvent(MOUSEEVENTF_MIDDLEUP);
	}
	return 0;
}
#pragma endregion

#pragma region Mouse Movement
int MouseController::moveMouse(int x, int y) {
	POINT currPos;
	if (GetCursorPos(&currPos)) {
		int currX = currPos.x;
		int currY = currPos.y;
		while (currX != x || currY != y) {
			if (currX < x) {
				currX++;
			}
			else if (currX>x) {
				currX--;
			}
			if (currY < y) {
				currY++;
			}
			else if (currY > y) {
				currY--;
			}
			if (!SetCursorPos(currX, currY)) {
				return 1; //Error setting Mouse Position
			}

		}
		return 0;
	}
	else {
		return -1;//Error retrieving mouse position.
	}

}

int MouseController::getMouseX() {
	POINT currPos;
	GetCursorPos(&currPos);
	return currPos.x;
}
int MouseController::getMouseY() {
	POINT currPos;
	GetCursorPos(&currPos);
	return currPos.y;
}
#pragma endregion


