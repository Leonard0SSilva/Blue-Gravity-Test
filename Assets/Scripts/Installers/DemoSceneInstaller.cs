using Zenject;

public class DemoSceneInstaller : MonoInstaller
{
    public int startHealth = 1, startCoins = 500;
    public IntReference health, coins;

    public override void InstallBindings()
    {
        health.Set(startHealth);
        coins.Set(startCoins);
    }
}