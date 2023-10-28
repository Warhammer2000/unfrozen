using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using UnfrozenTestProject;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Missions/Create mission", fileName = "Mission")]
public class MissionDescription : ScriptableObject, IModel
{
    [Header("Base Settings")]
    public float id;
    public string title;
    public Sprite missionIcon;
    public int MissionScore;

    [Header("Fields(string)_to_fill_in")]

    [TextArea(5, 10)] public string details;
    public string missionHeroName;
    public string missionEnemyName;


    //TODO: Rework needed
    public event Action<string, object> PropertyChanged;
}
