using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

    public float laserSpeed = 10;
    private Rigidbody2D rbody2d;

    // Use this for initialization
    void Start () {
        rbody2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        rbody2d.AddForce(transform.up * laserSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }

}
