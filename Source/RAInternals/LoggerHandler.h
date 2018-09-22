#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include "Logger.h"
#include "KeyLogger.h"
#include "MouseLogger.h"
#include "KeyWatcher.h"
class LoggerHandler
{
public:
	LoggerHandler();
	~LoggerHandler();
	
	KeyLogger* keyLog;
	KeyWatcher* keyWatch;
	MouseLogger* mouseLog;
	int startLogger(Logger* log);
	/*Waits for the user to press Ctrl+~, then records user activity until Ctrl+~ is pressed again.*/
	int recordActivity(std::string filepath);
	void initLoggers(int macroVKs[4]);
	/*Monitors keystrokes (but doesn't LOG) until the user presses Ctrl+~.
	This is used to watch global input (so the logger can start no matter what window is focused) and blocks until it sees the correct sequence.*/
	int watchForStart();
	int killLogger(Logger* log);
	int writeLogFile(std::string filepath);
	void cleanLogNodes(Logger::LogNode* node);
};

