using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeastAttackController : MonoBehaviour
{
    public StatsSO statsSO;
    private Protagonist _protagonist;
    private InputReader _inputReader;
    public float attackRadius = 1f;
    public Transform attackPoint;
    public LayerMask targetLayers;
    public event UnityAction attackEvent = delegate {};

    private void Awake() {
        _protagonist = GetComponent<Protagonist>();
        _inputReader = _protagonist.inputReader;
    }

    private void OnEnable() {
        _inputReader.attackEvent.OnEventRaised += OnAttack;
    }

    private void OnDisable() {
        _inputReader.attackEvent.OnEventRaised -= OnAttack;
    }

    public void OnAttack() {
        attackEvent.Invoke();
    }

    public void Attack() {
        Collider2D[] cols = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, targetLayers);
        foreach (var item in cols)
        {
            Health h;
            if (item.TryGetComponent<Health>(out h)) {
                h.DealDamage(statsSO.damage);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint != null) {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}
