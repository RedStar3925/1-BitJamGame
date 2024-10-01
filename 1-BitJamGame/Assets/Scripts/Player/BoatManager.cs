using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    public GameObject curentsentry; //just for testing script

    private Transform _currentSqrSelected;

    public void SetCurrentSqrSelected(Transform trm) => _currentSqrSelected = trm;
    public Transform GetCurrentSqrSelected() => _currentSqrSelected;
    
    


    public void RepairSentry()
    {
        //if money && hp < maxhp {tower hp = tower hp max; playermoney -= repairprice} (repair price will be set by the amount of hp restored)
        //play sound repairturet
    }
    public void RemoveSentry()
    {
        //playermoney += turetcost/2
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
    public void BuySentry(GameObject sentry)
    {
        //if playermoney > cost
        //playermoney -= cost
        GameObject t = Instantiate(sentry,_currentSqrSelected.position,Quaternion.identity,_currentSqrSelected);
        //playsound buyturet
    }
    public void UpgradeSentry()
    {
        //if playermoney > upgradecost
        //sqr.GetComponentInChildren<Sentry>()).UpdateSentry();
        //playsound upgrad
    }
}
