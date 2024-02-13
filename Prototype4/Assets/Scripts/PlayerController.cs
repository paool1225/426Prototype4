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
    private Vector3 originalPosition;
    
    private AudioSource gun;
    private AudioSource bomb;
    private AudioClip bang;
    private AudioClip jam;
    private AudioClip bombPickup;
    private AudioClip bombDrop;

    private Vector2 mousePosition;
    private Vector2 moveDirection;

    UIManager uiManager;

    // Update is called once per frame

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
                Vector2 direction = transform.right; // Assuming the player's forward direction is facing right
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, objectLayer);
                if (hit.collider != null)
                {
                    bomb.PlayOneShot(bombPickup);
                    carriedObject = hit.collider.gameObject;
                    originalPosition = carriedObject.transform.position;
                    carriedObject.SetActive(false); // Deactivate the bomb object
                   
                    uiManager.SetHoldingPart(true);
                    isCarryingObject = true;
                }
            }
            else
            {
                bomb.PlayOneShot(bombDrop);
                carriedObject.transform.position = transform.position + transform.right; // Set down the bomb in front of the player
                carriedObject.SetActive(true); // Activate the bomb object
                carriedObject = null;
                
                uiManager.SetHoldingPart(false);
                uiManager.DecreasePartsLeft();
                uiManager.IncreasePartsCollected();
                isCarryingObject = false;
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
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}