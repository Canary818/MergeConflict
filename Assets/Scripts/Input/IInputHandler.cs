using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputHandler 
{
    // returns true when input is successfully handled
    public void HandleInput(InputManager.InputEvent inputEvent);
}
