// Populates an inventory UI using a list of items.
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopkeeperMenu : MonoBehaviour
{
    [SerializeField]
    private IntVariable playerCurrency;
    [SerializeField]
    private ItemListVariable items;
    [SerializeField]
    private List<ItemUInstance> itemInstances = new();

    public ItemUInstance.Pool inventoryPool;
    public SignalBus signalBus;

    [Inject]
    public void Construct(SignalBus signalBus, ItemUInstance.Pool inventoryPool)
    {
        this.signalBus = signalBus;
        this.inventoryPool = inventoryPool;
    }

    private void Awake()
    {
        playerCurrency.onValueChange += ReinitializeUI;
        for (int i = 0; i < items.value.Count; i++)
        {
            ItemUInstance ui = inventoryPool.Spawn(i);
            itemInstances.Add(ui);
        }
    }

    private void OnEnable()
    {
        ReinitializeUI();
        signalBus?.Fire<OpenShop>();
    }

    private void OnDisable()
    {
        signalBus?.Fire<CloseShop>();
    }

    private void OnDestroy()
    {
        playerCurrency.onValueChange -= ReinitializeUI;
    }

    public void ReinitializeUI(int currency)
    {
        for (int i = 0; i < items.value.Count; i++)
        {
            itemInstances[i].UpdateSellButton(true, items.value[i].price > currency);
        }
    }

    public void ReinitializeUI()
    {
        for (int i = 0; i < items.value.Count; i++)
        {
            itemInstances[i].UpdateSellButton(true, items.value[i].price > playerCurrency.value);
        }
    }
}