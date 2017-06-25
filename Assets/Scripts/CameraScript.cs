using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Bird bird;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 bird_pos = bird.transform.position;
        Vector3 camera_pos = this.transform.position;

        camera_pos.x = bird_pos.x+7;
        //camera_pos.y = bird_pos.y;

        this.transform.position = camera_pos;
	}
}
