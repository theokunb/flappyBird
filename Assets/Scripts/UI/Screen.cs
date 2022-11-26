using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Screen : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private CanvasGroup _canvasGroup;

    public event Action OnButtonClicked;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(ButtonClicked);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(ButtonClicked);

    }

    private void ButtonClicked()
    {
        OnButtonClicked?.Invoke();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1.0f;
        _actionButton.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _actionButton.interactable = false;
    }
}
