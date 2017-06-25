using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondLevelButton : MonoBehaviour
{

    public MyButton secondButton;
    void Start()
    {
        secondButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
        SceneManager.LoadScene("Level2");
    }
}