using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AskerGoster : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private int gold;

    void Start()
    {

        if (PlayerPrefs.HasKey("Asker Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Asker Miktarı");
            goldText.text = "Asker Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Asker Miktarı: " + gold.ToString();
        }



    }

    void Update()
    {

        if (PlayerPrefs.HasKey("Asker Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Asker Miktarı");
            goldText.text = "Asker Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Asker Miktarı: " + gold.ToString();
        }
    }



}