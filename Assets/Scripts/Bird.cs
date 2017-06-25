
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public bool isMusicOn; 
    float wait_time = 0.5f;
    float temp = 0;
    bool die;
    [Range(0.05f, 0.8f)]
    public float speedY = 2f;
    [Range(0.05f, 0.8f)]
    public float speedX = 0.04f;
    Rigidbody2D myBody = null;
    public Vector2 movement;
    public static Bird lastBird;
    public GameObject eggPrefab;
    float last_egg = 0;
    int lifes = 3;

    public float level_time = 5f;

    public GameObject looseWindow;
    public GameObject winWindow;

    public UILabel grainWinLabel;
    public UILabel insectWinLabel;

    public UILabel lifesLabel;

    public GameObject collider;
    public GameObject looseCollider;

    public AudioClip foneMusic = null;
    AudioSource foneMusicSource = null;

    public AudioClip winMusic = null;
    AudioSource winMusicSource = null;

    public AudioClip dieMusic = null;
    AudioSource dieMusicSource = null;

    void Awake()
    {
        
        lastBird = this;
    }

    void Start()
    {
        collider.SetActive(false);
        looseCollider.SetActive(false);
        foneMusicSource = gameObject.AddComponent<AudioSource>();
        foneMusicSource.clip = foneMusic;
        foneMusicSource.loop = true;
        foneMusicSource.Play();

        winMusicSource = gameObject.AddComponent<AudioSource>();
        winMusicSource.clip = winMusic;
        winMusicSource.loop = false;

        dieMusicSource = gameObject.AddComponent<AudioSource>();
        dieMusicSource.clip = dieMusic;
        dieMusicSource.loop = false;

        lifes = PlayerPrefs.GetInt("BirdLifes", 3 );
        string temp = "" + lifes;
        //PlayerPrefs.SetInt();
        lifesLabel.text = temp;
        myBody = this.GetComponent<Rigidbody2D>();
        Animator animator = this.GetComponent<Animator>();
        animator.SetBool("fly", true);
    }

    void Update()
    {
        int mus = PlayerPrefs.GetInt("music", 1);
        if (mus == 1)
        {
            isMusicOn = true;
        }
        else
        {
            isMusicOn = false;
        }
        if (!isMusicOn)
        {
            foneMusicSource.volume = 0;
        }
        else
        {
            foneMusicSource.volume = 1;
        }
        if (level_time > 0)
        {
            winWindow.SetActive(false);
            level_time -= Time.deltaTime;
           // Debug.Log(die);
            lifes = PlayerPrefs.GetInt("BirdLifes", 3);
            string temp = "" + lifes;
            lifesLabel.text = temp;
            float value = Input.GetAxis("Vertical");
            if (!die)
            {
                myBody.MovePosition(new Vector3(speedX, speedY * value, 0) + transform.position);
                if (Input.GetButton("Jump"))
                {
                    launchEgg();
                }
            }
            if (die)
            {
                /// this.transform.position -= new Vector3(-0.03f, 0.04f, 0);
            }
        }
        else
        {   //Debug.Log("win play");
            collider.SetActive(true);
           lifes = 3;
           PlayerPrefs.SetInt("BirdLifes", lifes);

           winWindow.transform.position = new Vector3(0, 0, -4);
           winWindow.SetActive(true);

           string ins = "" + LevelController.current.insects;
           string grn = "" + LevelController.current.grain;
           // Debug.Log(ins);
           // Debug.Log(grn);
           grainWinLabel.text = grn;
           insectWinLabel.text = ins;

           foneMusicSource.Stop();


           if (SceneManager.GetActiveScene().name == "Level1")
           {
               PlayerPrefs.SetInt("firstLevel", 1);
               PlayerPrefs.Save();


           }
           else if (SceneManager.GetActiveScene().name == "Level1")
           {
               PlayerPrefs.SetInt("secondLevel", 1);
               PlayerPrefs.Save();
           }

          // winMusicSource.Play();
           Time.timeScale = 0;
        }

    }

    IEnumerator play()
    {
        lifes = 3;
        PlayerPrefs.SetInt("BirdLifes", lifes);

        winWindow.transform.position = new Vector3(0, 0, -4);
        winWindow.SetActive(true);

        string ins = "" + LevelController.current.insects;
        string grn = "" + LevelController.current.grain;
       // Debug.Log(ins);
       // Debug.Log(grn);
        grainWinLabel.text = grn;
        insectWinLabel.text = ins;

        foneMusicSource.Stop();

        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            //winMusicSource.Play();
        }
        Time.timeScale = 0;
        yield return new WaitForSeconds(1.5f);
        
        

    }

    public void removeHealth()
    {
        //yield return new WaitForSeconds(0.5f);
        lifes--;
        die = true;
        if (lifes <= 0)
        {
            Debug.Log("Looooose");
            looseCollider.SetActive(true);
            foneMusicSource.Stop();
            GameObject obj = GameObject.Instantiate(this.looseWindow) as GameObject;
            obj.transform.position = new Vector3(0, 0, -4);
            PlayerPrefs.SetInt("BirdLifes", 3);
            Time.timeScale = 0;

        }
        else
        {
            PlayerPrefs.SetInt("BirdLifes", lifes);
            if (isMusicOn)
            {
                dieMusicSource.Play();
            }
            StartCoroutine(newLevel());   
        }

    }

    IEnumerator newLevel()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
       
            PlayerPrefs.Save();
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (scene.name == "Level2")
            {
                SceneManager.LoadScene("Level2");
            }
        }

    public void launchEgg()
    {
        if (Time.time - last_egg > 0.5f)
        {
            last_egg = Time.time;
            GameObject egg = GameObject.Instantiate(this.eggPrefab);
            egg.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1.3f, -4f);
        }

    }

    
}
