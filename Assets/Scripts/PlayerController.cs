using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private float velocity = 5f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private float jumpSpeed = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private GameObject FurrPrefab;
    [SerializeField] private Transform FurrSpawnPoint;
    [SerializeField] private Transform FurrSpawnPoint2;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.5f, 0.44f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalIinput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new(horizontalInput, 0, 0);
        movementDirection.Normalize();
        if (horizontalInput != 0)
        {
            transform.Translate(velocity * Time.deltaTime * movementDirection);
            anim.SetBool("isRun", true);
        } else anim.SetBool("isRun", false);
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (verticalIinput > 0 && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 throwRight, throwLeft;
            if (spriteRenderer.flipX)
            {
                throwLeft = transform.right * -1;
                GameObject furr = Instantiate(FurrPrefab, FurrSpawnPoint2.position, Quaternion.identity);
                furr.GetComponent<Rigidbody2D>().velocity = throwLeft * 30f;
                Destroy(furr, 1f);
            }
            else
            {
                throwRight = transform.right;
                GameObject furr = Instantiate(FurrPrefab, FurrSpawnPoint.position, Quaternion.identity);
                furr.GetComponent<Rigidbody2D>().velocity = throwRight * 30f;
                Destroy(furr, 1f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }        
    }
}
