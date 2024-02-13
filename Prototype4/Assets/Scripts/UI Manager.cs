using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text partsCollectedText;
    public TMP_Text partsLeftText;
    public TMP_Text holdingPartText;

    private int partsCollected = 0;
    private int partsLeft = 4;
    private bool isHoldingPart = false;
    private int partsInZone = 0;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Update the UI based on game logic
        UpdateUI();
    }

    void UpdateUI()
    {
        partsCollectedText.text = "Parts collected: " + partsCollected + "/4";
        partsLeftText.text = "Parts left: " + partsLeft + "/4";
        holdingPartText.text = "Holding part: " + (isHoldingPart ? "Yes" : "No");
    }

    // Call this method when a bomb part is collected
    public void IncreasePartsCollected()
    {
        partsCollected++;
        UpdateUI();
    }

    // Call this method when a bomb part is dropped off
    public void DecreasePartsLeft()
    {
        if (partsLeft > 0)
        {
            partsLeft--;
            UpdateUI();
        }
    }

    // Call this method when the player picks up or drops a bomb part
    public void SetHoldingPart(bool holding)
    {
        isHoldingPart = holding;
        UpdateUI();
    }

    // Call this method when a bomb part enters the drop-off zone
    public void IncreasePartsInZone()
    {
        partsInZone++;
        UpdateUI();
        CheckDropOff();
    }

    // Call this method when a bomb part exits the drop-off zone
    public void DecreasePartsInZone()
    {
        if (partsInZone > 0)
        {
            partsInZone--;
            UpdateUI();
        }
    }

    // Check if all parts are in the drop-off zone
    void CheckDropOff()
    {
        if (partsInZone == 4)
        {
            DecreasePartsLeft();
            partsInZone = 0;
        }
    }

    // Handle entering the drop-off zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropOffZone"))
        {
            IncreasePartsInZone();
        }
    }

    // Handle exiting the drop-off zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DropOffZone"))
        {
            DecreasePartsInZone();
        }
    }
}
