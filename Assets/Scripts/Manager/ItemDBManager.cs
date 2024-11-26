using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物品数据管理器
public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager Instance {  get; private set; }

    public ItemDBSO itemDB;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }
        Instance = this;
    }

    public ItemSO GetRandomItem()
    {
        int randomIndex = Random.Range(0, itemDB.itemList.Count);
        return itemDB.itemList[randomIndex];
    }
}
