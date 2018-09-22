#include "stdafx.h"
#include "Logger.h"

#pragma region Constructor/Destructor
Logger::Logger()
{
}


Logger::~Logger()
{
}

void Logger::clearLogList() {
	delete(head);
}
DWORD WINAPI Logger::log(LPVOID param) {
	return 0;
}
DWORD WINAPI Logger::logWrapper(LPVOID param){
	Logger* logObj = (Logger*)param;
	logObj->log(NULL);
	return 0;
}
#pragma endregion







