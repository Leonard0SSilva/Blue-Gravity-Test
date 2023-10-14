using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable")]
public class ItemConsumableAction : ItemAction
{
    public override void Execute(Item item)
    {
        item.amount--;
    }
}