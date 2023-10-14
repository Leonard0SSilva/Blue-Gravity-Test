// Handles drop item functionality.
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ItemUIDrop : MonoBehaviour, IDropHandler
{
    public ItemUInstance.Settings settings;

    [Inject]
    public void Construct(ItemUInstance.Settings settings)
    {
        this.settings = settings;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject item = eventData.pointerDrag;
        ItemUIDrop dragedItem = item.GetComponent<DraggableUI>().parent.GetComponent<ItemUIDrop>();
        if (dragedItem != this)
        {
            Item tempItem = settings.Item;
            settings.items.Set(dragedItem.settings.Item, settings.index);
            settings.items.Set(tempItem, dragedItem.settings.index);
        }
    }
}