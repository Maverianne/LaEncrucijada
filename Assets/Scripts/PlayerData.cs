using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int money;
    public int sleep;
    public int strength;
    public int reputation;

    public PlayerData(GameManager player)
    {
        money = player.money;
        sleep = player.currentSleep;
        strength = player.currentStrenght;
        reputation = player.currentReputation;
    }
}
