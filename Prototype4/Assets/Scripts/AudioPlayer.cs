using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource gun, enemyDeath;

    public AudioClip pewSound, enemyDeath1, enemyDeath2, enemyDeath3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gun.PlayOneShot(pewSound);
        }
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
        }
    }
}
