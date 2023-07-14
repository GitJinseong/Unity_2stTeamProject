using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpawner : MonoBehaviour
{
    public GameObject thunderPrefab = default;
    public GameObject thunderBody = default;
    private bool isSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnThunder());
    }

    private IEnumerator SpawnThunder()
    {
        if (isSpawn == false)
        {
            isSpawn = true;

            yield return new WaitForSeconds(10f);

            GameObject thunderImg = Instantiate(thunderPrefab,
                transform.position, transform.rotation, transform);

            Destroy(thunderImg, 2f);

            yield return new WaitForSeconds(1f);

            GameObject thunderCollider = Instantiate(thunderBody,
                transform.position, transform.rotation, transform);

            Destroy(thunderCollider, 1f);

            isSpawn = false;
        }
    }
}
