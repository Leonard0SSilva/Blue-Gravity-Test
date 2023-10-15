using Zenject;

public class SellItem : IInitializable
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;
    public IntReference currency;

    public SellItem(ItemUInstance.Settings settings, ItemUInstance.View view, IntReference currency)
    {
        this.settings = settings;
        this.view = view;
        this.currency = currency;
    }

    public void Initialize()
    {
        view.sellButton.onClick.RemoveAllListeners();
        view.sellButton.onClick.AddListener(() =>
        {
            var item = settings.Item;
            currency.Set(currency.Value + (int)(item.price * settings.sellRatio.Value));
            settings.items.Set(new Item(), settings.items.value.FindIndex(x => x == item));
        });
    }
}