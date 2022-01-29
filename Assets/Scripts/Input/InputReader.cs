using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    public Vector2EventChannelSO moveEvent = default;
    public VoidEventChannelSO attackEvent = default;
    private GameInput gameInput;

    private void OnEnable() {
        if (gameInput == null) {
            gameInput = new GameInput();
            gameInput.Gameplay.SetCallbacks(this);
        }
        EnableGameplayInput();
    }

    private void OnDisable() {
        DisableAllInput();
    }

    public void EnableGameplayInput()
	{
        gameInput.Gameplay.Enable();
	}

    public void DisableAllInput() {
        gameInput.Gameplay.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        moveEvent.RaiseEvent(ctx.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext ctx) {
        attackEvent.RaiseEvent();
    }

    public void OnTest(InputAction.CallbackContext ctx) {
        Debug.Log("Works!");
    }
}
