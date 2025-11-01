using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家
public class Player : MonoBehaviour
{
    private PlayerProperty playerProperty;
    private PlayerAttack playerAttack;
    private void Start()
    {
        playerProperty = GetComponent<PlayerProperty>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void UseItem(ItemSO itemSO)
    {
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                playerAttack.LoadWeapon(itemSO);
                break;
            case ItemType.Consumable:
                playerProperty.UseDrug(itemSO);
                break;
            default:
                break;
        }
    }
}
