using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {


    private Rigidbody2D rbody2d;

    private bool hasFired = false;
    private string friendlyTag = ""; //Tag of shooter to prevent 
    private Vector3 forceDirection;
    private float laserForce = 10;

    // Use this for initialization
    void Start () {
        rbody2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        rbody2d.AddForce(forceDirection * laserForce);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Make sure friendly fire cannot happen.
        if(collision.tag != friendlyTag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void Fire(Vector3 direction, string shooterTag, float forceModifier)
    {
        hasFired = true;
        forceDirection = direction;
        friendlyTag = shooterTag;
        laserForce = forceModifier;
    }
}
