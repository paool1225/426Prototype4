using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private static float speedIncrement = 5f, accelerationIncrement = 2f;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OneBulletHit()
    {
        IncreaseSpeedForAllEnemies();
    }

    private void IncreaseSpeedForAllEnemies()
    {
        accelerationIncrement += speedIncrement;
        speedIncrement += 5;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemy)
        {
            NavMeshAgent enemyAgent = enemyObject.GetComponent<NavMeshAgent>();
            if (enemyAgent != null)
            {
                enemyAgent.speed += speedIncrement;
                enemyAgent.acceleration += accelerationIncrement;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OneBulletHit();
        }
    }
}
