using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFrameController : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        //SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize()
    {
        float width = canvas.GetComponent<RectTransform>().rect.width;
        //float height = canvas.GetComponent<RectTransform>().rect.height;
        rect.sizeDelta = new Vector2(width, 200);
    }
}
