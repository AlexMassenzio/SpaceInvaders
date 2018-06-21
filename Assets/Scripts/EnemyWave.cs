using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public int enemiesLeft;
    public WaveSettings settings;
    public GameObject[] enemyTemplates; 

    // Enemies are stored in a grid based on location
    private GameObject[,] enemies;
    private bool turnAround; //Flag for when to turn around

	// Use this for initialization
	void Start ()
    {
        turnAround = false;

        settings = new WaveSettings(settings); // Create a copy to ensure we don't overwrite the scriptable object
        if (enemyTemplates != null && enemyTemplates.Length > 0)
        {
            // Spawn all enemies
            enemies = new GameObject[settings.columnAmount, settings.rowAmount];

            for (int i = 0; i < settings.columnAmount; i++)
            {
                for (int j = 0; j < settings.rowAmount; j++)
                {
                    int chosenTemplate = (int)Mathf.Min((j + 1f) / settings.rowAmount * enemyTemplates.Length, enemyTemplates.Length - 1); // Picks a template based on the row.
                    enemies[i, j] = Instantiate(enemyTemplates[chosenTemplate], new Vector3(transform.position.x + i * settings.horizontalOffset, transform.position.y + j * settings.verticalOffset, 0f), Quaternion.identity, transform); // Spawn in each enemy type depending on row.
                    enemiesLeft++;

                    // Assign location to each enemy
                    enemies[i, j].GetComponent<Invader>().col = i;
                    enemies[i, j].GetComponent<Invader>().row = j;
                }
            }

            // Start firing coroutine
            StartCoroutine(FireLoop());
        }
        else
        {
            Debug.Log("Could not spawn enemies. Make sure there is at least one enemy template defined.");
        }
	}

    void Update()
    {
        if(enemiesLeft == 0)
        {
            FindObjectOfType<MainMenu>().GetComponent<Canvas>().enabled = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.position = new Vector2(transform.position.x + settings.speedModifier / 10f, transform.position.y);

        // Turn around here in case TurnAroundWave() was called multiple times in a given physics step.
        if(turnAround)
        {
            turnAround = false;
            settings.speedModifier *= -1;
            transform.position = new Vector2(transform.position.x + settings.speedModifier, transform.position.y - settings.verticalOffset);
        }
    }

    /// <summary>
    /// Shifts the wave downwards and torwards the other direction
    /// </summary>
    public void TurnAroundWave()
    {
        turnAround = true;
    }

    IEnumerator FireLoop()
    {
        while(true)
        {
            //Get a random column, then have the closest invader fire a laser downwards. Ran out of time.
            yield return new WaitForSeconds(settings.fireInterval);
        }
    }
}
