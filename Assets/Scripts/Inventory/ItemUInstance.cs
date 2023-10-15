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
        public bool enableSell;
        public GameObject gameObject;
        public GameObject highlight;
        public Image icon;
        public TextMeshProUGUI slotIndexTMP, amountTMP, priceTMP;
        public Button equipButton, sellButton;
    }

    public Settings settings;
    public View view;
    public SignalBus signalBus;

    [Inject]
    public void Construct(Settings settings, View view, SignalBus signalBus)
    {
        this.settings = settings;
        this.view = view;
        this.signalBus = signalBus;
        settings.Item.equipped = false;
    }

    public void Start()
    {
        signalBus.Subscribe<UpdateUIItemSignal>(UpdateUI);
    }

    public void OnDestroy()
    {
        signalBus.Unsubscribe<UpdateUIItemSignal>(UpdateUI);
    }

    public void UpdateUI(UpdateUIItemSignal signal)
    {
        if (signal.item == settings.Item)
        {
            Initialize();
        }
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
        UpdateSellButton(invalid);
        view.icon.sprite = settings.Item.icon;
        view.icon.enabled = !settings.Item.Empty;
        view.amountTMP.text = settings.Item.amount > 1 ? settings.Item.amount.ToString() : "";
    }

    public void UpdateSellButton(bool invalid)
    {
        if (view.priceTMP)
        {
            view.priceTMP.text = $"{settings.Item.price * settings.sellRatio.Value}";
            view.priceTMP.color = invalid ? Color.red : Color.white;
        }
        if (view.sellButton)
        {
            view.sellButton.gameObject.SetActive(!settings.Item.Empty && view.enableSell);
            view.sellButton.interactable = !invalid;
        }
    }
}