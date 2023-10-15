using UnityEngine;
using Zenject;

//Attached on the Project Context
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