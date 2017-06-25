using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour
{

    //Стандартна функція, яка викличеться,
    //коли поточний об’єкт зіштовхнеться із іншим
    void OnTriggerEnter2D(Collider2D collider)
    {
        Bird bird = collider.GetComponent<Bird>();

        if (bird != null)
        {
            bird.removeHealth();
        }
    }

    
}
