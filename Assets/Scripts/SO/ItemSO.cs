using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物品数据
[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public int id;
    public new string name; //new有意隐藏原name
    public ItemType itemType;
    public string description;
    public List<Property> propertyList;
    public Sprite icon; //2D图像的封装类
    public GameObject prefab;
}

public enum ItemType
{
    Weapon,
    Consumable
}

[Serializable] //Property标识为可被序列化，否则Unity编辑器不显示
public class Property //属性
{
    public PropertyType propertyType;
    public int value;

    public Property()
    {

    }
    public Property(PropertyType propertyType, int value)
    {
        this.propertyType = propertyType;
        this.value = value;
    }
}
public enum PropertyType //属性类型
{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue
}
