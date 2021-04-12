using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class playerMoney : MonoBehaviour
{
    public int money;
    //public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;

    }

    public void subtractMoney(int moneyToSubtract)
    {
        if(money - moneyToSubtract<0)
        {
            Debug.Log("Not enough money!");
        }
        else
        {
            money -= moneyToSubtract;
        }

    }
}
