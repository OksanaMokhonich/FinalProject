using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLooseObject : MonoBehaviour
{

    public AudioClip looseMusic = null;
    AudioSource looseMusicSource = null;

    void Start()
    {
        looseMusicSource = gameObject.AddComponent<AudioSource>();
        looseMusicSource.clip = looseMusic;
        looseMusicSource.loop = false;
        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            looseMusicSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Bird bird = collider.GetComponent<Bird>();
        if (bird != null)
        {
            Debug.Log("collided");
            
        }

    }
}
