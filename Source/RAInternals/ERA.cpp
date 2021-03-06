// ERA.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <fstream>
#include <iostream>
#include "LoggerHandler.h"
#include "Interpreter.h"

static Interpreter staticInterpreter;
static LoggerHandler staticLoggerHandler;
static bool isInterpreting;

extern "C" {
	__declspec(dllexport) double calculateRuntime(char* filepath) {
		std::string fp(filepath);
		return staticInterpreter.calculateRuntime(fp);
	}
	//reads the routine file to generate an action node sequence, and then executes the sequence with the params
	__declspec(dllexport) void executeAutomatedRoutine(char* filepath, float speed, int loops) {
		//convert to std::string for readLog function - using char* for marshalling with Pinvoke calls from C#
		std::string fp(filepath);
		//reads the file and returns the action node sequence
		ActionNode* actionSeq = staticInterpreter.readLog(fp);
		isInterpreting = true;//flag used for interrupting the playback
		for (int i = 0;i < loops;i++) {
			if (!isInterpreting) {
				break;
			}
			staticInterpreter.executeActions(actionSeq->next, speed);
		}
		staticInterpreter.cleanActionNodes(actionSeq);
		//kill the keywatcher thats used to interrupt the interpreter
		staticLoggerHandler.keyWatch->externalEscape = true;
	}
	//runs a keyWatcher to block until the macro sequence parameter is input
	_declspec(dllexport) void watchForStartSequence(int macroKeys[4]) {
		staticLoggerHandler.initLoggers(macroKeys);
		staticLoggerHandler.watchForStart();
	}
	//runs a keywatcher to block until the macro sequence parameter is input and then sets flags to stop the interpreter
	_declspec(dllexport) void interruptInterpreterSequence(int macroKeys[4]) {
		staticLoggerHandler.initLoggers(macroKeys);
		staticLoggerHandler.watchForStart();
		isInterpreting = false;
		staticInterpreter.isInterpreting = false;

	}
	//uses the logger handler to record user keystrokes/mouse activity
	__declspec(dllexport) void recordActivity(char* fileName) {
		std::string fn(fileName);
		staticLoggerHandler.recordActivity(fn);
		//delete(pLogHandler);
	}
}
int main()
{
	return 0;
}




