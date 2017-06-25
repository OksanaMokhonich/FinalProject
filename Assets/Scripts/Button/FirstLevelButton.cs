using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelButton : MonoBehaviour
{

    public MyButton firstButton;
    void Start()
    {
        firstButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
        SceneManager.LoadScene("Level1");
    }
}