#include "Logger.h"
#pragma once

class MouseLogger :
	public Logger
{
public:
	MouseLogger();
	MouseLogger(HANDLE h);
	~MouseLogger();
	Coord* mousePos;
	std::ostringstream strStream;
	bool escapeSequence;
	static LRESULT CALLBACK hookProcess(int code, WPARAM wParam, LPARAM lParam);
	DWORD WINAPI log(LPVOID param) override;
};

