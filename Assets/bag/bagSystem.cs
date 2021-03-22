using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// copy current grid
public static InventoryUIItemWrapperBase CreateDragObject(InventoryUIItemWrapperBase from)
{
    var copy = GameObject.Instantiate<InventoryUIItemWrapperBase>(from);
    copy.index = from.index;
    copy.itemCollection = from.itemCollection;
    copy.item = from.item;

    var copyComp = copy.GetComponent<RectTransform>();
    copyComp.SetParent(InventorySettingsManager.instance.guiRoot.transform);
    copyComp.transform.localPosition = new Vector3(copyComp.transform.localPosition.x, copyComp.transform.localPosition.y, 0.0f);
    copyComp.sizeDelta = from.GetComponent<RectTransform>().sizeDelta;

    group.blocksRaycasts = false;
    group.interactable = false;

    return copy;
}

//draging event
public static void OnDrag(PointerEventData eventData)
{
    if (currentDragHandler != null)
    {
        currentDragHandler.OnDrag(eventData);

        if (OnDragging != null) OnDragging(currentDragHandler.dragLookup, currentDragHandler.currentlyDragging, eventData);
    }
}


//finish drag
public static InventoryUIDragLookup OnEndDrag(PointerEventData eventData)
{
    if (currentDragHandler == null)
    {
        return null;
    }
    var lookup = currentDragHandler.OnEndDrag(InventoryUIUtility.currentlyHoveringWrapper, eventData);
    if (OnEndDragging != null)
    {
        OnEndDragging(lookup, currentDragHandler.currentlyDragging, eventData);
        AppFacade.instance.CallLua("pg.global.bag.moveItem", curItemId, eventData.getTargetGrid());
    }

    return lookup;
}
