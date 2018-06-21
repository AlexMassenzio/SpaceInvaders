using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public WaveSettings settings;

    public GameObject[] enemyTemplates; 

    // Enemies are stored in a grid based on location
    private GameObject[,] enemies;

	// Use this for initialization
	void Start ()
    {
        if (enemyTemplates != null && enemyTemplates.Length > 0)
        {
            // Spawn all enemies
            enemies = new GameObject[settings.columnAmount, settings.rowAmount];

            for (int i = 0; i < settings.columnAmount; i++)
            {
                for (int j = 0; j < settings.rowAmount; j++)
                {
                    int chosenTemplate = (int)Mathf.Min((j + 1f) / settings.rowAmount * enemyTemplates.Length, enemyTemplates.Length - 1); // Picks a template based on the row.
                    enemies[i, j] = Instantiate(enemyTemplates[chosenTemplate], new Vector3(i * settings.horizontalOffset, -1f * j * settings.verticalOffset, 0f), Quaternion.identity, transform); // Spawn in each enemy type depending on row.
                }
            }

            // Start movement coroutine
        }
        else
        {
            Debug.Log("Could not spawn enemies. Make sure there is at least one enemy template defined.");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
