using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Drawing;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text statusText = default;
    public int PlayerLife = 3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLife == 0 ) { PlayerLife = -1; PlayerController.instance.Die_Motion(); }
    }

    public void SetPlayerDamage()
    {
        PlayerLife -= 1;
        statusText.text = "4P-004444 HI-004444 STAGE-00\r\n" +
            "<color=#ed4669>BOUNS</color>-4444 LIFE-" + GetPlayerLife();
    }

    public void SetPlayerDie()
    {
        string lifeText = "<color=#ff0000>X</color><color=#ff0000>X</color><color=#ff0000>X</color>";
        statusText.text = "4P-004444 HI-004444 STAGE-00\r\n" +
            "<color=#ed4669>BOUNS</color>-4444 LIFE-" + lifeText;
    }

    public string GetPlayerLife()
    {
        string lifeText = "";

        for (int i = 0; i < PlayerLife; i++)
        {
            lifeText = lifeText + "O";
        }

        for (int i = 0; i < 3 - PlayerLife; i++)
        {
            lifeText = lifeText + "<color=#ff0000>X</color>";

        }

        return lifeText;
    }
}
