using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rigid = default;
    public float speed = 20f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;
        animator = GetComponent<Animator>();

        Destroy(gameObject, 3f);
    }

    public IEnumerator Hit()
    {
        animator.SetTrigger("Hit");
        rigid.velocity = Vector2.zero;
        EnemyMitterCheck.instance.Hit();
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            StartCoroutine(Hit());
            Debug.Log("몬스터 피격");
        }
    }
}
