// MovementController: Handles movement of the GameObject based on direction and speed.
using System;
using UnityEngine;
using Zenject;

public class MovementController : ITickable
{
    [Serializable]
    public class Settings
    {
        public FloatReference speed;
        public Vector2Reference direction;
        public Rigidbody2D rb2D;
    }
    public Settings settings;

    [Inject]
    private MovementController(Settings settings)
    {
        this.settings = settings;
    }

    public void Tick()
    {
        settings.direction.Value.Normalize();
        settings.rb2D.velocity = settings.speed * settings.direction.Value;
    }
}