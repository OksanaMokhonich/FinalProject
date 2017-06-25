using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicOff : MonoBehaviour
{

    public MyButton musicOffButton;
    public GameObject musicOn;
    public GameObject musicOff;

    void Start()
    {
        musicOffButton.signalOnClick.AddListener(this.onPlay);
    }

    void onPlay()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        PlayerPrefs.SetInt("music", 0);
        PlayerPrefs.Save();

    }

   
}