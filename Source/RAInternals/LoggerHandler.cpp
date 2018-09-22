#include "stdafx.h"
#include "LoggerHandler.h"


LoggerHandler::LoggerHandler()
{
}


LoggerHandler::~LoggerHandler()
{
}
void LoggerHandler::initLoggers(int macroVKs[4]) {
	keyWatch = new KeyWatcher();
	keyLog = new KeyLogger();
	for (int i = 0;i < 4;i++) {
		keyWatch->macroKeys[i] = macroVKs[i];
		keyLog->macroKeys[i] = macroVKs[i];
		if (macroVKs[i] == 0) {
			keyWatch->keysDown[i] = true;
			keyLog->keysDown[i] = true;
		}
		else {
			keyWatch->keysDown[i] = false;
			keyLog->keysDown[i] = false;
		}
	}
	mouseLog = new MouseLogger();
}
int LoggerHandler::recordActivity(std::string filepath) {
	startLogger(keyLog);
	startLogger(mouseLog);
	WaitForSingleObject(keyLog->logHandle, INFINITE);
	killLogger(keyLog);
	killLogger(mouseLog);
	//printf("Stopped Recording.");
	writeLogFile(filepath);
	return 0;
}
int LoggerHandler::startLogger(Logger* log) {
	log->logHandle = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)Logger::logWrapper,(LPVOID)log, NULL, &(log->logThread));
	return 0;
}
int LoggerHandler::watchForStart() {
	//printf("Press Ctrl+~ to start recording.\n");
	startLogger(keyWatch);
	WaitForSingleObject(keyWatch->logHandle, INFINITE);
	killLogger(keyWatch);
	//printf("Watcher killed, starting recording.\n");
	return 0;
}
int LoggerHandler::killLogger(Logger* log) {
	UnhookWindowsHookEx((log->logHook));
	TerminateThread(log->logHandle, log->logThread);
	CloseHandle(log->logHandle);
	return 0;
}
int LoggerHandler::writeLogFile(std::string filepath) {
	//std::remove(filepath.c_str());
	std::ofstream file;
	file.open(filepath);
	Logger::LogNode* mouseNode = mouseLog->head;
	Logger::LogNode* keyNode = keyLog->head;
	mouseNode = mouseNode->next;
	keyNode = keyNode->next;
	while (keyNode != NULL || mouseNode != NULL) {
		try {
			if (mouseNode == NULL || mouseNode == nullptr) {
				file << keyNode->logline;
				file << "\n";
				keyNode = keyNode->next;
			}
			else if (keyNode == NULL || keyNode == nullptr) {
				file << mouseNode->logline;
				file << "\n";
				mouseNode = mouseNode->next;
			}
			else {
				int mouseTIndex = mouseNode->logline.find('T', 3);
				int keyTIndex = keyNode->logline.find('T', 2);
				std::string mouseStamp = mouseNode->logline.substr(mouseTIndex + 1, mouseNode->logline.length() - mouseTIndex - 1);
				std::string keyStamp = keyNode->logline.substr(keyTIndex + 1, keyNode->logline.length() - keyTIndex - 1);
				double mouseTime = std::stod(mouseStamp);
				double keyTime = std::stod(keyStamp);
				if (mouseTime > keyTime) {
					file << keyNode->logline;
					file << "\n";
					keyNode = keyNode->next;
				}
				else {
					file << mouseNode->logline;
					file << "\n";
					mouseNode = mouseNode->next;
				}
			}
		}
		catch (std::exception e) {}
	}
	//Add a control up to the file, control down is captured as part of the escape sequence and needs to go back up.
	double time = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
	file << "KU17T" << std::fixed << time << "\n";
	file.close();
	cleanLogNodes(mouseLog->head);
	cleanLogNodes(keyLog->head);
	return 0;
}
void LoggerHandler::cleanLogNodes(Logger::LogNode* node) {
	Logger::LogNode* next = node->next;
	delete node;
	while (next != NULL) {
		node = next;
		next = node->next;
		delete node;
	}
}

