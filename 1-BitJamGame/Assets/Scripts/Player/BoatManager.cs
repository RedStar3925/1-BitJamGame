using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    public GameObject curentsentry; //just for testing script
    public LogicScript playermoney;
    public Transform _currentSqrSelected;

    public int sentryCost = 10;

    public void SetCurrentSqrSelected(Transform trm) => _currentSqrSelected = trm;
    public Transform GetCurrentSqrSelected() => _currentSqrSelected;
    

    public void RemoveSentry()
    {
        playermoney.AddRemoveGold(sentryCost / 2);

        foreach (Transform obj in _currentSqrSelected)
        {
            Destroy(obj.gameObject);
        }
        
        //play sound refound turret
        
    }
    public void TestBuySentry()
    {
        
        GameObject t = Instantiate(curentsentry,_currentSqrSelected.position,Quaternion.identity,_currentSqrSelected);
    }
    public void BuySentry()
    {
        // Verificar se o jogador tem moedas suficientes
        Debug.Log("Actual Coins: " + playermoney.PlayerCoin);
        if (playermoney.PlayerCoin >= sentryCost)
        {
            // Verificar se a posição atual não tem uma sentry
            if (_currentSqrSelected.childCount == 0)
            {
                Debug.Log("Buying a sentry....");
                // Instanciar a sentry e descontar o custo
                GameObject t = Instantiate(curentsentry, _currentSqrSelected.position, Quaternion.identity, _currentSqrSelected);
                playermoney.AddRemoveGold(-sentryCost); // Descontar moedas
                sentryCost = sentryCost + sentryCost;

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
    public void UpgradeSentry()
    {
        //if playermoney > upgradecost
        //sqr.GetComponentInChildren<Sentry>()).UpdateSentry();
        //playsound upgrad
    }
}
