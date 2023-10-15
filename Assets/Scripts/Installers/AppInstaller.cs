using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    [SerializeField]
    private AudioSettings audioSettings;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.Bind<AudioManager>().AsSingle()
            .WithArguments(audioSettings).NonLazy();

        GameInstaller.Install(Container);
    }
}