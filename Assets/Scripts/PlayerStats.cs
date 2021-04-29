using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public int coins;
    public int gems;
    public TextMeshProUGUI moneyText;

    public void AddCoins(int amount) {
        coins += amount;
        moneyText.text= coins.ToString();
    }

    public void RemoveCoins(int amount) {
        coins -= amount;
        moneyText.text= coins.ToString();
    }


}