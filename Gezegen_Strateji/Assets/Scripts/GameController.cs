using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _goldAmount;
    public int GoldAmount
    {
        get => _goldAmount;
        set
        {
            _goldAmount = value;
            OnGoldAmountChanged.Invoke(_goldAmount);
        }
    }

    public UnityEvent<int> OnGoldAmountChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            OnGoldAmountChanged = new UnityEvent<int>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
