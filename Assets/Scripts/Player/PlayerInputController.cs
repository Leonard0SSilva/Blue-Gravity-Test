// PlayerInputController: Handles player input for movement in different directions.
using System;
using UnityEngine;
using Zenject;

[DefaultExecutionOrder(-100)]
public class PlayerInputController : ITickable
{
    [Serializable]
    public class Settings
    {
        public KeyCodeVariable moveLeft, moveRight, moveUp, moveDown;
        public Vector2Reference direction;
    }

    public Settings settings;
    Vector2 vector2Zero = Vector2.zero;

    public PlayerInputController(Settings settings)
    {
        this.settings = settings;
    }

    public void Tick()
    {
        settings.direction.Set(vector2Zero);
        if (Input.GetKey(settings.moveLeft.value))
        {
            settings.direction.SetX(-1);
        }
        else if (Input.GetKey(settings.moveRight.value))
        {
            settings.direction.SetX(1);
        }

        if (Input.GetKey(settings.moveUp.value))
        {
            settings.direction.SetY(1);
        }
        else if (Input.GetKey(settings.moveDown.value))
        {
            settings.direction.SetY(-1);
        }
    }
}