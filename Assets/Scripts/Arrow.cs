using UnityEngine;
using System.Collections;

public class Arrow : Collectable {

	public Vector3 v = new Vector3(0, 0, 0);
	public Vector3 a = new Vector3(0, 0, 0);
    public bool right = false;

	void Start () {
		Destroy(this.gameObject, 1.2f);
        if (!right)
            v.x = -v.x;
	}

	void Update () {

        
		transform.position += v*Time.deltaTime;
		v += a * Time.deltaTime;//поворот стріли
        
       transform.rotation = Quaternion.LookRotation(v, new Vector3(0,0,25));
	}

    public override void OnBirdHit(Bird bird)
    {
        bird.removeHealth();
        this.CollectedHide();

    }

    public void setRight(bool temp)
    {
        right = temp;
    }
}
