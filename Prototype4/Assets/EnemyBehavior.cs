using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float currentSpeed;
    private float currentAcceleration;
    private bool needsToUpdate = false;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void BombDelivered(string stat, float speed, float acceleration)
    {
        currentSpeed = speed;
        currentAcceleration = acceleration;
        switch (stat)
        {
            case "increase":
                currentSpeed += 1.5f;
                currentAcceleration *= 1.5f;
                IncreaseSpeedForAllEnemies();
                break;
            /*
            case "decrease":
                speedIncrement -= 1.5f;
                accelerationIncrement -= 1.5f;
                IncreaseSpeedForAllEnemies();
                break;
            */
            default:
                return;
        }
    }

    private void IncreaseSpeedForAllEnemies()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemy)
        {
            NavMeshAgent enemyAgent = enemyObject.GetComponent<NavMeshAgent>();
            if (enemyAgent != null)
            {
                enemyAgent.speed = currentSpeed;
                enemyAgent.acceleration = currentAcceleration;
            }
        }
    }
}
