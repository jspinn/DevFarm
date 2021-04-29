using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{

    public enum PickupObject { COIN, GEM };
    public PickupObject currentObject;
    public int pickupQuantity;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();

            if (currentObject == PickupObject.COIN)
            {
                playerStats.AddCoins(pickupQuantity);
            }
            else if (currentObject == PickupObject.GEM)
            {
                playerStats.gems += pickupQuantity;
            }
            Destroy(gameObject);
        }
    }
}
