﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    public int Health;
    public float[] position;

    public PlayerData(PlayerStats player)
    {
        Health = player.Health;
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
