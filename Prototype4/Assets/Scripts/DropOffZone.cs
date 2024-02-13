using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffZone : MonoBehaviour
{
    public UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BombPart"))
        {
            uiManager.IncreasePartsInZone(); // Increment the count of bomb parts in the zone
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BombPart"))
        {
            uiManager.DecreasePartsInZone(); // Decrement the count of bomb parts in the zone
        }
    }
}
