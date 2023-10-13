using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Mission/New Mission", fileName = "Mission")]
public class MissionModel : ScriptableObject
{
    public int id;
    public string title;
    public Sprite missionIcon;

    [TextArea(5, 10)]
    public string missionDescription;

}
