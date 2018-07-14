using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour, IDamageable {

    protected float health;
    protected bool dead;
    public float startingHealth;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    { 
        health -= damage;

        if(health <=0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        // if문 없어도 되지 않나... 싶음
        GameObject.Destroy(gameObject);
    }
}
