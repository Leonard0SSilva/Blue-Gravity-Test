using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [SerializeField]
    private AudioSettings audioSettings;

    public override void InstallBindings()
    {
        Container.Bind<AudioInstaller>().AsSingle().WithArguments(audioSettings).NonLazy();
        GameInstaller.Install(Container);
    }
}