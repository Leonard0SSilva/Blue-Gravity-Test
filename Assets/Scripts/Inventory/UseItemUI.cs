// Handle use UI items and highlighting the selected item
using UnityEngine;
using Zenject;

public class UseItemUI : MonoBehaviour
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;
    public SignalBus signalBus;

    [Inject]
    public void Construct(ItemUInstance.Settings settings, ItemUInstance.View view, SignalBus signalBus)
    {
        this.settings = settings;
        this.view = view;
        this.signalBus = signalBus;
    }

    public void Start()
    {
        signalBus.Subscribe<EquipItemSignal>(OnEquipItem);
        signalBus.Subscribe<UnequipItemSignal>(OnUnequipItem);
        view.equipButton.onClick.RemoveAllListeners();
        view.equipButton.onClick.AddListener(() =>
        {
            if (!settings.Item.Empty && settings.Item.ItemType != null)
            {
                bool cachedEquip = settings.Item.equipped;
                if (settings.Item.ItemType.GetType() == typeof(ItemEquippableAction))
                {
                    UseItemUI[] equipUIItem = FindObjectsOfType<UseItemUI>();
                    foreach (var equipUIs in equipUIItem)
                    {
                        if (equipUIs != this)
                        {
                            equipUIs.view.highlight.SetActive(false);
                            if (equipUIs.settings.Item.equipped)
                            {
                                signalBus.Fire(new UnequipItemSignal() { item = equipUIs.settings.Item });
                            }
                        }
                    }
                    foreach (var item in settings.items.value)
                    {
                        item.equipped = false;
                    }

                    settings.Item.equipped = !cachedEquip;
                    if (settings.Item.equipped)
                    {
                        signalBus.Fire(new EquipItemSignal() { item = settings.Item });
                    }
                    else
                    {
                        signalBus.Fire(new UnequipItemSignal() { item = settings.Item });
                    }
                }
                settings.Item.ItemType?.Execute(settings.Item);
                if (settings.Item.Empty)
                {
                    settings.items.value[settings.index] = new Item();
                }
            }
        });
    }

    public void OnDestroy()
    {
        signalBus.Unsubscribe<EquipItemSignal>(OnEquipItem);
        signalBus.Unsubscribe<UnequipItemSignal>(OnUnequipItem);
    }

    public void OnEquipItem(EquipItemSignal unequipItemSignal)
    {
        if (unequipItemSignal.item == settings.Item)
        {
            view.highlight.SetActive(true);
        }
    }

    public void OnUnequipItem(UnequipItemSignal unequipItemSignal)
    {
        if (unequipItemSignal.item == settings.Item)
        {
            view.highlight.SetActive(false);
        }
    }
}