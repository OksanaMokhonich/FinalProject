using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {


    public GameObject firstLevelDone;
    public GameObject secondLevelDone;

	void Start () {
        
        firstLevelDone.SetActive(false);
        secondLevelDone.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
        int first = PlayerPrefs.GetInt("firstLevel", 0);
        int second = PlayerPrefs.GetInt("secondLevel", 0);

        if (first == 1)
        {
            firstLevelDone.SetActive(true);
        } if (second == 1)
        {
            secondLevelDone.SetActive(true);
        }	
	}
}
