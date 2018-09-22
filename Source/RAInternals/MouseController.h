#pragma once
#include <Windows.h>
#include <string>
#include <time.h>
#include <chrono>
#include <thread>
//Change movement from Coord based to percent based to fix resolution differences?
class MouseController
{
public:
	MouseController();
	MouseController(int delay);
	~MouseController();
	int clickDelay;//time between consecutive clicks in millis
	/*moves the mouse to the x y coordinate params at the speed specified.*/
	int moveMouse(int x, int y);
	/*Returns the current mouse X position*/
	int getMouseX();
	/*Returns the current mouse Y position*/
	int getMouseY();
	/*Sends a down event for the specified button (primary,secondary,tertiary) to Windows*/
	int pressMouse(char button);
	/*Sends an up event for the specified button (primary,secondary,tertiary) to Windows*/
	int releaseMouse(char button);
	/*Low level mouse input function that creates a INPUT struct and uses the SendInput function to synthesize input for Windows*/
	int sendMouseEvent(DWORD flags);
};
