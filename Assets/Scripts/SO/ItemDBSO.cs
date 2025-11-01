using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物品数据库
[CreateAssetMenu()]
public class ItemDBSO : ScriptableObject
{
    public List<ItemSO> itemList;
}
