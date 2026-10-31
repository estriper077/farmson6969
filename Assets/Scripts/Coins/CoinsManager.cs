using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    int coins = 0;

    [SerializeField] private TMP_Text coinsCounter;
    void Start()
    {
        
    }

    private int coinsCount;
    private COIN[] allCoins;

    void Update()
    {
        allCoins = FindObjectsByType<COIN>(FindObjectsSortMode.None);
        coinsCount = allCoins.Length;
        UpdateCOINS();
    }

    public void addCoin()
    {
        coins= coins+1;
        UpdateCOINS();

    }

    public void UpdateCOINS()
    {
        coinsCounter.text = coins + "/" + coinsCount;
    }
}
