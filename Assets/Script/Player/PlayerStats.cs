﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{
    public int Health = 100;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Health = data.Health;
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];

        transform.position = position;
    }
}
