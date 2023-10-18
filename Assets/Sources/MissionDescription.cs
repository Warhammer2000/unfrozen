using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Missions/Create mission", fileName = "Mission")]
public class MissionDescription : ScriptableObject
{
    public float id;
    public string title;
    public Sprite missionIcon;

    [TextArea(5, 10)]
    public string details;
}
