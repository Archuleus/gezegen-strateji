using UnityEngine;
using System.Collections;
using TMPro;

public class BuildingInteraction : MonoBehaviour
{
    public static BuildingInteraction Instance { get; private set; }

    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI madenTxt;
    private int currentAmount;
    private int currentGold;
    private int currentMaden;

    private int beforeClickYemek;
    private int beforeClickGold;
    private int beforeClickMaden;


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
        if (PlayerPrefs.HasKey("Yemek Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Yemek Miktarı");
        }
        else
        {
            currentAmount = 0;
        }

        currentGold = PlayerPrefs.GetInt("Altın Miktarı");
        currentMaden = PlayerPrefs.GetInt("Maden Miktarı");

        textToUpdate.text = "Yemek Miktarı: " + currentAmount.ToString();
    }

    private void OnMouseDown()
    {
        if (canInteract && Input.GetMouseButtonDown(0)) // Sadece sol tıklama ile etkileşime girsin
        {
            currentGold = PlayerPrefs.GetInt("Altın Miktarı");
            currentMaden = PlayerPrefs.GetInt("Maden Miktarı");
            beforeClickGold= PlayerPrefs.GetInt("Altın Miktarı");
            beforeClickMaden= PlayerPrefs.GetInt("Maden Miktarı");
            beforeClickYemek= PlayerPrefs.GetInt("Yemek Miktarı");

            if (currentGold >= 20 && currentMaden >= 20)
            {
                StartCoroutine(InteractWithDelay());
                currentGold -= 20;
                currentMaden -= 20;

                PlayerPrefs.SetInt("Maden Miktarı", currentMaden);
                PlayerPrefs.SetInt("Altın Miktarı", currentGold);

                goldTxt.text = "Altın Miktarı: " + currentGold.ToString();
                madenTxt.text = "Maden Miktarı: " + currentMaden.ToString();
            }
        }
    }

    IEnumerator InteractWithDelay()
    {
        canInteract = false;

        yield return new WaitForSeconds(5f);

        // Canvas içindeki metni güncelle
        currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 5; // Her tıklamada 5 birim artır
        textToUpdate.text = "Yemek Miktarı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Yemek Miktarı", currentAmount);

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
}
