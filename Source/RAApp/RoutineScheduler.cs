using Microsoft.Win32.TaskScheduler;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using RAInterface;

namespace RA_Application
{
    class RoutineScheduler
    {
        private RAController raController;
        public RoutineScheduler(RAController rac)
        {
            raController = rac;
        }
        //The interval for how often the routine should repeat
        public enum IntervalType { None, Hourly, SixHourly, TwelveHourly, Daily, Weekly, Monthly }

        public void deleteTask(Microsoft.Win32.TaskScheduler.Task task)
        {
            using(TaskService taskService = new TaskService())
            {
                taskService.RootFolder.DeleteTask(task.Name);
            }
        }
        /*
         * Takes the ABSOLUTE path to the routine file, A DateTime for when to first execute, and an Interval for how often to repeat
         * This function then checks to make sure theres no scheduling conflicts then registers the routine with the task scheduler
         * The tasks scheduler will launch RABooter.exe with some cmd line args, RABooter then launches the main application and streams it data.
         */
        public bool scheduleTask(string routinePath, DateTime executionTime, IntervalType interval)
        {
            //Checks to make sure no other routines will be running during the time period this routine is supposed to run.
            if(checkValidity(routinePath.Substring(0), executionTime))
            {
                using (TaskService taskService = new TaskService())
                {
                    string filePath = Directory.GetCurrentDirectory();
                    Guid uid = Guid.NewGuid();
                    //extract routine name from absolute file path
                    string routineName = routinePath.Substring(routinePath.LastIndexOf("\\") + 1, (routinePath.LastIndexOf(".") - routinePath.LastIndexOf("\\") - 1));

                    TaskDefinition taskDef = taskService.NewTask();
                    taskDef.RegistrationInfo.Description = "RA Routine Execution for " + routineName + " at " + executionTime.ToString() + " PATH: " + routinePath;
                    taskDef.RegistrationInfo.Author = "RA";
                    taskDef.Settings.StopIfGoingOnBatteries = false;
                    taskDef.Settings.DisallowStartIfOnBatteries = false;
                    taskDef.Settings.WakeToRun = true;
                    taskDef.Principal.LogonType = TaskLogonType.InteractiveToken;
                    TimeTrigger trigger = new TimeTrigger(executionTime);
                    switch (interval)
                    {
                        case IntervalType.Hourly:
                            trigger.Repetition.Interval = TimeSpan.FromHours(1); break;
                        case IntervalType.SixHourly:
                            trigger.Repetition.Interval = TimeSpan.FromHours(6); break;
                        case IntervalType.TwelveHourly:
                            trigger.Repetition.Interval = TimeSpan.FromHours(12); break;
                        case IntervalType.Daily:
                            trigger.Repetition.Interval = TimeSpan.FromDays(1); break;
                        case IntervalType.Weekly:
                            trigger.Repetition.Interval = TimeSpan.FromDays(7); break;
                        case IntervalType.Monthly:
                            trigger.Repetition.Interval = TimeSpan.FromDays(30); break;
                        default: break;
                    }
                    taskDef.Triggers.Add(trigger);
                    //this is what actually happens when the task runs. TaskScheduler launches RABooter -> RABooter launches RA -> RABooter tells RA What routine to execute
                    taskDef.Actions.Add(new ExecAction(filePath + "/RABooter.exe", routinePath + " " + filePath));
                    taskService.RootFolder.RegisterTaskDefinition(@"RA" + uid.ToString(), taskDef);
                    return true;
                }
            } else
            {
                return false;
            }

        }
        //Retrieves any task that starts with RA and then is followed by a standard GUID
        public Microsoft.Win32.TaskScheduler.Task[] getSchedule()
        {
            using (TaskService taskService = new TaskService())
            {
                Regex taskNamePattern = new Regex("RA.{8}-.{4}-.{4}-.{4}-.{12}");
                return taskService.FindAllTasks(taskNamePattern);
            }
        }

        //Checks every RA Task to see if it's time range overlaps with the proposed new task
        public bool checkValidity(string routinePath, DateTime executionTime)
        {
            Microsoft.Win32.TaskScheduler.Task[] currentTasks = getSchedule();
            if (currentTasks.Count() != 0)
            {
                //end time is calculated from start Time + Approximate run time
                DateTime routineEndTime = executionTime.AddMilliseconds(getRoutineRuntime(routinePath));
                for(int i=0;i<currentTasks.Count();i++)
                {
                    
                    DateTime taskStartTime = currentTasks[i].NextRunTime;
                    string taskRoutinePath = getRoutinePathFromTask(currentTasks[i]);
                    double taskRuntime = getRoutineRuntime(taskRoutinePath);
                    DateTime taskEndTime = taskStartTime.AddMilliseconds(taskRuntime);
                    if (isOverlappingTimeRange(executionTime, routineEndTime, taskStartTime, taskEndTime))
                    {
                        return false;
                    }
                }
            }
            return true;
            

        }
        //extracts a routine path from a Registered Tasks. When tasks are registered the end of the description has the path appended.
        public string getRoutinePathFromTask(Microsoft.Win32.TaskScheduler.Task task)
        {
            string taskDesc = task.Definition.RegistrationInfo.Description;
            string taskRoutinePath = taskDesc.Substring(taskDesc.IndexOf("PATH: ")+5);
            return taskRoutinePath;
        }
        public double getRoutineRuntime(string filepath)
        {
            return raController.calculateRuntime(filepath);
        }
        public bool isOverlappingTimeRange(DateTime startTime1, DateTime endTime1, DateTime startTime2, DateTime endTime2)
        {
            return (startTime1 >= startTime2 && startTime1 <= endTime2) || (endTime1 >= startTime2 && endTime1 <= endTime2) ||
                    (startTime1 <= startTime2 && endTime1 >= endTime2);
        }
    }
}
