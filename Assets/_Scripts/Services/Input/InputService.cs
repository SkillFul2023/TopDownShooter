using UnityEngine;

namespace TopDownShooter.Service.Input
{
    public class InputService : IInputService
    {
        public Vector2 Axis =>
             new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

        public bool FireButtonUp()
        {
            return SimpleInput.GetButtonUp("Fire");
        }
    }
}