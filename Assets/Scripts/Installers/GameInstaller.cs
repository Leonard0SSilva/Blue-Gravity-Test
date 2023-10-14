using Zenject;

public class GameInstaller : Installer<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<OpenShop>();
        Container.DeclareSignal<CloseShop>();
    }
}