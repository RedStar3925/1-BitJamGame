using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int PlayerCoin;
    public Text PlayerCoinText;


    [ContextMenu("Increase Coin")]
    public void AddCoin()
    {
        PlayerCoin = PlayerCoin + 1;
        PlayerCoinText.text = PlayerCoin.ToString();
    }
}
