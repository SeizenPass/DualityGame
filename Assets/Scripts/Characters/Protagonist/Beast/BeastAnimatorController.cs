using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private PersonMovementController _personMovementController;
    private BeastAttackController _beastAttackController;
    private const string ATTACK = "Attack", DASH = "Dash", IS_RUNNING = "IsRunning";

    private void Awake() {
        _animator = GetComponent<Animator>();
        _beastAttackController = GetComponent<BeastAttackController>();
        _personMovementController = GetComponent<PersonMovementController>();
    }

    private void OnEnable() {
        _beastAttackController.attackEvent += CallAttackTrigger;
        _personMovementController.dashEvent += CallDashTrigger;
    }

    private void OnDisable() {
        _beastAttackController.attackEvent -= CallAttackTrigger;
        _personMovementController.dashEvent -= CallDashTrigger;
    }

    private void Update() {
        if (_personMovementController._inputDirection > 0.001f || _personMovementController._inputDirection < -0.001f) {
            SetIsRunning(true);
        } else SetIsRunning(false);
    }

    private void CallAttackTrigger() {
        _animator.SetTrigger(ATTACK);
    }

    private void CallDashTrigger() {
        _animator.SetTrigger(DASH);
    }

    private void SetIsRunning(bool isRunning) {
        _animator.SetBool(IS_RUNNING, isRunning);
    }
}
