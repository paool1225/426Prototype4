using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public EnemyAI enemy;
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            enemy.destroyEnemy();
        }
        
        Destroy(gameObject);
    }
}
