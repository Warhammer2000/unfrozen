using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionView : MonoBehaviour
{
    public MissionModel missionModel;
    public MissionViewModel viewModel;
    public Button taskButton;
    public TaskPanel taskPanel;

    private void Start()
    {
        taskPanel.gameObject.SetActive(false);
        viewModel = new MissionViewModel();
        taskButton = GetComponent<Button>();    
        taskButton.onClick.AddListener(OnTaskButtonClick);
        // Другие настройки UI-элементов
    }

    private void OnTaskButtonClick()
    {
        viewModel.SelectTask(missionModel, taskPanel); // Здесь передайте выбранное задание в метод SelectTask
    }
}
