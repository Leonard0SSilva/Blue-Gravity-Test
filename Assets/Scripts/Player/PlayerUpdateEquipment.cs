// Update player's equipped item visuals based on changes in the equipped items list
using UnityEngine;

public class PlayerUpdateEquipment : MonoBehaviour
{
    public int index;
    public ItemListVariable equippedItems;
    public Sprite[] spritSides;
    public SpriteRenderer[] itemSides;

    private void Start()
    {
        equippedItems.onListValueIndexChange += OnEquipItemChange;
    }

    private void OnDestroy()
    {
        equippedItems.onListValueIndexChange += OnEquipItemChange;
    }

    private void OnEquipItemChange(Item item, int index)
    {
        if (this.index == index)
        {
            spritSides = item.itemSides;
            for (int i = 0; i < itemSides.Length; i++)
            {
                itemSides[i].sprite = spritSides != null && spritSides.Length > i ? spritSides[i] : null;
                itemSides[i].gameObject.SetActive(itemSides[i].sprite == null);
            }
        }
    }
}