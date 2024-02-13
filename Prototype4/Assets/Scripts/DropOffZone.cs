using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffZone : MonoBehaviour
{
    public UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BombPart"))
        {
            uiManager.IncreasePartsInZone(); // Increment the count of bomb parts in the zone
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BombPart"))
        {
            uiManager.DecreasePartsInZone(); // Decrement the count of bomb parts in the zone
        }
    }
}
