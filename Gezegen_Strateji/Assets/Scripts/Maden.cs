using UnityEngine;
using System.Collections;
using TMPro;

public class Maden : MonoBehaviour
{
    private bool canInteract = true;
    public TextMeshProUGUI textToUpdate; // Canvas içindeki metni güncellemek için referans
    private int currentAmount;


    void Start()
    {

        if (PlayerPrefs.HasKey("Maden Miktarı"))
        {
            currentAmount = PlayerPrefs.GetInt("Maden Miktarı");
        }
        else
        {
            currentAmount = 0;
        }
        textToUpdate.text = "Maden Miktarı: " + currentAmount.ToString();
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
        int currentAmount = int.Parse(textToUpdate.text.Split(':')[1].Trim()); // Mevcut miktarı al
        currentAmount += 7; // Her tıklamada 7 birim artır
        textToUpdate.text = "Maden Miktarı: " + currentAmount.ToString(); // Metni güncelle
        PlayerPrefs.SetInt("Maden Miktarı", currentAmount);

        canInteract = true;
    }
}