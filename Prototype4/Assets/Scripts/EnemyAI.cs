using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    //public Transform Player;
    public AudioPlayer enemyDeath;
    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;
    //private EnemyBehavior speedBehavior;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = 5f;
        agent.acceleration = 5f;
    }
    
    // Update is called once per frame
    void Update()
    {
        agent.speed = FindObjectOfType<PlayerController>().enemySpeed;
        agent.acceleration = FindObjectOfType<PlayerController>().enemyAcceleration;
        agent.SetDestination(target.transform.position);
        Vector3 vector = target.transform.position - this.transform.position;
        Quaternion targetRot = Quaternion.LookRotation(forward: Vector3.forward, upwards: Quaternion.Euler(0,0,90)*vector);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyEnemy();
        }
        
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyEnemy()
    {
        int randomDeathNoise = Random.Range(0, 9) % 3;
        switch (randomDeathNoise)
        {
            case 0:
                enemyDeath.PlaySounds("enemyDeath1");
                break;
            case 1:
                enemyDeath.PlaySounds("enemyDeath2");
                break;
            case 2:
                enemyDeath.PlaySounds("enemyDeath3");
                break;
        }
        Destroy(gameObject);
    }
}
