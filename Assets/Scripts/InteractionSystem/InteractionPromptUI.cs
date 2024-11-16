using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;
    public bool isDisplayed = false;
    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;
        _uiPanel.SetActive(false);
        isDisplayed = false;
        
    }

    
    private void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, 
            rotation * Vector3.up);
    }

    public void SetUp(string promptText)
    {
        if (string.IsNullOrEmpty(promptText))
        {
            return;
        }

        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }
    
    public void Close()
    {
        isDisplayed = false;
        _uiPanel.SetActive(false);
    }
}
