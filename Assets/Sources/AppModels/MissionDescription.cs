using System;
using System.Collections;
using System.Collections.Generic;
using UnfrozenTestProject;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Missions/Create mission", fileName = "Mission")]
public class MissionDescription : ScriptableObject, IModel
{
    public float id;
    public string title;
    public Sprite missionIcon;

    [TextArea(5, 10)]
    public string details;

    public HeroModel heroModel;

    //TODO: Rework needed
    public event Action<string, object> PropertyChanged;
}
