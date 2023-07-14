using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject bulletPrefab = default;
    public AudioClip deathClip;
    private float jumpForce = 200f;
    private int bulletCount = 0;
    private float bulletDelay = 0.2f;
    private bool isGrounded = false;
    public bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        instance = this;

        GFunc.Assert(playerRigid != null);
        GFunc.Assert(animator != null);
        GFunc.Assert(playerAudio != null);

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        if (transform.position.y > 5.5f) { Die_Motion(); }

        //LEGACY;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        if (Input.GetMouseButtonDown(1) && bulletCount == 0
            ||
            Input.GetMouseButton(1) && bulletCount == 0)
        {
            bulletCount += 1;
            GameObject bullet = Instantiate(bulletPrefab, transform.position,
                transform.rotation, transform);
            StartCoroutine(Shoot());
            //playerAudio.Play();
        }

        //Jump();

        animator.SetBool("Ground", isGrounded);
    }
    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(bulletDelay);
        bulletCount = 0;
    }

    public void Eat_PlayerMotion()
    {

    }

    public void Die_Motion()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        gameObject.tag = "Untagged";

        GameManager.instance.SetPlayerDie();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead") && isDead == false)
        {
            Die_Motion();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7 < collision.contacts[0].normal.y)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
