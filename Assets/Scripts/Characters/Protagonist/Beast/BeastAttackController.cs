using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastAttackController : MonoBehaviour
{
    public StatsSO statsSO;
    private Protagonist _protagonist;
    private InputReader _inputReader;
    public float attackRadius = 1f;
    public Transform attackPoint;
    public LayerMask targetLayers;

    private void Awake() {
        _protagonist = GetComponent<Protagonist>();
        _inputReader = _protagonist.inputReader;
    }

    private void OnEnable() {
        _inputReader.attackEvent.OnEventRaised += Attack;
    }

    private void OnDisable() {
        _inputReader.attackEvent.OnEventRaised -= Attack;
    }

    public void Attack() {
        Debug.Log("Attacked!");
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
