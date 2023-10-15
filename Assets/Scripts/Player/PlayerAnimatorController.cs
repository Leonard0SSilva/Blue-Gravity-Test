// PlayerAnimatorController: Manages player animation based on movement direction and state.
using System;
using UnityEngine;
using Zenject;

public class PlayerAnimatorController : ILateTickable
{
    [Serializable]
    public class Settings
    {
        public Animator animator;
        public Vector2Reference direction;
    }
    public Settings settings;
    public static int directionKey = Animator.StringToHash("Direction");
    public static int isMovingKey = Animator.StringToHash("IsMoving");

    [Inject]
    private PlayerAnimatorController(Settings settings)
    {
        this.settings = settings;
    }

    public void LateTick()
    {
        if (settings.direction.Value.x == -1)
        {
            settings.animator.SetInteger(directionKey, 3);
        }
        else if (settings.direction.Value.x == 1)
        {
            settings.animator.SetInteger(directionKey, 2);
        }

        if (settings.direction.Value.y == 1)
        {
            settings.animator.SetInteger(directionKey, 1);
        }
        else if (settings.direction.Value.y == -1)
        {
            settings.animator.SetInteger(directionKey, 0);
        }
        settings.animator.SetBool(isMovingKey, settings.direction.Value.magnitude > 0);
    }
}