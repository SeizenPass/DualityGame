using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public StatsSO statsSO;
    private int currentHealth;
    public event UnityAction onHurt = delegate {};
    public event UnityAction onHeal = delegate {};
    public event UnityAction onDie = delegate {};
    private void Awake() {
        currentHealth = statsSO.maxHealth;
    }

    public void DealDamage(int dmg = 1) {
        Debug.Log("UGH");
        currentHealth -= dmg;
        onHurt.Invoke();
        if (currentHealth < 0) {
            onDie.Invoke();
            currentHealth = 0;
        } 
    }

    public void Heal(int amount = 1) {
        currentHealth += amount;
        onHeal.Invoke();
        if (currentHealth > 0) {
            currentHealth = statsSO.maxHealth;
        }
    }

    public bool IsDead() => currentHealth <= 0;
}
