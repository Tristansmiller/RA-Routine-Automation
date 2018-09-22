#include "stdafx.h";
#include <Windows.h>;
#include <string>;
#pragma once
using namespace std;
class KeyboardController
{
public:
	KeyboardController();
	//delay param corresponds to the time (in millis) between keystrokes if a string is passed to KeyClick
	KeyboardController(int delay);
	~KeyboardController();
	int keyDelay;//time between keystrokes

	/*Lowest level key input function - this function takes a WORD representing the key and a boolean for whether it is a KeyUp or KeyDown event.
	  The function sets the proper flags and uses the SendInput function to send an INPUT struct to Windows. */
	int sendKeyEvent(WORD key, bool isUp);

	/*Sends a KeyDown event using the Virtual key param to Windows*/
	int keyPress(WORD VK);
	/*Sends a KeyUp event for the Virtual Key param to Windows*/
	int keyRelease(WORD VK);
};