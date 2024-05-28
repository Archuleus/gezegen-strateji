using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MadenGoster : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private int gold;

    void Start()
    {

        if (PlayerPrefs.HasKey("Maden Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Maden Miktarı");
            goldText.text = "Maden Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Maden Miktarı: " + gold.ToString();
        }



    }

    void Update()
    {

        if (PlayerPrefs.HasKey("Maden Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Maden Miktarı");
            goldText.text = "Maden Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Maden Miktarı: " + gold.ToString();
        }
    }



}