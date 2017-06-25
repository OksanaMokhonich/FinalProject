using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : Collectable
{
    public AudioClip dieMusic = null;
    AudioSource dieMusicSource = null;

    void Start()
    {
        dieMusicSource = gameObject.AddComponent<AudioSource>();
        dieMusicSource.clip = dieMusic;
        dieMusicSource.loop = false;
    }

    public override void OnBirdHit(Bird bird)
    {
        bird.removeHealth();
        Debug.Log("play lose");
        this.CollectedHide();

    }

    IEnumerator play() {
        if (Bird.lastBird.isMusicOn)
        {
            dieMusicSource.Play();
        }
        yield return new WaitForSeconds(1.5f);
        Bird.lastBird.removeHealth();
    }
}
