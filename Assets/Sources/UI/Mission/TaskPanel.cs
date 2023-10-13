using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image Icon;
    public TextMeshProUGUI description;

    private void Awake()
    {
        title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Icon = transform.GetChild(1).GetChild(0).GetComponent<Image>();    
        description = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();    
    }
    public void SetTask(MissionModel task)
    {
        title.text = task.title;
        Icon.sprite = task.missionIcon;
        description.text = task.missionDescription; 
        gameObject.SetActive(true); 
    }

}
