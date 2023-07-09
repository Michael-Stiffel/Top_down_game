using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathEffekt;
    public GameObject dropedGem;
    public GameObject hiteffect;
    public GameObject Self;
    public int damage = 10;

    public Healthbar_scrript healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        Gem gem = hitInfo.GetComponent<Gem>();
        if (gem != null)
        {
            return;
        }
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        GameObject effect =Instantiate(hiteffect, transform.position, Quaternion.identity);
            
        Destroy(effect,1f);
    }
    void Die()
    {
        var position = transform.position;
        GameObject effect = Instantiate(deathEffekt, position, Quaternion.identity);
        Destroy(effect, 1f);
        Instantiate(dropedGem,position, Quaternion.identity);
        Destroy(gameObject);
        
        
    }
}