using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{
    public FloatEventChannelSO moveEvent = default;
    public VoidEventChannelSO attackEvent = default;
    public VoidEventChannelSO interactEvent = default;
    public VoidEventChannelSO jumpEvent = default;
    public VoidEventChannelSO dashEvent = default;
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
        moveEvent.RaiseEvent(ctx.ReadValue<float>());
    }

    public void OnAttack(InputAction.CallbackContext ctx) {
        if (ctx.phase == InputActionPhase.Performed) 
            attackEvent.RaiseEvent();
    }

    public void OnInteract(InputAction.CallbackContext ctx) {
        if (ctx.phase == InputActionPhase.Performed)
            interactEvent.RaiseEvent();
    }

    public void OnJump(InputAction.CallbackContext ctx) {
        if (ctx.phase == InputActionPhase.Performed)
            jumpEvent.RaiseEvent();
    }

    public void OnDash(InputAction.CallbackContext ctx) {
        if (ctx.phase == InputActionPhase.Performed)
            dashEvent.RaiseEvent();
    }

    public void OnTest(InputAction.CallbackContext ctx) {
        if (ctx.phase == InputActionPhase.Performed)
            Debug.Log("Works!");
    }
}
