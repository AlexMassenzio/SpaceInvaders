using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExplosion : MonoBehaviour {

    private const int EXPLOSION_DURATION = 3; // In frames
    private int lifeDuration;

	// Use this for initialization
	void Start () {
        lifeDuration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(lifeDuration >= EXPLOSION_DURATION)
        {
            Destroy(gameObject);
        }

        lifeDuration++;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
