#include "stdafx.h"
#include "ActionNode.h"


ActionNode::ActionNode()
{
}


ActionNode::~ActionNode()
{
	delete params;
}
void ActionNode::execute(float speed) {
	(*func)(params);
	if (params->predNodeTime > 0) {
		long targetTime = params->timeParam - params->predNodeTime;
		targetTime = targetTime / speed;
		std::this_thread::sleep_for(std::chrono::milliseconds(targetTime));
	}
}
void ActionNode::keyDown(ActionNode::ActionParam* param) {
	param->keyControl->keyPress(param->keyParam);
}
void ActionNode::keyUp(ActionNode::ActionParam* param) {
	param->keyControl->keyRelease(param->keyParam);
}
void ActionNode::mouseDown(ActionNode::ActionParam* param) {
	param->mouseControl->moveMouse(param->xParam, param->yParam);
	Sleep(200);
	param->mouseControl->pressMouse(param->mButtonParam);
}
void ActionNode::mouseUp(ActionNode::ActionParam* param) {
	param->mouseControl->moveMouse(param->xParam, param->yParam);
	Sleep(200);
	param->mouseControl->releaseMouse(param->mButtonParam);
}
void ActionNode::moveMouse(ActionNode::ActionParam* param) {
	param->mouseControl->moveMouse(param->xParam, param->yParam);
}