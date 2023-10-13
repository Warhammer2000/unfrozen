using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionViewModel 
{
    public MissionModel SelectedTask { get; set; }
    public TaskPanel TaskPanel;

    public void SelectTask(MissionModel task, TaskPanel taskpanel)
    {
        SelectedTask = task;
        TaskPanel = taskpanel;
        TaskPanel.SetTask(task);
    }
}
