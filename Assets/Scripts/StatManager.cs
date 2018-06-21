using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private string saveDataPath;

    // Use this for initialization
    void Start()
    {
        saveDataPath = Application.persistentDataPath + "/save.dat";

        if (!File.Exists(saveDataPath))
        {
            Debug.Log("Failed to locate save file. Creating a fresh save now...");
            GameStats newSave = new GameStats();
            Save(newSave);
        }
    }

    public void Save(GameStats statsToSave)
    {
        Debug.Log("Saving data...");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(saveDataPath, FileMode.OpenOrCreate);

        // Writing the GameStats class to a local file.
        bf.Serialize(file, statsToSave);
        file.Close();

        Debug.Log("Save complete!");
    }

    public GameStats Load()
    {
        Debug.Log("Loading data...");
        if (File.Exists(saveDataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(saveDataPath, FileMode.Open);

            GameStats stats = (GameStats)bf.Deserialize(file);

            file.Close();
            Debug.Log("Successfully Loaded!");
            return stats;
        }

        Debug.Log("Failed to find save file.");
        return null;
    }
}