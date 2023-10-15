using Zenject;

//Attached to player inventory item instance as subcontainer resolve
public class PlayerInventoryItemInstaller : MonoInstaller
{
    public IntReference currency;
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;

    public override void InstallBindings()
    {
        Container.Bind<ItemUInstance.Settings>().FromInstance(settings).AsSingle().NonLazy();
        Container.Bind<ItemUInstance.View>().FromInstance(view).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SellItem>()
            .FromNew().AsSingle().WithArguments(settings, view, currency).NonLazy();
    }
}