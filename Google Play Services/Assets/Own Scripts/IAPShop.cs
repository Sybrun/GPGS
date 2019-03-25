using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPShop : MonoBehaviour
{ 
    public void Buy1000()
    {
        IAPManager.Instance.Buy1000Gold();
    }
    public void Buy3500()
    {
        IAPManager.Instance.Buy3500Gold();
    }
    public void Buy5700()
    {
        IAPManager.Instance.Buy5700Gold();
    }
    public void BuyNoAds()
    {
        IAPManager.Instance.BuyNoAds();
    }
}
