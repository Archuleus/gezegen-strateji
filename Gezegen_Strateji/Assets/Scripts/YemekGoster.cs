using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YemekGoster : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private int gold;

    void Start()
    {

        if (PlayerPrefs.HasKey("Yemek Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Yemek Miktarı");
            goldText.text = "Yemek Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Yemek Miktarı: " + gold.ToString();
        }



    }

    void Update()
    {

        if (PlayerPrefs.HasKey("Yemek Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Yemek Miktarı");
            goldText.text = "Yemek Miktarı: " + gold.ToString();

        }

        else
        {
            gold = 0; goldText.text = "Yemek Miktarı: " + gold.ToString();
        }
    }



}