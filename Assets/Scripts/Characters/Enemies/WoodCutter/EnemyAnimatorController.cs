using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator animator;
    private EnemyAI _enemyAI;
    private EnemyAttackController enemyAttackController;
    private Health health;

    private void Awake() {
        _enemyAI = GetComponent<EnemyAI>();
        enemyAttackController = GetComponent<EnemyAttackController>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void OnEnable() {
        enemyAttackController.attackEvent += TriggetAttack;
        health.onHurt += TriggerHurt;
        health.onDie += SetDeadBool;
    }

    private void OnDisable() {
        enemyAttackController.attackEvent -= TriggetAttack;
        health.onHurt -= TriggerHurt;
        health.onDie -= SetDeadBool;
    }

    private void TriggetAttack() {
        animator.SetTrigger("Attack");
    }

    private void TriggerHurt() {
        Debug.Log("Hurt Triggered!");
        animator.SetTrigger("Hurt");
    }

    private void SetDeadBool() {
        animator.SetBool("IsDead", true);
    }

    private void FixedUpdate() {
        if (_enemyAI.moving) animator.SetBool("IsMoving", true);
        else animator.SetBool("IsMoving", false);
    }
}
