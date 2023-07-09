using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathEffekt;
    public int nextLevel = 10;
    public int currentxp;
    public int currentLevel; 

    public Healthbar_scrript healthbar;
    public ExpLeiste xpleiste;
    public Weapon_script weapon;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        currentxp = 0;
        currentLevel = 1; 
        xpleiste.SetnextLevel(nextLevel);
        xpleiste.SetLevel(currentLevel.ToString());

    }

    // Update is called once per frame
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
           
            Die();
        }
    }

    void Die()
    {
        
        Instantiate(deathEffekt, transform.position, Quaternion.identity);
        Destroy(gameObject);
        DestroyImmediate(weapon,true);
        DestroyImmediate(gameObject,true);
        Destroy(deathEffekt,1f);
        


    }

    public void getXp(int xp)
    {
        currentxp += xp;
        xpleiste.setxp(currentxp);

        if (currentxp >= nextLevel)
        {
            nextLevel = nextLevel * 2;
            currentxp = 0;
            currentLevel += 1;
            xpleiste.SetnextLevel(nextLevel);
            xpleiste.SetLevel(currentLevel.ToString());
        }
    }
}
