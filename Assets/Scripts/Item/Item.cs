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
}