using Zenject;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<OpenShopSignal>();
        Container.DeclareSignal<CloseShopSignal>();
        Container.DeclareSignal<UpdateUIItemSignal>();
        Container.DeclareSignal<EquipItemSignal>();
        Container.DeclareSignal<UnequipItemSignal>();
    }
}