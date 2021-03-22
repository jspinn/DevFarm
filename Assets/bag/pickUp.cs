using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public virtual void OnTriggerEnter(Collider col)
{
    TryPickup(col.gameObject);
}

public virtual void OnTriggerEnter2D(Collider2D col)
{
    TryPickup(col.gameObject);
}

protected virtual void TryPickup(GameObject obj)
{
    if (obj.layer == InventorySettingsManager.instance.equipmentLayer)
    {
        return;
    }
    if (InventorySettingsManager.instance.itemTriggerOnPlayerCollision || CanPickupGold(obj))
    {
        var item = obj.GetComponent<ObjectTriggererItem>();
        if (item != null)
        {
            item.Use(this);
        }
    }
}
protected virtual bool CanPickupGold(GameObject obj)
{
    return InventorySettingsManager.instance.alwaysTriggerGoldItemPickupOnPlayerCollision && obj.GetComponent<CurrencyInventoryItem>() != null;
}
protected virtual void PickUpSucc(itemId, gridId)
{
    AppFacade.instance.CallLua("pg.global.bag.addItem", curItemId, gridId)
}