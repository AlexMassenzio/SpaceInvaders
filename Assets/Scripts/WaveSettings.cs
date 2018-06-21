using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveSettings", menuName = "Wave Settings")]
public class WaveSettings : ScriptableObject {

    public float speedModifier = 1f;
    public float fireInterval = 1f;

    //Spawn settings
    public int columnAmount = 11;
    public int rowAmount = 5;
    public float horizontalOffset = 3f;
    public float verticalOffset = 3f;

    public WaveSettings(WaveSettings settingsToCopy)
    {
        speedModifier = settingsToCopy.speedModifier;
        fireInterval = settingsToCopy.fireInterval;

        columnAmount = settingsToCopy.columnAmount;
        rowAmount = settingsToCopy.rowAmount;
        horizontalOffset = settingsToCopy.horizontalOffset;
        verticalOffset = settingsToCopy.horizontalOffset;
    }
}
