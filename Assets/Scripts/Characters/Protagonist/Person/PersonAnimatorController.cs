using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private PersonMovementController _personMovementController;
    private const string IS_WALKING = "IsWalking";
    private void Awake() {
        _animator = GetComponent<Animator>();
        _personMovementController = GetComponent<PersonMovementController>();
    }

    private void Update() {
        if (_personMovementController._inputDirection > 0.001f || _personMovementController._inputDirection < -0.001f) {
            SetIsWalking(true);
        } else SetIsWalking(false);
    }

    private void SetIsWalking(bool isRunning) {
        _animator.SetBool(IS_WALKING, isRunning);
    }
}
