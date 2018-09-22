#include "stdafx.h"
#include "KeyboardController.h"

#pragma region Constructors
KeyboardController::KeyboardController()
{
}

KeyboardController::KeyboardController(int delay) {
	keyDelay = delay;
}

KeyboardController::~KeyboardController()
{
}
#pragma endregion

#pragma region Lower Level Keyboard Input Functions
int KeyboardController::sendKeyEvent(WORD key, bool isUp) {
	INPUT keyEvent;
	keyEvent.type = 1;
	keyEvent.ki.time = 0;
	keyEvent.ki.wVk = key;
	keyEvent.ki.dwFlags = KEYEVENTF_UNICODE;
	if (isUp) {
		keyEvent.ki.dwFlags = keyEvent.ki.dwFlags | KEYEVENTF_KEYUP;
	}
	UINT result = SendInput(1, &keyEvent, sizeof INPUT);
	return result;
}
int KeyboardController::keyPress(WORD VK) {
	sendKeyEvent(VK, false);
	return 0;
}
int KeyboardController::keyRelease(WORD VK) {
	sendKeyEvent(VK, true);
	return 0;
}
#pragma endregion