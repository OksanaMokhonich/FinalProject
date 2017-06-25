using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public GameObject settingsPrefab;

    public Camera camera;

    public MyButton settingsButton;
    void Start()
    {
        Time.timeScale = 1;
        settingsButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {

        GameObject obj = Instantiate(this.settingsPrefab) as GameObject;
        obj.transform.position = camera.transform.position;
      

        Time.timeScale = 0;
        Debug.Log("settings");
    }
}