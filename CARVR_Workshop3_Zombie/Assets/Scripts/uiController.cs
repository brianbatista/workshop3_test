using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class uiController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;


    [SerializeField]
    private GameObject openingPanel;

    private void Awake()
    {
        startButton.onClick.AddListener(ChangeScene);   
    }

    private void ChangeScene()
    {
        openingPanel.SetActive(false);
        SceneManager.LoadScene("ZombieScene");
    }
}
