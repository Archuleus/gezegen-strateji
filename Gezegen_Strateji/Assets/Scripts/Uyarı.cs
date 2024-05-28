using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uyarı : MonoBehaviour
{
    public Text altinText;
    public Text yemekText;
    public Text madenText;
    public Text askerText;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("yemek"))
                {
                    CheckResources("yemek");
                }
                else if (hit.collider.CompareTag("maden"))
                {
                    CheckResources("maden");
                }
                else if (hit.collider.CompareTag("altin"))
                {
                    CheckResources("altin");
                }
                else if (hit.collider.CompareTag("asker"))
                {
                    CheckResources("asker");
                }
            }
        }
    }

    private void CheckResources(string obje)
    {
        if (obje == "yemek")
        {
            int currentGold = BuildingInteraction.Instance.GetBeforeClickGold();
            int currentMaden = BuildingInteraction.Instance.GetBeforeClickMaden();
            print(currentGold);
            print(currentMaden);



            if (currentGold >= 20 && currentMaden >= 20)
            {
                yemekText.text = "Yemek Toplandı";
            }
            else
            {
                yemekText.text = "Yetersiz Kaynak";
            }

            yemekText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(yemekText, 5f));
        }
        else if (obje == "maden")
        {
            madenText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(madenText, 5f));
        }
        else if (obje == "altin")
        {
            altinText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(altinText, 5f));
        }
        else if (obje == "asker")
        {
            int currentGold2 = Asker.Instance.GetBeforeClickGold();
            int currentMaden2 = Asker.Instance.GetBeforeClickMaden();
            int currentYemek2 = Asker.Instance.GetBeforeClickYemek();



            if (currentGold2 >= 20 && currentMaden2 >= 20 && currentYemek2 >= 10)
            {
                askerText.text = "Asker Üretildi";
            }
            else
            {
                askerText.text = "Yetersiz Kaynak";
            }

            askerText.gameObject.SetActive(true);
            StartCoroutine(HideTextAfterDelay(askerText, 5f));
        }
    }

    private IEnumerator HideTextAfterDelay(Text text, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (text != null)
        {
            text.gameObject.SetActive(false);
        }
    }
}
