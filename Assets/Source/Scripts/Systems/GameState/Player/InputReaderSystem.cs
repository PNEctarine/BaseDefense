using Kuhpik;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderSystem : GameSystem
{
    public void ReadMovementInputData(InputAction.CallbackContext context)
    {
        game.InputVector = context.ReadValue<Vector2>();
    }
}
