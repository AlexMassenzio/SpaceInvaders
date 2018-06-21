using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerSettings", menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject {

    public int lives = 3;
    public float speedModifier = 1f;
    public float bulletSpeedModifier = 1f;

}
