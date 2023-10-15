using Zenject;

public class SellItem : IInitializable
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;
    public IntReference currency;
    public SignalBus signalBus;

    public SellItem(ItemUInstance.Settings settings, ItemUInstance.View view, IntReference currency, SignalBus signalBus)
    {
        this.settings = settings;
        this.view = view;
        this.currency = currency;
        this.signalBus = signalBus;
    }

    public void Initialize()
    {
        view.sellButton.onClick.RemoveAllListeners();
        view.sellButton.onClick.AddListener(() =>
        {
            var item = settings.Item;
            signalBus.Fire(new UnequipItemSignal() { item = item });
            currency.Set(currency.Value + (int)(item.price * settings.sellRatio.Value));
            settings.items.Set(new Item(), settings.items.value.FindIndex(x => x == item));
        });
    }
}