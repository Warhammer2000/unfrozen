using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour
{
    [SerializeField] private float id;
    private Button taskButton;

    public Action<float> OnClick;

    private void Start()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(OnTaskButtonClick);
    }

    private void OnTaskButtonClick()
    {
        OnClick?.Invoke(id);
    }
}
