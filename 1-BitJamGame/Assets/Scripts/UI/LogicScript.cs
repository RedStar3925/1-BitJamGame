using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{

    public int PlayerCoin = 10;
    public Text PlayerCoinText;

    [SerializeField] GameObject _gameOverPanel;

    public static LogicScript instance;
    private void Awake()
    {
        if (instance != null)
        { 
            Debug.LogWarning("careful more than one instance of LogicScript"); 
            return; 
        }
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

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void retryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
