#include "KeyboardController.h"
#include "MouseController.h"
#pragma once
class ActionNode
{
public:

	//This struct is used to hold various parameters that can be used for the functions an action node executes
	//params are put into a struct so that all the action node functions can have the same function signature.
	struct ActionParam {
	public:
		int xParam;//x coordinate for a mouse movement
		int yParam;//y coordinate for a mouse movement
		double predNodeTime;//time stamp of the previous node
		double timeParam;//time stamp of this action node
		WORD keyParam;//the VK for a key stroke
		char mButtonParam;//char signifying which mouse button for a mouse click ('p'-primary, 's'-secondary, 't'-tertiary
		KeyboardController * keyControl;//pointer to the key controller that the action node should use
		MouseController* mouseControl;//pointer to the mouse controller that the action node should use
	};
	/*function pointer - this gets set to one of the 5 functions (mouseMove, mouseDown, mouseUp,keyDown,keyUp)
	 *This is done so that the function can be aliased under the *func name. execute calls this function.
	 *Doing it this way makes it so that the nodes do not have to reevaluate which function to execute.
	 */
	void(*func)(ActionParam*);
	ActionNode* next;//pointer to the next node in the sequence
	ActionParam* params;//pointer to the ActionParam instance that this node using
	
	//This is called by the interpreter as it iterates the action node sequence, it executes whatever function the *func pointer points to.
	void execute(float speed);

	//use the ActionParam's MouseController to move the mouse to it's x and y coordinates.
	static void moveMouse(ActionParam* param);

	//Use the ActionParam's MouseController to press the mouse down.
	static void mouseDown(ActionParam* param);
	
	//Use the ActionParam's MouseController to release the mouse.
	static void mouseUp(ActionParam* param);
	
	//Use the Actionparam's KeyboardController to press the key in the ActionParam down.
	static void keyDown(ActionParam* param);

	//Use the ActionParam's KeyboardController to release the key in the ActionParam.
	static void keyUp(ActionParam* param);

	ActionNode();
	~ActionNode();
};

															    