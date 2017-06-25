using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndObject : MonoBehaviour {

    public AudioClip winMusic = null;
    AudioSource winMusicSource = null;

    void Start()
    {
        winMusicSource = gameObject.AddComponent<AudioSource>();
        winMusicSource.clip = winMusic;
        //winMusicSource.playOnAwake = false;
        winMusicSource.loop = false;
    }

    void Update()
    {
        if (Bird.lastBird.isMusicOn)
        {
            winMusicSource.volume = 1;
        }
        else
        {
            winMusicSource.volume = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Bird bird = collider.GetComponent<Bird>();
        if (bird != null)
        {
            if (Bird.lastBird.isMusicOn)
            {
                winMusicSource.volume = 1;
            }
            else
            {
                winMusicSource.volume = 0;
            }

        }

    }
}
