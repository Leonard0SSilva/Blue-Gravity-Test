using UnityEngine;
using Zenject;

//Attached to player inventory ui GameObjectContext
public class InventoryInstaller : MonoInstaller
{
    public GameObject inventoryPrefab;
    public Transform inventoryParent;

    public override void InstallBindings()
    {
        Container.Bind<InventoryMenu>().FromComponentOnRoot().AsSingle().NonLazy();
        Container.BindSignal<OpenShopSignal>()
           .ToMethod<InventoryMenu>(x => x.OnOpenShop)
           .FromResolve();
        Container.BindSignal<CloseShopSignal>()
           .ToMethod<InventoryMenu>(x => x.OnCloseShop)
           .FromResolve();

        Container.BindMemoryPool<ItemUInstance, ItemUInstance.Pool>()
        .FromNewComponentOnNewPrefab(inventoryPrefab)
        .UnderTransform(inventoryParent)
        .AsSingle().NonLazy();
    }
}