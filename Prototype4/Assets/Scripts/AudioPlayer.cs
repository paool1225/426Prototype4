using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource source;

    public AudioClip pewSound, enemyDeath;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(pewSound);
        }
    }

    public void playSounds(string trigger)
    {
        switch (trigger)
        {
            case "enemyDeath":
                source.PlayOneShot(enemyDeath);
                break;
        }
    }
}
