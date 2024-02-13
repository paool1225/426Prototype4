using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetawayCar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player interaction with the getaway car
            // For instance, display a message to press Q or Space to get in
            // Then trigger the GameWin screen when the player gets in
            SceneManager.LoadScene("GameWin"); // Load the GameWin scene
        }
    }
}
