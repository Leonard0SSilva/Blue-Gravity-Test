using UnityEngine;
using Zenject;

public class ShopkeeperInstaller : MonoInstaller
{
    public ShopkeeperMenu shopkeeperMenu;
    public GameObject inventoryPrefab;
    public Transform inventoryParent;

    public override void InstallBindings()
    {
        Container.Bind<ShopkeeperMenu>().FromInstance(shopkeeperMenu)
            .AsSingle().NonLazy();

        Container.BindMemoryPool<ItemUInstance, ItemUInstance.Pool>()
        .FromNewComponentOnNewPrefab(inventoryPrefab)
        .UnderTransform(inventoryParent)
        .AsSingle().NonLazy();
    }
}