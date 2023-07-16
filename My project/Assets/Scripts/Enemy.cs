using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public GameObject targetBulletPrefab = default;
    private bool isShoot = false;
    //Transform transform = default;
    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5.5f)
        {
            Dead();
        }
        StartCoroutine(Shoot());
    }

    public void Dead()
    {
        GFunc.LoadScene("Stage_0_LoadScene");
    }

    private IEnumerator Shoot()
    {
        if (isShoot == false)
        {
            isShoot = true;

            yield return new WaitForSeconds(2f);

            if (Random.Range(1,10) >= 1)
            {
                GameObject PlayerObject = GameObject.Find("Player");
                Vector2 targetPos = new Vector2(PlayerObject.transform.position.x + 30f, PlayerObject.transform.position.y);
                GameObject targetBullet = Instantiate(targetBulletPrefab, targetPos,
                transform.rotation, transform);
                yield return new WaitForSeconds(2f);
            }
            GameObject bullet = Instantiate(bulletPrefab, transform.position,
            transform.rotation, transform);

            yield return new WaitForSeconds(1f);

            isShoot = false;
        }   
    }
}
