using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private float loopWidth;

    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = transform.position.x - 0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0.97f)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width, 0f);
        transform.position = (Vector2)transform.position + offset;
        //transform.position = transform.position.AddVector(offset);
    }
}
