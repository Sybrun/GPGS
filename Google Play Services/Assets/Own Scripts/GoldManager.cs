using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int gold = 500;
    public Text goldCounter;

    /// <summary>
    /// Updates the Gold counter continually accordingly to the correct Gold value of the player.
    /// </summary>
    void Update()
    {
        goldCounter.text = gold.ToString();
    }

    /// <summary>
    /// This function gets called whenever the player should be rewarded with Gold. This function has an int parameter 
    /// which determines how many Gold will be added to the player's Gold counter. After the Gold has been added,
    /// the Gold counter will save it's value so that the player will keep his Gold if he restarts the game.
    /// </summary>
    public void addGold(int amount)
    {
        gold += amount;
        PlayerPrefs.SetInt("Gold", gold);
    }

    /// <summary>
    /// This function gets called whenever the player loses Gold (After buying a skin from the shop). This function has an int parameter 
    /// which determines how many Gold will be subtracted from the player's Gold counter. After the Gold has been subtracted,
    /// the Gold counter will save it's value so that the player will keep his Gold if he restarts the game.
    /// </summary>
    public void removeGold(int amount)
    {
        gold -= amount;
        PlayerPrefs.SetInt("Gold", gold);
    }
}
