using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    public LayerMask objectLayer;
    private GameObject carriedObject;
    private bool isCarryingObject = false;
    private bool canDropOutsideZone = false;
    public bool droppedInDropOffZone = false;

    public float enemySpeed = 5f;
    public float enemyAcceleration = 5f;

    private AudioSource gun;
    private AudioClip bang;
    private AudioClip jam;

    private Vector2 mousePosition;
    private Vector2 moveDirection;

    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        bang = Resources.Load<AudioClip>("Audio/SFX/gun sound");
        jam = Resources.Load<AudioClip>("Audio/SFX/error");

        gun = GetComponent<AudioSource>();
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
                PickUpBomb();
            }
            else
            {
                if (droppedInDropOffZone)
                {
                    PutDownBomb();
                }
                else if (canDropOutsideZone)
                {
                    PutDownBomb();
                }
                else
                {
                    Debug.Log("Bomb part must be set down in the DropOffZone.");
                }
            }
        }
    }

    private void PickUpBomb()
    {
        Vector2 direction = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, objectLayer);
        if (hit.collider != null)
        {
            carriedObject = hit.collider.gameObject;
            carriedObject.SetActive(false);
            uiManager.SetHoldingPart(true);
            isCarryingObject = true;
            canDropOutsideZone = true;
        }
    }

    private void PutDownBomb()
    {
        carriedObject.transform.position = transform.position + transform.right;
        carriedObject.SetActive(true);
        carriedObject = null;
        uiManager.SetHoldingPart(false);
        if (droppedInDropOffZone)
        {
            uiManager.DecreasePartsLeft();
            uiManager.IncreasePartsCollected();
            //FindObjectOfType<EnemyBehavior>().BombDelivered("increase", enemySpeed, enemyAcceleration);
            enemySpeed += 1.5f;
            enemyAcceleration *= 1.5f;
            droppedInDropOffZone = false; // Reset to disallow further dropping in drop-off zone
        }
        isCarryingObject = false;
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
