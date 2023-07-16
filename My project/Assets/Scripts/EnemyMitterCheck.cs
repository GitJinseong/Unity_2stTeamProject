using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMitterCheck : MonoBehaviour
{
    public static EnemyMitterCheck instance;
    public TMP_Text mitterText;
    public int mitter = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (mitter <= 0) { mitter = 444; StartCoroutine(Delay()); }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        GFunc.LoadScene("Stage_0_LoadScene");
    }

    public void Hit()
    {
        mitter--;
        mitterText.text = mitter.ToString();
    }
}
