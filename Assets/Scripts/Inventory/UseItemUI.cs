// Handle use UI items and highlighting the selected item
using UnityEngine;
using Zenject;

public class UseItemUI : MonoBehaviour
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;

    [Inject]
    public void Construct(ItemUInstance.Settings settings, ItemUInstance.View view)
    {
        this.settings = settings;
        this.view = view;
    }

    public void Start()
    {
        view.highlight.SetActive(settings.Item.equipped);
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
                        equipUIs.view.highlight.SetActive(false);
                    }
                    foreach (var item in settings.items.value)
                    {
                        item.equipped = false;
                    }
                    settings.Item.equipped = !cachedEquip;
                    view.highlight.SetActive(!cachedEquip);
                }
                settings.Item.ItemType?.Execute(settings.Item);
                if (settings.Item.Empty)
                {
                    settings.items.value[settings.index] = new Item();
                }
            }
        });
    }
}