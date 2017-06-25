using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour {

    public AudioClip winMusic = null;
    AudioSource winMusicSource = null;

    void Start()
    {
        winMusicSource = gameObject.AddComponent<AudioSource>();
        winMusicSource.clip = winMusic;
        winMusicSource.playOnAwake = false;
        winMusicSource.loop = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Bird bird = collider.GetComponent<Bird>();
        if (bird != null)
        {
            if(Bird.lastBird.isMusicOn){
                winMusicSource.playOnAwake = true;
            }
        }

    }
}
