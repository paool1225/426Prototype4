using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    
    public GameObject explosionPrefab;
    public GameObject bomber;

    void Start()
    {
        Invoke("TriggerExplosion", 1.1f);
    }

    void TriggerExplosion()
    {
        // Instantiate the explosion prefab
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Play the explosion sound effect
        explosion.GetComponent<AudioSource>().Play();

        // Destroy the explosion effect after the sound has finished playing
        Destroy(explosion, explosion.GetComponent<AudioSource>().clip.length);

        // Destroy the bomb GameObject
        Destroy(bomber);
    }
}
