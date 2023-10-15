using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable/Health")]
public class ItemHealthAction : ItemAction
{
    public int addValue = 1;
    public IntReference currentHealth;
    public IntReference maxHealth;

    public override void Execute(Item item)
    {
        item.amount--;
        int newHealth = currentHealth.Value + addValue;
        newHealth = Mathf.Clamp(newHealth, 0, maxHealth.Value);
        currentHealth.Set(newHealth);
    }
}