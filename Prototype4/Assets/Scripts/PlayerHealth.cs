using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 3;

    private AudioSource player;

    private AudioClip bite;

    void Start()
    {
        bite = Resources.Load<AudioClip>("Audio/SFX/bite");

        player = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.PlayOneShot(bite);
            if (playerHealth > 0)
            {
                playerHealth--;
            }

            else
            {
                SceneManager.LoadScene("GameLose");
            }
        }
    }
}
