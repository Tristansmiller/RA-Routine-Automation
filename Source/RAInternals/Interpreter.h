#include <Windows.h>
#include <string>
#include <fstream>
#include <iostream>
#include <sstream>
#include "ActionNode.h"
#pragma once
class Interpreter
{
public:
	MouseController* mouseControl;//Pointer to the MouseController for the interpreter - passed along to the Action Nodes
	KeyboardController* keyControl;//Pointer to the KeyboardController for the interpreter - passed along to the Action Nodes
	ActionNode* actionListHead;//head to the action node linked list, is a sentinel node so it's next pointer is the first real node.
	bool isInterpreting;//flag used to interrupt an execution.

	//Opens the file at the filepath param and attempts to generate an actionNode sequence from it.
	ActionNode* readLog(std::string filepath);

	/*executes an action node sequence with the speed param
	 *The speed param is a decimal percentage i.e. .74 = 74% speed*/
	int executeActions(ActionNode* headNode,float speed);

	//Reads the file at the filepath specified and executes the action node sequence that was generated.
	void executeLog(std::string filepath, float speed);

	double calculateRuntime(std::string filepath);

	void cleanActionNodes(ActionNode * node);
	
	Interpreter();
	Interpreter(int mDelay, int kDelay);
	~Interpreter();
};

