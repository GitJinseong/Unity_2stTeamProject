using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 4f)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                GFunc.LoadScene("Stage_0_LoadScene");
            }
        }
    }
}
