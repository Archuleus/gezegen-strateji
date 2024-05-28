using UnityEngine;

public class Ana_Gezgen : MonoBehaviour
{
    void OnMouseDown()
    {
        // Sahne ismi ya da sahne index numarası
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}