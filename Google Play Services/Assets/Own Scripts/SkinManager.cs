using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    GoldManager Script_GoldManager;
    SaveProgress Script_SaveProgress;

    private int cost_Green = 500;
    private int cost_Crimson = 1500;
    private int cost_Cyan = 4500;
    private int cost_Violet = 10000;
    private int cost_Gold = 25000;

    public Text counter;

    [Header("Cost Panels")]
    public GameObject Panel_Cost_Green;
    public GameObject Panel_Cost_Crimson;
    public GameObject Panel_Cost_Cyan;
    public GameObject Panel_Cost_Violet;
    public GameObject Panel_Cost_Gold;

    [Header("Equipped Panels")]
    public GameObject Panel_Equipped_White;
    public GameObject Panel_Equipped_Green;
    public GameObject Panel_Equipped_Crimson;
    public GameObject Panel_Equipped_Cyan;
    public GameObject Panel_Equipped_Violet;
    public GameObject Panel_Equipped_Gold;

    [Header("Skins")]
    public Color Color_White;
    public Color Color_Green;
    public Color Color_Crimson;
    public Color Color_Cyan;
    public Color Color_Violet;
    public Color Color_Gold;

    /// <summary>
    /// Reference to the "GoldManager" and "SaveProgress" scripts to get access to the necessary variables/functions.
    /// </summary>
    void Start()
    {
        Script_GoldManager = GetComponent<GoldManager>();
        Script_SaveProgress = GetComponent<SaveProgress>();
    }

    /// <summary>
    /// When this function is called, the "White" skin will be applied to the Score Counter. Also, the appropriate panel will be showcased to the player
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void EquipSkin_White()
    {
        counter.color = Color_White;

        Panel_Equipped_White.SetActive(true);
        Panel_Equipped_Green.SetActive(false);
        Panel_Equipped_Crimson.SetActive(false);
        Panel_Equipped_Cyan.SetActive(false);
        Panel_Equipped_Violet.SetActive(false);
        Panel_Equipped_Gold.SetActive(false);
    }

    /// <summary>
    /// When this function is called, we check if the player has enough Gold to purchase the skin and if he hasn't already bought this skin.
    /// If both criteria are met by the player, we let the player purchase this skin, which will result in removing the cost of the skin from the player's Gold count,
    /// deactivation of the cost panel GameObject and saving the player's purchase so that the player doesn't have to buy the skin again after restarting the game.
    /// If the player already purchased the skin before calling this function, the skin will only be equipped. Also, the appropriate panel will be showcased to the player 
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void PurchaseSkin_Green()
    {
        if(Script_GoldManager.gold >= cost_Green && Script_SaveProgress.unlocked_Green != "true")
        {
            Script_GoldManager.removeGold(cost_Green);
            Panel_Cost_Green.SetActive(false);

            Script_SaveProgress.unlocked_Green = "true";
            PlayerPrefs.SetString("Unlocked_Green", Script_SaveProgress.unlocked_Green);
        }

        if(Script_SaveProgress.unlocked_Green == "true")
        {
            EquipSkin_Green();
        }
    }
    private void EquipSkin_Green()
    {
        counter.color = Color_Green;

        Panel_Equipped_White.SetActive(false);
        Panel_Equipped_Green.SetActive(true);
        Panel_Equipped_Crimson.SetActive(false);
        Panel_Equipped_Cyan.SetActive(false);
        Panel_Equipped_Violet.SetActive(false);
        Panel_Equipped_Gold.SetActive(false);
    }

    /// <summary>
    /// When this function is called, we check if the player has enough Gold to purchase the skin and if he hasn't already bought this skin.
    /// If both criteria are met by the player, we let the player purchase this skin, which will result in removing the cost of the skin from the player's Gold count,
    /// deactivation of the cost panel GameObject and saving the player's purchase so that the player doesn't have to buy the skin again after restarting the game.
    /// If the player already purchased the skin before calling this function, the skin will only be equipped. Also, the appropriate panel will be showcased to the player 
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void PurchaseSkin_Crimson()
    {
        if (Script_GoldManager.gold >= cost_Crimson && Script_SaveProgress.unlocked_Crimson != "true") 
        {
            Script_GoldManager.removeGold(cost_Crimson);
            Panel_Cost_Crimson.SetActive(false);

            Script_SaveProgress.unlocked_Crimson = "true";
            PlayerPrefs.SetString("Unlocked_Crimson", Script_SaveProgress.unlocked_Crimson);
        }

        if (Script_SaveProgress.unlocked_Crimson == "true")
        {
            EquipSkin_Crimson();
        }
    }
    private void EquipSkin_Crimson()
    {
        counter.color = Color_Crimson;

        Panel_Equipped_White.SetActive(false);
        Panel_Equipped_Green.SetActive(false);
        Panel_Equipped_Crimson.SetActive(true);
        Panel_Equipped_Cyan.SetActive(false);
        Panel_Equipped_Violet.SetActive(false);
        Panel_Equipped_Gold.SetActive(false);
    }

    /// <summary>
    /// When this function is called, we check if the player has enough Gold to purchase the skin and if he hasn't already bought this skin.
    /// If both criteria are met by the player, we let the player purchase this skin, which will result in removing the cost of the skin from the player's Gold count,
    /// deactivation of the cost panel GameObject and saving the player's purchase so that the player doesn't have to buy the skin again after restarting the game.
    /// If the player already purchased the skin before calling this function, the skin will only be equipped. Also, the appropriate panel will be showcased to the player 
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void PurchaseSkin_Cyan()
    {
        if (Script_GoldManager.gold >= cost_Cyan && Script_SaveProgress.unlocked_Cyan != "true")
        {
            Script_GoldManager.removeGold(cost_Cyan);
            Panel_Cost_Cyan.SetActive(false);

            Script_SaveProgress.unlocked_Cyan = "true";
            PlayerPrefs.SetString("Unlocked_Cyan", Script_SaveProgress.unlocked_Cyan);
        }

        if (Script_SaveProgress.unlocked_Cyan == "true")
        {
            EquipSkin_Cyan();
        }
    }
    private void EquipSkin_Cyan()
    {
        counter.color = Color_Cyan;

        Panel_Equipped_White.SetActive(false);
        Panel_Equipped_Green.SetActive(false);
        Panel_Equipped_Crimson.SetActive(false);
        Panel_Equipped_Cyan.SetActive(true);
        Panel_Equipped_Violet.SetActive(false);
        Panel_Equipped_Gold.SetActive(false);
    }

    /// <summary>
    /// When this function is called, we check if the player has enough Gold to purchase the skin and if he hasn't already bought this skin.
    /// If both criteria are met by the player, we let the player purchase this skin, which will result in removing the cost of the skin from the player's Gold count,
    /// deactivation of the cost panel GameObject and saving the player's purchase so that the player doesn't have to buy the skin again after restarting the game.
    /// If the player already purchased the skin before calling this function, the skin will only be equipped. Also, the appropriate panel will be showcased to the player 
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void PurchaseSkin_Violet()
    {
        if (Script_GoldManager.gold >= cost_Violet && Script_SaveProgress.unlocked_Violet != "true")
        {
            Script_GoldManager.removeGold(cost_Violet);
            Panel_Cost_Violet.SetActive(false);

            Script_SaveProgress.unlocked_Violet = "true";
            PlayerPrefs.SetString("Unlocked_Violet", Script_SaveProgress.unlocked_Violet);
        }

        if (Script_SaveProgress.unlocked_Violet == "true")
        {
            EquipSkin_Violet();
        }
    }
    private void EquipSkin_Violet()
    {
        counter.color = Color_Violet;

        Panel_Equipped_White.SetActive(false);
        Panel_Equipped_Green.SetActive(false);
        Panel_Equipped_Crimson.SetActive(false);
        Panel_Equipped_Cyan.SetActive(false);
        Panel_Equipped_Violet.SetActive(true);
        Panel_Equipped_Gold.SetActive(false);
    }

    /// <summary>
    /// When this function is called, we check if the player has enough Gold to purchase the skin and if he hasn't already bought this skin.
    /// If both criteria are met by the player, we let the player purchase this skin, which will result in removing the cost of the skin from the player's Gold count,
    /// deactivation of the cost panel GameObject and saving the player's purchase so that the player doesn't have to buy the skin again after restarting the game.
    /// If the player already purchased the skin before calling this function, the skin will only be equipped. Also, the appropriate panel will be showcased to the player 
    /// to notify him that he has bought and/or applied this particular skin.
    /// </summary>
    public void PurchaseSkin_Gold()
    {
        if (Script_GoldManager.gold >= cost_Gold && Script_SaveProgress.unlocked_Gold != "true")
        {
            Script_GoldManager.removeGold(cost_Gold);
            Panel_Cost_Gold.SetActive(false);

            Script_SaveProgress.unlocked_Gold = "true";
            PlayerPrefs.SetString("Unlocked_Gold", Script_SaveProgress.unlocked_Gold);
        }

        if (Script_SaveProgress.unlocked_Gold == "true")
        {
            EquipSkin_Gold();
        }
    }
    private void EquipSkin_Gold()
    {
        counter.color = Color_Gold;

        Panel_Equipped_White.SetActive(false);
        Panel_Equipped_Green.SetActive(false);
        Panel_Equipped_Crimson.SetActive(false);
        Panel_Equipped_Cyan.SetActive(false);
        Panel_Equipped_Violet.SetActive(false);
        Panel_Equipped_Gold.SetActive(true);
    }
}
