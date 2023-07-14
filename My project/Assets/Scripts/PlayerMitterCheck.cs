using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMitterCheck : MonoBehaviour
{
    public TMP_Text mitterText;
    public int mitter = 999;
    private float delay = 0.1f; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckMitters());
    }

    private void Update()
    {
        if (PlayerController.instance.isDead) { mitterText.text = "444"; }
    }
    private IEnumerator CheckMitters()
    {
        while (mitter > 0) 
        {
            yield return new WaitForSeconds(delay);
            mitter--;
            if (PlayerController.instance.isDead) { continue; }
            mitterText.text = mitter.ToString();
        }
    }
}
