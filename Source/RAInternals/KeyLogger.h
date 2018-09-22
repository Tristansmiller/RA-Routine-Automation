#pragma once
#include "Logger.h"
class KeyLogger :
	public Logger
{
public:
	KeyLogger();
	KeyLogger(HANDLE h);
	~KeyLogger();
	bool ctrlDown;//flag for whether control is down - deprecated
	bool escapeSequence;//flag for when the macro sequence is all held down at the same time - kills the thread.
	int macroKeys[4];//the virtual keys for the start/stop macro
	bool keysDown[4];//keysDown[i]==true means macroKeys[i] is currently held down
	std::ostringstream strStream; //stream used to generate strings for the LogNode sequence.
	/*Hook for the logger, this function is installed as a hook, which is essentially a filter function to be called when I/O occurs*/
	static LRESULT CALLBACK hookProcess(int code, WPARAM wParam, LPARAM lParam);
	/*outer function that the thread executes. essentially just keeps the thread running for the hook*/
	DWORD WINAPI log(LPVOID param) override;
};

