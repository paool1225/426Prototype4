using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Destroy(gameObject);
    }
}
