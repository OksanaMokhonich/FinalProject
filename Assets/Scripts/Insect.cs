using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : Collectable
{


    public override void OnBirdHit(Bird bird)
    {
        LevelController.current.addInsect();
        this.CollectedHide();

    }
}