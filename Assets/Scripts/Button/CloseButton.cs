using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    public GameObject settingsPrefab;

    public MyButton closeButton;
    void Start()
    {
        closeButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
        settingsPrefab.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("lol");
    }
}