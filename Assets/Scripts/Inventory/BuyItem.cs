using UnityEngine;
using Zenject;

public class BuyItem : IInitializable
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;
    public ItemListVariable playerItems;
    public IntReference currency;

    public BuyItem(ItemUInstance.Settings settings, ItemUInstance.View view,
        ItemListVariable playerItems, IntReference currency)
    {
        this.settings = settings;
        this.view = view;
        this.playerItems = playerItems;
        this.currency = currency;
    }

    public void Initialize()
    {
        view.equipButton.onClick.RemoveAllListeners();
        view.equipButton.onClick.AddListener(() =>
        {
            int validIndex = playerItems.value.FindIndex(x => x.Empty);
            if (validIndex != -1 && currency.Value >= settings.Item.price)
            {
                settings.Item.equipped = false;
                playerItems.Set(new Item(settings.Item), validIndex);
                currency.Set(currency.Value - settings.Item.price);
                view.gameObject.SetActive(false);
            }
        });
    }
}