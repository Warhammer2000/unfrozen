using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButtonService : MonoBehaviour
{
    public static Action<Button> GetTouched;

    private void OnEnable()
    {
        GetTouched += OnInteractableHandler;
    }
    private void OnDisable()
    {
        GetTouched -= OnInteractableHandler;
    }
    public void OnInteractableHandler(Button button)
    {
        button.interactable = false;
    }
}