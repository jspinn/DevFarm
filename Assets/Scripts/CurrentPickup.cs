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
            if (currentObject == PickupObject.COIN)
            {
                PlayerStats.playerstats.coins += pickupQuantity;
                Debug.Log(PlayerStats.playerstats.coins);
            }
            else if (currentObject == PickupObject.GEM)
            {
                PlayerStats.playerstats.gems += pickupQuantity;
                Debug.Log(PlayerStats.playerstats.gems);
            }
            Destroy(gameObject);
        }
    }
}
