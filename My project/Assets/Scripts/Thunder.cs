using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) {  return; }
        if (collision.tag.Equals("Player"))
        {
            GameManager.instance.SetPlayerDamage();
            gameObject.SetActive(false);
        }
    }
}
