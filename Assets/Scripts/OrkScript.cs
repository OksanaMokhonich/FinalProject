using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkScript : MonoBehaviour {

    public GameObject arrowPrefab;
    float last_arrow = 0f;
    bool attack;
    SpriteRenderer sr;
    bool orkRight;

    public static OrkScript ork;

    

    void Awake()
    {
        ork = this;
    }


	// Use this for initialization
	void Start () {
        //this.GetComponent<Animator>().SetBool("iddle", true);
        
        
	}
	
	// Update is called once per frame
    void Update()
    {
        sr = GetComponent<SpriteRenderer>();
        float bird_pos = Bird.lastBird.transform.position.x;
        float ork_pos = this.transform.position.x;
        float value = ork_pos - bird_pos;
        if (value > 0)
        {
            sr.flipX = false;
            orkRight = false;
        }
        else if (value < 0)
        {
            sr.flipX = true;
            orkRight = true;
        }


        if (Mathf.Abs(Bird.lastBird.transform.position.x - this.transform.position.x) < 15f)
        {
            attack = true;
            this.GetComponent<Animator>().SetBool("idle", false);
            this.GetComponent<Animator>().SetBool("attack", true);
        }
        else
        {
            attack = false;
            this.GetComponent<Animator>().SetBool("attack", false);
            this.GetComponent<Animator>().SetBool("idle", true);
        }

        if (attack)
        {
            if (Time.time - last_arrow > 0.8f)
            {
                last_arrow = Time.time;
                //StartCoroutine(throwArrow(2f));
                GameObject obj = Instantiate(this.arrowPrefab) as GameObject;
                obj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -4);
                obj.GetComponent<Arrow>().right = orkRight;
            }
        }
    }


    public void hide()
    {
        StartCoroutine(destroyOrk(1.8f));
    }

    IEnumerator destroyOrk(float duration)
    {
        
        this.GetComponent<Animator>().SetBool("die", true);
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }

    IEnumerator throwArrow(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject obj = Instantiate(this.arrowPrefab) as GameObject;
        obj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y , -4);
    }


}
