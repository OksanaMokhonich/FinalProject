using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public MyButton menuButton;
    void Start()
    {
        menuButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
       
            SceneManager.LoadScene("StartScene");
            PlayerPrefs.SetInt("BirdLifes", 3);
            PlayerPrefs.Save();
            Time.timeScale = 1;
        
    }
}