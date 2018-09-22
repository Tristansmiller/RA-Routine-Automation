#pragma once
#include "Logger.h"
class KeyWatcher :
	public Logger
{
public:
	KeyWatcher();
	KeyWatcher(HANDLE h);
	~KeyWatcher();
	bool ctrlDown;
	bool escapeSequence;
	bool externalEscape;
	int macroKeys[4];
	bool keysDown[4];
	static LRESULT CALLBACK hookProcess(int code, WPARAM wParam, LPARAM lParam);
	DWORD WINAPI log(LPVOID param) override;
};

