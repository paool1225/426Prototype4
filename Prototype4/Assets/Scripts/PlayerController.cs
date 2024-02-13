using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    public LayerMask objectLayer;
    private GameObject carriedObject;
    private bool isCarryingObject = false;
    private bool canDropOutsideZone = false; // New flag to allow dropping outside the zone
    private Vector3 originalPosition;
    private bool droppedInDropOffZone = false;

    private AudioSource gun;
    private AudioSource bomb;
    private AudioClip bang;
    private AudioClip jam;
    private AudioClip bombPickup;
    private AudioClip bombDrop;

    private Vector2 mousePosition;
    private Vector2 moveDirection;

    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        bang = Resources.Load<AudioClip>("Audio/SFX/gun sound");
        jam = Resources.Load<AudioClip>("Audio/SFX/error");
        bombPickup = Resources.Load<AudioClip>("Audio/SFX/bombPickup");
        bombDrop = Resources.Load<AudioClip>("Audio/SFX/bombDropoff");

        gun = GetComponent<AudioSource>();
        bomb = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCarryingObject)
            {
                gun.PlayOneShot(bang);
                weapon.Fire();
            }
            else
            {
                gun.PlayOneShot(jam);
            }
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!isCarryingObject)
            {
                Vector2 direction = transform.right;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, objectLayer);
                if (hit.collider != null)
                {
                    bomb.PlayOneShot(bombPickup);
                    carriedObject = hit.collider.gameObject;
                    originalPosition = carriedObject.transform.position;
                    carriedObject.SetActive(false);

                    uiManager.SetHoldingPart(true);
                    isCarryingObject = true;
                    canDropOutsideZone = true; // Allow dropping outside the zone
                }
            }
            else
            {
<<<<<<< HEAD
                if (droppedInDropOffZone || canDropOutsideZone)
                {
                    carriedObject.transform.position = transform.position + transform.right;
                    carriedObject.SetActive(true);
                    carriedObject = null;

                    uiManager.SetHoldingPart(false);
                    if (droppedInDropOffZone)
                    {
                        uiManager.DecreasePartsLeft();
                        uiManager.IncreasePartsCollected();
                    }
                    isCarryingObject = false;
                }
                else
                {
                    Debug.Log("Bomb part must be set down in the DropOffZone or you can drop it outside the zone");
                }
=======
                bomb.PlayOneShot(bombDrop);
                carriedObject.transform.position = transform.position + transform.right; // Set down the bomb in front of the player
                carriedObject.SetActive(true); // Activate the bomb object
                carriedObject = null;
                
                uiManager.SetHoldingPart(false);
                uiManager.DecreasePartsLeft();
                uiManager.IncreasePartsCollected();
                isCarryingObject = false;
>>>>>>> 0a37b1a15eda9ff1ea4fa500fd0f9381908601a5
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropOffZone"))
        {
            droppedInDropOffZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropOffZone"))
        {
            droppedInDropOffZone = false;
        }
    }
}