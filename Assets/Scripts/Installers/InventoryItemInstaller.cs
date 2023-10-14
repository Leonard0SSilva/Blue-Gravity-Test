using Zenject;

public class InventoryItemInstaller : MonoInstaller
{
    public ItemUInstance.Settings settings;
    public ItemUInstance.View view;

    public override void InstallBindings()
    {
        Container.Bind<ItemUIDrop>().FromNewComponentOnRoot().AsSingle().NonLazy();
        Container.Bind<UseItemUI>().FromNewComponentOnRoot().AsSingle().NonLazy();

        Container.Bind<ItemUInstance.Settings>().FromInstance(settings).AsSingle().NonLazy();
        Container.Bind<ItemUInstance.View>().FromInstance(view).AsSingle().NonLazy();
    }
}