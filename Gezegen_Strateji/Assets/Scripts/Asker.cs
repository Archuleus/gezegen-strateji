using UnityEngine;
using System.Collections;
using TMPro;

public class Asker : MonoBehaviour
{
    public static Asker Instance { get; private set; } // Singleton instance

    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate; // Canvas içindeki metni güncellemek için referans
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI madenTxt;
    public TextMeshProUGUI yemekTxt;
    private int currentAmount;
    private int currentGold;
    private int currentYemek;
    private int currentMaden;
    private int beforeClickGold;
    private int beforeClickMaden;
    private int beforeClickYemek;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Asker Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Asker Miktarı");
        }
        else
        {
            currentAmount = 0;
        }

        currentGold = PlayerPrefs.GetInt("Altın Miktarı");
        currentMaden = PlayerPrefs.GetInt("Maden Miktarı");
        currentYemek = PlayerPrefs.GetInt("Yemek Miktarı");

        textToUpdate.text = "Asker Miktarı: " + currentAmount.ToString();
    }

    private void OnMouseDown()
    {
        if (canInteract && Input.GetMouseButtonDown(0)) // Sadece sol tıklama ile etkileşime girsin
        {
            currentGold = PlayerPrefs.GetInt("Altın Miktarı");
            currentMaden = PlayerPrefs.GetInt("Maden Miktarı");
            currentYemek = PlayerPrefs.GetInt("Yemek Miktarı");
            beforeClickGold = currentGold;
            beforeClickMaden = currentMaden;
            beforeClickYemek = currentYemek;

            if (currentGold >= 20 && currentMaden >= 20 && currentYemek >= 10)
            {
                StartCoroutine(InteractWithDelay());
                currentGold -= 20;
                currentMaden -= 20;
                currentYemek -= 10;

                PlayerPrefs.SetInt("Maden Miktarı", currentMaden);
                PlayerPrefs.SetInt("Altın Miktarı", currentGold);
                PlayerPrefs.SetInt("Yemek Miktarı", currentYemek);

                goldTxt.text = "Altın Miktarı: " + currentGold.ToString();
                madenTxt.text = "Maden Miktarı: " + currentMaden.ToString();
                yemekTxt.text = "Yemek Miktarı: " + currentYemek.ToString();
            }
        }
    }

    IEnumerator InteractWithDelay()
    {
        canInteract = false;

        yield return new WaitForSeconds(5f);

        // Canvas içindeki metni güncelle
        int currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 5; // Her tıklamada 5 birim artır
        textToUpdate.text = "Asker Miktarı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Asker Miktarı", currentAmount);
        canInteract = true;
    }

    public int GetBeforeClickGold()
    {
        return beforeClickGold;
    }

    public int GetBeforeClickMaden()
    {
        return beforeClickMaden;
    }

    public int GetBeforeClickYemek()
    {
        return beforeClickYemek;
    }
}
