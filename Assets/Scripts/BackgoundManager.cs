using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgoundManager : MonoBehaviour {

   // public List<Transform> Backgrounds;
    public Camera camera;

    public GameObject back_1;
    public GameObject back_2;

    private GameObject current;

   // private Queue<Transform> _backgrounds;


    void Start()
    {
        current = back_1;
       // _backgrounds = new Queue<Transform>(Backgrounds);
    }

    void Update()
    {
      //  if(back_1.transform.position.x)

        var bg_pos = camera.WorldToViewportPoint(current.transform.position);
//        Debug.Log(bg_pos);
       // Debug.Log(bg_pos.x);
       // Transform current_bg = _backgrounds.Peek();

        if(bg_pos.x <= -0.514f){
            changeBackground();
        }
    }

    private void changeBackground()
    {
        GameObject temp = (GameObject)Instantiate(current);
        RectTransform rt = (RectTransform)temp.transform;
        float width = rt.rect.position.x;
        Vector3 newPos = current == back_1 ? back_2.transform.position : back_1.transform.position;
        current.transform.position = new Vector3(newPos.x + 20.17f, current.transform.position.y, current.transform.position.z);
        current = current == back_1 ? back_2 : back_1;
    }



}
