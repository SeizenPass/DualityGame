using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackController : MonoBehaviour
{
    public LayerMask targetLayer;
    private EnemyAI _enemyAI;
    public PlayerDetector playerDetector;
    private Health health;
    public float stopTime = 1f;
    public float attackCooldown = 2.5f;
    public float attackRadius = 1;
    private float lastAttackTime;
    private bool dead = false;
    public event UnityAction attackEvent = delegate {};

    private void Awake() {
        health = GetComponent<Health>();
        _enemyAI = GetComponent<EnemyAI>();
        lastAttackTime = Time.time - attackCooldown;
    }

    private void OnEnable() {

        playerDetector.playerOnSightEvent += Attack;
        health.onDie += SetDead;
    }

    private void OnDisable() {
        playerDetector.playerOnSightEvent -= Attack;
        health.onDie -= SetDead;
    }

    private void SetDead() {
        _enemyAI.stop = true;
        dead = true;
    }

    private void Attack() {
        if (!dead && lastAttackTime + attackCooldown < Time.time) {
            Debug.Log("SHEEEEEEES");
            lastAttackTime = Time.time;
            attackEvent.Invoke();
            StartCoroutine(StopPathFinding());
        }
    }

    private IEnumerator StopPathFinding() {
        if (dead) yield break;
        _enemyAI.stop = true;
        yield return new WaitForSeconds(stopTime);
        _enemyAI.stop = false;
    }

    private void PerformAttack() {
        Collider2D col = Physics2D.OverlapCircle(playerDetector.transform.position, attackRadius, targetLayer);
        if (col != null) {
            col.GetComponent<Health>().DealDamage();
        }
    }

    private void OnDrawGizmosSelected() {
        if (playerDetector != null) {
            Gizmos.DrawWireSphere(playerDetector.transform.position, attackRadius);
        }
    }

}
