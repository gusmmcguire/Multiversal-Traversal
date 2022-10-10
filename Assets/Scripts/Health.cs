using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathPrefab;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] int maxHealth = 100;
    [SerializeField] bool destroyRoot = false;
    [SerializeField] AudioClip hurtSound;


    public int health { get; set; }
    bool isDead = false;

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(int damage) {
        
        health -= damage;       

        if (!isDead && health <= 0) {
            isDead = true;
            if (TryGetComponent<IDestructable>(out IDestructable destructable)) {
                destructable.Destroyed();
            }

            if (deathPrefab != null) {
                Instantiate(deathPrefab, transform.position, transform.rotation);
            }

            if (destroyOnDeath) {
                if (destroyRoot) Destroy(gameObject.transform.root.gameObject);
                else Destroy(gameObject);
            }
        }
        else if (hurtSound)
        {
            AudioManager.Instance.PlaySFX(hurtSound);
        }
    }
}
