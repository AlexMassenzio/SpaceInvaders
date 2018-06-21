using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCollector : MonoBehaviour {

    private StatManager statManager;
    private GameStats stats;

	// Use this for initialization
	void Start () {
        statManager = GetComponent<StatManager>();
        stats = statManager.Load();
        stats.playCount++;
        statManager.Save(stats);
	}

    // Create a function for storing a score with a name. Ran out of time
}
