using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    public virtual void OnBirdHit(Bird bird)
    {
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        Bird bird = collider.GetComponent<Bird>();
        if (bird != null)
        {
            this.OnBirdHit(bird);
        }

    }
    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }
}
