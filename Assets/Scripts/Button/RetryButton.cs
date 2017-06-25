using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{

    public MyButton retryButton;
    public GameObject loosePrefab;
    Vector3 start_pos;

    void Start()
       {
           start_pos = Bird.lastBird.transform.position;
        retryButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("BirdLifes", 3);
        loosePrefab.SetActive(false);
        //Bird.lastBird.transform.position = start_pos;
        Time.timeScale = 1;
        if (scene.name == "Level1")
        { 
            SceneManager.LoadScene("Level1"); 
        }
        else if (scene.name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        
        PlayerPrefs.SetInt("BirdLifes", 3);
        PlayerPrefs.Save();
    }
}