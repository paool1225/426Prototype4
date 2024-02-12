using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource gun, enemyDeath, bombPickup, bombDrop;

    public AudioClip pewSound, enemyDeath1, enemyDeath2, enemyDeath3, pickupSound, dropSound;

    // Update is called once per frame
    void Update()
    {
    }

    public void PlaySounds(string trigger)
    {
        switch (trigger)
        {
            case "enemyDeath1":
                enemyDeath.PlayOneShot(enemyDeath1);
                break;
            case "enemyDeath2":
                enemyDeath.PlayOneShot(enemyDeath2);
                break;
            case "enemyDeath3":
                enemyDeath.PlayOneShot(enemyDeath3);
                break;
            case "pickup":
                bombPickup.PlayOneShot(pickupSound);
                break;
            case "drop":
                bombDrop.PlayOneShot(dropSound);
                break;
        }
    }
}
