using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicOn : MonoBehaviour
{

    public MyButton musicOnButton;
    public GameObject musicOn;
    public GameObject musicOff;

    void Start()
    {
        if (!Bird.lastBird.isMusicOn)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        musicOnButton.signalOnClick.AddListener(this.onPlay);
    }

    void onPlay()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        PlayerPrefs.SetInt("music", 1);
        PlayerPrefs.Save();
    }


}