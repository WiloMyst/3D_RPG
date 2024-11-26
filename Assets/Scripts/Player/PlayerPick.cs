using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家拾取脚本
public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 碰撞物体可交互
        if(collision.gameObject.tag == Tag.INTERACTABLE)
        {
            PickableObject po = collision.gameObject.GetComponent<PickableObject>();
            // 碰撞物体可拾取
            if(po != null)
            {
                InventoryManager.Instance.AddItem(po.itemSO);

                Destroy(po.gameObject);
            }
        }
    }
}
