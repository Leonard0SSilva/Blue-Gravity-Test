using Zenject;

//Attached to player GameObjectContext
public class PlayerInstaller : MonoInstaller
{
    public Vector2Reference direction;
    public PlayerInputController.Settings inputSettings;
    public MovementController.Settings movementSettings;
    public PlayerAnimatorController.Settings animatorSettings;

    public override void InstallBindings()
    {
        movementSettings.direction = direction;
        Container.BindInterfacesAndSelfTo<MovementController>().AsSingle()
            .WithArguments(movementSettings).NonLazy();

        inputSettings.direction = direction;
        Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle()
            .WithArguments(inputSettings).NonLazy();

        animatorSettings.direction = direction;
        Container.BindInterfacesAndSelfTo<PlayerAnimatorController>().AsSingle()
            .WithArguments(animatorSettings).NonLazy();
    }
}