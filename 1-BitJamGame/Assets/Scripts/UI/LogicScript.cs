using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public int PlayerCoin;
    public Text PlayerCoinText;

    public static LogicScript instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one instance of LogicScript"); return; }
        instance = this;
    }
    [ContextMenu("Increase Coin")]


    public void AddRemoveGold(int goldGainLose)
    {
        PlayerCoin += goldGainLose;
        ActualisationUI();
    }

    public void ActualisationUI()
    {
        PlayerCoinText.text = "GOLD   " + PlayerCoin.ToString();
    }
}
