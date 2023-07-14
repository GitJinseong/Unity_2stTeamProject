using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab = default;
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
        if (transform.position.y > 7f)
        {
            Debug.Log("Dead");
        }
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        if (isShoot == false)
        {
            isShoot = true;

            yield return new WaitForSeconds(2f);

            GameObject bullet = Instantiate(bulletPrefab, transform.position,
            transform.rotation, transform);

            yield return new WaitForSeconds(1f);

            isShoot = false;
        }   
    }
}
