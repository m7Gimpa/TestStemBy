using UnityEngine;

namespace Services.Input
{
    public class InputService : IInputService
    {

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string FireButton = "Fire";
        public Vector2 Axis =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
            
        public bool IsAttackButtonUp()
        {
            return SimpleInput.GetButtonUp(FireButton);
        }
    }
}