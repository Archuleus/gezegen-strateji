using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldGoster : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private int gold;

    void Start()
    {

        if (PlayerPrefs.HasKey("Altın Miktarı"))
        {
            gold = PlayerPrefs.GetInt("Altın Miktarı");
        }
        else
        {
            gold = 0;
        }

        goldText.text = "Altın Miktarı: " + gold.ToString();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        goldText.text = "Altın Miktarı: " + gold.ToString();
        PlayerPrefs.SetInt("Altın Miktarı", gold);
        PlayerPrefs.Save();
    }

    public void SetGold(int amount)
    {
        gold = amount;
        goldText.text = "Altın Miktarı: " + gold.ToString();
        PlayerPrefs.SetInt("Altın Miktarı", gold);
        PlayerPrefs.Save();
    }
}