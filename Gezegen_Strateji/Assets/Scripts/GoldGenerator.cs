using UnityEngine;
using System.Collections;
using TMPro;

public class GoldGenerator : MonoBehaviour
{
    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate; // Canvas içindeki metni güncellemek için referans
    private int currentAmount;

    void Start()
    {

        if (PlayerPrefs.HasKey("Altın Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Altın Miktarı");
        }
        else
        {
            currentAmount = 0;
        }
        textToUpdate.text = "Altın Miktarı: " + currentAmount.ToString();
    }


    private void OnMouseDown()
    {
        if (canInteract && Input.GetMouseButtonDown(0)) // Sadece sol tıklama ile etkileşime girsin
        {
            StartCoroutine(InteractWithDelay());
        }
    }

    IEnumerator InteractWithDelay()
    {
        canInteract = false;

        yield return new WaitForSeconds(5f);

        // Canvas içindeki metni güncelle
        currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 5; // Her tıklamada 5 birim artır
        textToUpdate.text = "Altın Miktarı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Altın Miktarı", currentAmount);

        canInteract = true;
    }
}