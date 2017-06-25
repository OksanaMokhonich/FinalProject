using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : Collectable
{


    public override void OnBirdHit(Bird bird)
    {
        LevelController.current.addGrain();
        this.CollectedHide();

    }
}
