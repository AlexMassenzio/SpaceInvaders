using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerSettings settings;
    public GameObject laserPrefab;

    private Rigidbody2D rbody2d;
    private GameObject lastLaserShot;

	// Use this for initialization
	void Start () {
        rbody2d = GetComponent<Rigidbody2D>();
        lastLaserShot = null;
	}

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (lastLaserShot == null)
            {
                //Fire a laser bomb
                lastLaserShot = Instantiate(laserPrefab, transform.position, transform.rotation, null);
                lastLaserShot.GetComponent<LaserShot>().Fire(transform.up, tag, settings.bulletSpeedModifier);
            }
            else // If there is a laser currently travelling
            {
                lastLaserShot.GetComponent<LaserShot>().Detonate();
            }
        }
    }

    void FixedUpdate () {
        rbody2d.MovePosition(new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * settings.speedModifier, transform.position.y));
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("You lost!");
        }
    }

}
