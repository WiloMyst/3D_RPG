using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 可拾取物品
public class PickableObject : InteractableObject
{
    public ItemSO itemSO;
    protected override void Interact()
    {
        Destroy(this.gameObject);
        InventoryManager.Instance.AddItem(itemSO);
    }
}
