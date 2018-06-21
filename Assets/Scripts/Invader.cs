using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

    public float row = -1, col = -1;

    private EnemyWave wave;

	// Use this for initialization
	void Start () {
        wave = transform.parent.gameObject.GetComponent<EnemyWave>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            wave.TurnAroundWave();
        }
    }

    void OnDestroy()
    {
        wave.enemiesLeft--;
    }
}
