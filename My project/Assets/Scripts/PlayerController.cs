using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    private float jumpForce = 300f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        GFunc.Assert(playerRigid != null);
        GFunc.Assert(animator != null);
        GFunc.Assert(playerAudio != null);

        //GameManager.instance.LinkPlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        //LEGACY;
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        //Jump();

        animator.SetBool("Ground", isGrounded);
    }

    public void Jump()
    {

        if (jumpCount < 2)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        //GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead") && isDead == false)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7 < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
