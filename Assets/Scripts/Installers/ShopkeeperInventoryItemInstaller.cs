using Zenject;

//Attached to shopkeeper inventory item instance as subcontainer resolve
public class ShopkeeperInventoryItemInstaller : MonoInstaller
{
    public ItemListVariable playerItems;
    public IntReference currency;
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;

    public override void InstallBindings()
    {
        Container.Bind<ItemUInstance.Settings>().FromInstance(settings).AsSingle().NonLazy();
        Container.Bind<ItemUInstance.View>().FromInstance(view).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<BuyItem>()
            .FromNew().AsSingle().WithArguments(settings, view, playerItems, currency).NonLazy();
    }
}