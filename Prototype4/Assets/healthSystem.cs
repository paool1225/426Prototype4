using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    public int healthPoints;

    private AudioSource damageTaken;

    private AudioClip bite;
    // Start is called before the first frame update
    void Start()
    {
        bite = Resources.Load<AudioClip>("Audio/SFX/bite");

        damageTaken = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageTaken.PlayOneShot(bite);
            
            if (healthPoints > 1)
            {
                healthPoints--;
            }

            else
            {
                SceneManager.LoadSceneAsync("GameLose");
            }
        }
    }
}
