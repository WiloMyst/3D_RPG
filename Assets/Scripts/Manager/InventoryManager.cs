using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance {  get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }

    public List<ItemSO> itemList; //拾取列表
    public ItemSO defaultWeapon; //默认武器

    //IEnumerator Start() //各个Start调用顺序不确定
    //{
    //    yield return new WaitForSeconds(1);
    //    AddItem(defaultWeapon);
    //}

    public void AddItem(ItemSO itemSO)
    {
        itemList.Add(itemSO);
        InventoryUI.Instance.AddItem(itemSO);
        MessageUI.Instance.Show("你获得了一个：" + itemSO.name);
    }
    public void RemoveItem(ItemSO itemSO)
    {
        itemList.Remove(itemSO);
    }
}
