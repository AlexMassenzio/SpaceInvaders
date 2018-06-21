using System;
using System.Collections.Generic;

/// <summary>
/// Contains information about the playcount and scoreboard of the game.
/// </summary>
[Serializable]
public class GameStats
{
    public int playCount;
    public Dictionary<string, int> scores;

    public GameStats()
    {
        playCount = 0;
        scores = new Dictionary<string, int>();
    }
}