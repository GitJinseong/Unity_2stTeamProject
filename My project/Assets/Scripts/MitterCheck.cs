using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MitterCheck : MonoBehaviour
{
    public TMP_Text mitterText;
    public int mitter = 999;
    private float delay = 0.1f; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckMitters());
    }

    private IEnumerator CheckMitters()
    {
        while (mitter > 0) 
        {
            yield return new WaitForSeconds(delay);
            mitter--;
            mitterText.text = mitter.ToString();
        }
    }
}
