using System;
using System.Collections;
using System.Collections.Generic;
using UnfrozenTestProject;
using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour
{
    public float Id;
    private Button taskButton;

    public MissionDescription Missions;
    public Action<float> OnClick;

    public MapController mapController;
    public HeroModel heroModel;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardTransform;

    [SerializeField] private Button missionCompleteButton;
    private void Start()
    {
        taskButton = GetComponent<Button>();
        taskButton.onClick.AddListener(OnTaskButtonClick);
        taskButton.onClick.AddListener(Indexator);
        missionCompleteButton.onClick.AddListener(CreateNewCard);
    }

    private void OnTaskButtonClick()
    {
        OnClick?.Invoke(Id);
    }
    public void Indexator()
    {
        mapController.index = Id;
    }
    public void IO()
    {
        heroModel = Missions.heroModel;
    }
    public void CreateNewCard()
    {
        if (Id >= 1)
        {
            return;
        }
        GameObject card = Instantiate(cardPrefab, cardTransform);
        CardViewModel cardViewModel = card.GetComponent<CardViewModel>();
        cardViewModel.heroesProvider.GetHeroModel("0");
        
        
    }
}
