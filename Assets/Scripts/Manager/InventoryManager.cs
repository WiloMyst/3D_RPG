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

    public List<ItemSO> itemList; //ʰȡ�б�
    public ItemSO defaultWeapon; //Ĭ������

    //IEnumerator Start() //����Start����˳��ȷ��
    //{
    //    yield return new WaitForSeconds(1);
    //    AddItem(defaultWeapon);
    //}

    public void AddItem(ItemSO itemSO)
    {
        itemList.Add(itemSO);
        InventoryUI.Instance.AddItem(itemSO);
        MessageUI.Instance.Show("������һ����" + itemSO.name);
    }
    public void RemoveItem(ItemSO itemSO)
    {
        itemList.Remove(itemSO);
    }
}