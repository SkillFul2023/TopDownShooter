using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Service.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool FireButtonUp();
    }
}

