#include "stdafx.h"
#include "Interpreter.h"

Interpreter::Interpreter()
{
	mouseControl = new MouseController();
	keyControl = new KeyboardController();
}

Interpreter::Interpreter(int mDelay, int kDelay) {
	mouseControl = new MouseController(mDelay);
	keyControl = new KeyboardController(kDelay);
}


Interpreter::~Interpreter()
{
	delete(mouseControl);
	delete(keyControl);
	delete(actionListHead);
}


void Interpreter::cleanActionNodes(ActionNode* node) {
	ActionNode * next = node->next;
	delete node;
	while (next != NULL) {
		node = next;
		next = node->next;
		delete node;
	}
}

/*Combination of the executeActions and readLog functions, this function takes a file path to a log, reads the log, and executes the nodes.
*/
void Interpreter::executeLog(std::string filepath, float speed) 
{
    ActionNode* sentinel = readLog(filepath);
	executeActions(sentinel->next,speed);
	cleanActionNodes(sentinel);
}
/*This node executes an actionNode and all subseqeuent action nodes that are chained to it.
*/
int Interpreter::executeActions(ActionNode* node, float speed) {
	isInterpreting = true;
	while (node != NULL && isInterpreting) {
		node->execute(speed);
		node = node->next;
	}
	return 0;
}
/* Calculates runtime by retrieving the start node's time and subtracting it from the end nodes time
*/
double Interpreter::calculateRuntime(std::string filepath) {
	if (filepath.at(0) == ' ') {
		filepath = filepath.substr(1, filepath.length() - 1);
	}
	ActionNode* sentinel = readLog(filepath);
	ActionNode* node = sentinel->next;
	double startNodeTime = node->params->timeParam;
	while (node->next != NULL) {
		node = node->next;
	}
	double endNodeTime = node->params->timeParam;
	double totalRunTime = endNodeTime - startNodeTime;
	return totalRunTime;
}
/*This function will generate a list of action nodes to be executed after reading a log file.
* The first node is a sentinel node, so the next needs to be used to start execution.
*/
ActionNode* Interpreter::readLog(std::string filepath) {
	ActionNode *head = new ActionNode();
	ActionNode *curr = NULL;
	std::ifstream file;
	std::string logLine;
	
	file.open(filepath);
	try {
		while (std::getline(file, logLine)) {
			if (logLine.length() != 0) {
				ActionNode::ActionParam* params = new ActionNode::ActionParam();
				if (curr != NULL) {
					params->predNodeTime = curr->params->timeParam;
				}
				params->keyControl = keyControl;
				params->mouseControl = mouseControl;
				if (logLine.at(0) == 'M') {
					if (logLine.at(1) == 'M') {
						int yIndex = logLine.find('Y', 2);
						int tIndex = logLine.find('T', yIndex);
						int xCoord;
						int yCoord;
						try {
							xCoord = std::stoi(logLine.substr(3, yIndex - 3));
							yCoord = std::stoi(logLine.substr(yIndex + 1, tIndex - yIndex));
						}
						catch (std::exception&) { printf("error"); }
						params->xParam = xCoord;
						params->yParam = yCoord;
						double time = std::stod(logLine.substr(tIndex+1, logLine.length() - tIndex - 1));
						params->timeParam = time;
						if (head->next == NULL) {
							head->next = new ActionNode();
							head->next->params = params;
							head->next->func = ActionNode::moveMouse;
							curr = head->next;
						}
						else {
							curr->next = new ActionNode();
							curr->next->params = params;
							curr->next->func = ActionNode::moveMouse;
							curr = curr->next;
						}
					}
					else if (logLine.at(1) == 'C') {
						if (logLine.at(2) == 'L') {
							if (logLine.at(3) == 'D') {
								int yIndex = logLine.find('Y', 5);
								int tIndex = logLine.find('T', yIndex);
								int xCoord = std::stoi(logLine.substr(5, yIndex - 5));
								int yCoord = std::stoi(logLine.substr(yIndex+1, tIndex-yIndex));
								double time = std::stod(logLine.substr(tIndex + 1, logLine.length() - tIndex - 1));
								params->xParam = xCoord;
								params->yParam = yCoord;
								params->mButtonParam = 'p';
								params->timeParam = time;
								if (head->next == NULL) {
									head->next = new ActionNode();
									head->next->params = params;
									head->next->func = ActionNode::mouseDown;
									curr = head->next;
								}
								else {
									curr->next = new ActionNode();
									curr->next->params = params;
									curr->next->func = ActionNode::mouseDown;
									curr = curr->next;
								}
							}
							else if (logLine.at(3) == 'U') {
								int yIndex = logLine.find('Y', 5);
								int tIndex = logLine.find('T', yIndex);
								int xCoord = std::stoi(logLine.substr(5, yIndex - 5));
								int yCoord = std::stoi(logLine.substr(yIndex+1, tIndex-yIndex));
								double time = std::stod(logLine.substr(tIndex + 1, logLine.length() - tIndex - 1));
								params->xParam = xCoord;
								params->yParam = yCoord;
								params->mButtonParam = 'p';
								params->timeParam = time;
								if (head->next == NULL) {
									head->next = new ActionNode();
									head->next->params = params;
									head->next->func = ActionNode::mouseUp;
									curr = head->next;
								}
								else {
									curr->next = new ActionNode();
									curr->next->params = params;
									curr->next->func = ActionNode::mouseUp;
									curr = curr->next;
								}
							}
						}
						else if (logLine.at(2) == 'R') {
							if (logLine.at(3) == 'D') {
								int yIndex = logLine.find('Y', 4);
								int tIndex = logLine.find('T', yIndex);
								int xCoord = std::stoi(logLine.substr(4, yIndex - 4));
								int yCoord = std::stoi(logLine.substr(yIndex+1, tIndex-yIndex));
								double time = std::stod(logLine.substr(tIndex + 1, logLine.length() - tIndex - 1));
								params->xParam = xCoord;
								params->yParam = yCoord;
								params->mButtonParam = 's';
								params->timeParam = time;
								if (head->next == NULL) {
									head->next = new ActionNode();
									head->next->params = params;
									head->next->func = ActionNode::mouseDown;
									curr = head->next;
								}
								else {
									curr->next = new ActionNode();
									curr->next->params = params;
									curr->next->func = ActionNode::mouseDown;
									curr = curr->next;
								}
							}
							else if (logLine.at(3) == 'U') {
								int yIndex = logLine.find('Y', 4);
								int tIndex = logLine.find('T', 4);
								int xCoord = std::stoi(logLine.substr(4, yIndex - 4));
								int yCoord = std::stoi(logLine.substr(yIndex+1, tIndex - yIndex));
								double time = std::stod(logLine.substr(tIndex + 1, logLine.length() - tIndex - 1));
								params->xParam = xCoord;
								params->yParam = yCoord;
								params->mButtonParam = 's';
								params->timeParam = time;
								if (head->next == NULL) {
									head->next = new ActionNode();
									head->next->params = params;
									head->next->func = ActionNode::mouseUp;
									curr = head->next;
								}
								else {
									curr->next = new ActionNode();
									curr->next->params = params;
									curr->next->func = ActionNode::mouseUp;
									curr = curr->next;
								}
							}
						}

					}
				}
				//									!K[DU]CONTROL
				else if (logLine.at(0) == 'K') {
					int tIndex = logLine.find('T', 2);
					params->keyParam = (WORD)std::stoi(logLine.substr(2, tIndex - 2));
					params->timeParam = std::stod(logLine.substr(tIndex + 1, logLine.length() - tIndex - 1));
					if (logLine.at(1) == 'D') {
						if (head->next == NULL) {
							head->next = new ActionNode();
							head->next->params = params;
							head->next->func = ActionNode::keyDown;
							curr = head->next;
						}
						else {
							curr->next = new ActionNode();
							curr->next->params = params;
							curr->next->func = ActionNode::keyDown;
							curr = curr->next;
						}

					}
					else if (logLine.at(1) == 'U') {
						if (head->next == NULL) {
							head->next = new ActionNode();
							head->next->params = params;
							head->next->func = ActionNode::keyUp;
							curr = head->next;
						}
						else {
							curr->next = new ActionNode();
							curr->next->params = params;
							curr->next->func = ActionNode::keyUp;
							curr = curr->next;
						}
					}
				}
			}
		}
		actionListHead = head;
		file.close();
		return head;
	}
	catch (std::exception ex) {
		cout << "Something went wrong while reading the file. Check the file path.";
		file.close();
		return NULL;
	}
}
