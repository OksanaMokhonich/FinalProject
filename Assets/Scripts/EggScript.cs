using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour {

    //public GameObject orkPrefab;
    public AudioClip orkMusic = null;
    AudioSource orkMusicSource = null;

	void Start () {
        StartCoroutine(destroyLater());
        orkMusicSource = gameObject.AddComponent<AudioSource>();
        orkMusicSource.clip = orkMusic;
        orkMusicSource.loop = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, 0.2f, 0);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        OrkScript ork = collider.GetComponent<OrkScript>();
        if (ork != null)
        {
            Debug.Log("ooooork");
            if (Bird.lastBird.isMusicOn)
            {
                orkMusicSource.Play();
            }
            StartCoroutine(destroyLater());
            Debug.Log("ork die play");
            ork.hide();

        }

    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

}
