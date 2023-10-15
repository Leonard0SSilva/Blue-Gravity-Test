using Zenject;

//Attached on the SceneContext
public class DemoSceneInstaller : MonoInstaller
{
    public AudioClipSettings musicSettings;
    public int startHealth = 1, startCoins = 500;
    public IntReference health, coins;

    public override void InstallBindings()
    {
        health.Set(startHealth);
        coins.Set(startCoins);
        musicSettings.Execute();
    }
}