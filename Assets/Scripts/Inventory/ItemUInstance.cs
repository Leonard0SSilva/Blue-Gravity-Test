// Represents an instance of an item in the inventory UI.
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemUInstance : MonoBehaviour
{
    public class Pool : MonoMemoryPool<int, ItemUInstance>
    {
        protected override void Reinitialize(int index, ItemUInstance instance)
        {
            instance.settings.index.Set(index);
            instance.Initialize();
        }
    }

    [Serializable]
    public class Settings
    {
        public IntReference index;
        public Item Item => items.value[index];
        public FloatReference sellRatio;
        public ItemListVariable items;
    }

    [Serializable]
    public class View
    {
        public GameObject gameObject;
        public GameObject highlight;
        public Image icon;
        public TextMeshProUGUI slotIndexTMP, priceTMP;
        public Button equipButton, sellButton;
    }

    public Settings settings;
    public View view;

    [Inject]
    public void Construct(Settings settings, View view)
    {
        this.settings = settings;
        this.view = view;
        settings.Item.equipped = false;
    }

    public void Initialize(bool invalid = false)
    {
#if UNITY_EDITOR
        gameObject.name = $"Item Button: {settings.index.Value}";
#endif
        if (view.slotIndexTMP)
        {
            view.slotIndexTMP.text = $"{settings.index.Value + 1}";
        }
        UpdateSellButton(false, invalid);
        view.icon.sprite = settings.Item.icon;
        view.icon.enabled = !settings.Item.Empty;
    }

    public void UpdateSellButton(bool value, bool invalid)
    {
        if (view.priceTMP)
        {
            view.priceTMP.text = $"{settings.Item.price * settings.sellRatio.Value}";
            view.priceTMP.color = invalid ? Color.red : Color.white;
        }
        if (view.sellButton)
        {
            view.sellButton.gameObject.SetActive(value);
            view.sellButton.interactable = !invalid;
        }
    }
}