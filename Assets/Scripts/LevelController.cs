//using System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public List<GameObject> obstacles;
    public int numOfObstacles;
    public static LevelController current;
    public float last_obstacle = 0;
    public float last_ork = 0;
    public GameObject first_obstacle;
    public Vector3 firstObstacleVector;
    public Vector3 firstOrkPosition;
    public GameObject ork_prefab;

    public float insects;
    public float grain;
    public float allInsects;
    public float allGrain;

    public UILabel grainLabel;
    public UILabel insectLabel;

    

    public float time;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        time = 3f;
        

        firstObstacleVector = first_obstacle.transform.position;
        firstOrkPosition = ork_prefab.transform.position;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            last_obstacle = Time.time;
            generateObstacle();

            last_ork = Time.time;
            generateOrk();
        } 
    }

    public void addInsect()
    {
        insects++;
        string temp = "" + insects;
        insectLabel.text = temp;
    }

    public void addGrain()
    {
        grain++;
        string temp = "" + grain;
        grainLabel.text = temp;
    }

    public void generateOrk()
    {
        //coordinate of obstacle

        float coordX = firstOrkPosition.x + 15f + Random.Range(0.0f, 10.0f);
        float coordY = Random.Range(-2.0f, 2.0f);
        float coordZ = -4f;

        GameObject obj = Instantiate(this.ork_prefab) as GameObject;
        obj.transform.position = new Vector3(coordX, coordY, coordZ);

        firstOrkPosition = obj.transform.position;

    }

    public void generateObstacle()
    {
        //index of obstacle
        float index = Mathf.Round(Random.Range(0.0f, 1.0f));
        
        Vector3 bird_pos = Bird.lastBird.transform.position;

        //coordinate of obstacle
        float coordX = firstObstacleVector.x + 3f + Random.Range(0.0f, 5.0f);
        float coordY = Random.Range(-2.0f, 4.0f);
        float coordZ = -4f;

        GameObject obj = Instantiate(this.obstacles[(int) index]) as GameObject;
        obj.transform.position = new Vector3(coordX, coordY, coordZ);
        firstObstacleVector = obj.transform.position;

    }

    IEnumerator wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        
    }
}
