// Populates an inventory UI using a list of items.
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryMenu : MonoBehaviour
{
    public ItemListVariable items;

    public ItemUInstance.Pool inventoryPool;

    [SerializeField]
    private bool shopIsOpen;
    [SerializeField]
    private List<ItemUInstance> itemInstances = new();

    [Inject]
    public void Construct(ItemUInstance.Pool inventoryPool)
    {
        this.inventoryPool = inventoryPool;
    }

    void Start()
    {
        items.onListValueIndexChange += OnItemChange;
        for (int i = 0; i < items.value.Count; i++)
        {
            ItemUInstance ui = inventoryPool.Spawn(i);
            itemInstances.Add(ui);
        }
    }

    private void OnDestroy()
    {
        SellOption(false);
        items.onListValueIndexChange -= OnItemChange;
    }

    private void OnItemChange(Item item, int index)
    {
        itemInstances[index].Initialize();
        if (shopIsOpen)
        {
            OnOpenShop();
        }
    }

    public void OnOpenShop(OpenShopSignal onOpen = null)
    {
        SellOption(true);
        shopIsOpen = true;
    }

    public void OnCloseShop(CloseShopSignal closeShop = null)
    {
        SellOption(false);
        shopIsOpen = false;
    }

    private void SellOption(bool value)
    {
        for (int i = 0; i < items.value.Count; i++)
        {
            itemInstances[i].view.enableSell = value && !items.value[i].Empty;
            itemInstances[i].UpdateSellButton(false);
        }
    }
}