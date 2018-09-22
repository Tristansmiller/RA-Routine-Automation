#include <Windows.h>
#include <string>
#include <time.h>
#include <iostream>
#include <fstream>
#include <sstream>
#include <chrono>
#pragma once
class Logger
{
public:
	Logger();
	~Logger();
	/*Mouse coordinates*/
	struct Coord {
	public: int x;
			int y;
	};
	class LogNode {
	public:
		std::string logline;
		double* time;
		LogNode * next;
		LogNode(std::string ll, long t) {
			time = new double(t);
			logline = ll;	
		}
		~LogNode() {
		}
	};
	Logger::LogNode* head;
	Logger::LogNode* curr;
	HHOOK logHook;
	HANDLE logHandle;
	DWORD logThread;
	static LRESULT CALLBACK hookProcess(int code, WPARAM wParam, LPARAM lParam);
	virtual DWORD WINAPI log(LPVOID param);
	static DWORD WINAPI logWrapper(LPVOID param);
	void clearLogList();
};

