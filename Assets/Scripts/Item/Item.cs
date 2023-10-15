using System;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemAction ItemType;
    public string name, description, category;
    public int amount, price;
    public Sprite icon;
    public Sprite[] itemSides;
    public bool Empty => amount <= 0;
    public bool equipped;

    public Item() { }

    public Item(Item item)
    {
        ItemType = item.ItemType;
        name = item.name;
        description = item.category;
        amount = item.amount;
        price = item.price;
        icon = item.icon;
        itemSides = item.itemSides;
        equipped = item.equipped;
    }
}