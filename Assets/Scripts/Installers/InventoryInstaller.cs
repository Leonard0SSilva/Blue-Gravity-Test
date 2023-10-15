using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    public GameObject inventoryPrefab;
    public Transform inventoryParent;

    public override void InstallBindings()
    {
        Container.Bind<InventoryMenu>().FromComponentOnRoot().AsSingle().NonLazy();
        Container.BindSignal<OpenShop>()
           .ToMethod<InventoryMenu>(x => x.OnOpenShop)
           .FromResolve();
        Container.BindSignal<CloseShop>()
           .ToMethod<InventoryMenu>(x => x.OnCloseShop)
           .FromResolve();

        Container.BindMemoryPool<ItemUInstance, ItemUInstance.Pool>()
        .FromNewComponentOnNewPrefab(inventoryPrefab)
        .UnderTransform(inventoryParent)
        .AsSingle().NonLazy();
    }
}