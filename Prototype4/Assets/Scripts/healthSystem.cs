using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    public int healthPoints;
    public TMP_Text displayHealth;
    
    private UIManager health;
    private AudioSource damageTaken;
    private AudioClip bite;
    // Start is called before the first frame update
    void Start()
    {
        bite = Resources.Load<AudioClip>("Audio/SFX/bite");

        damageTaken = GetComponent<AudioSource>();

        displayHealth.text = "Health: " + healthPoints;
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
                displayHealth.text = "Health: " + healthPoints;
            }

            else
            {
                SceneManager.LoadSceneAsync("GameLose");
            }
        }
    }
}
