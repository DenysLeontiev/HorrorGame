using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataToSave
{
    public int health;
    public float[] playerPosition;
    public int bossHealth;
    public float[] bossPos;

    public PlayerDataToSave(PlayerHealth player)
    {
        health = player.playerHealth;

        playerPosition = new float[3];
        playerPosition[0] = player.GetComponentInParent<Transform>().position.x;
        playerPosition[1] = player.GetComponentInParent<Transform>().position.y;
        playerPosition[2] = player.GetComponentInParent<Transform>().position.z;


        bossHealth = GameObject.FindWithTag("Boss").transform.GetComponent<BossHealth>().bossHealth;

        bossPos = new float[3];
        bossPos[0] = GameObject.FindWithTag("Boss").transform.GetComponent<Transform>().position.x;
        bossPos[1] = GameObject.FindWithTag("Boss").transform.GetComponent<Transform>().position.y;
        bossPos[2] = GameObject.FindWithTag("Boss").transform.GetComponent<Transform>().position.z;
    }
}
