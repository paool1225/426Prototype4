using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 1000;
    int MinDist = 0;
    public AudioPlayer enemyDeath;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            /*
            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
            */
        }
    }

    public void destroyEnemy()
    {
        enemyDeath.playSounds("enemyDeath");
        Destroy(gameObject);
    }
}
