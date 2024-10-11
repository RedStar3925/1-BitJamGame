using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour
{
    public GameObject curentsentry; //just for testing script
    public LogicScript playermoney;
    public Transform _currentSqrSelected;

    public int sentryCost = 10;

    public Text sentryCostText;

    public void SetCurrentSqrSelected(Transform trm) => _currentSqrSelected = trm;
    public Transform GetCurrentSqrSelected() => _currentSqrSelected;

    private void Update()
    {
        UpdateSentryCostText();
    }
    public void BuySentry()
    {
        Debug.Log("Actual Coins: " + playermoney.PlayerCoin);
        if (playermoney.PlayerCoin >= sentryCost)
        {
            if (_currentSqrSelected.childCount == 0)
            {
                Debug.Log("Buying a sentry....");
                GameObject t = Instantiate(curentsentry, _currentSqrSelected.position, Quaternion.identity, _currentSqrSelected);
                playermoney.AddRemoveGold(-sentryCost);
                sentryCost = sentryCost + sentryCost;

                AudioManager.instance.LaunchSoundSFX(AudioManager.instance.buildSentrySound);

            }
            else
            {
                Debug.Log("Already exist a sentry in this local");
            }
        }
        else
        {
            Debug.Log("Insuficient coins to buy a sentry!");
        }
    }

    private void UpdateSentryCostText()
    {
        sentryCostText.text = "Turret Cost: " + sentryCost.ToString();
    }
}
