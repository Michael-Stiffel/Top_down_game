using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Arrow : MonoBehaviour
{

    public GameObject hiteffect;
    public GameObject Self;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Gem gem = hitInfo.GetComponent<Gem>();
        if (gem != null)
        {
            return;
        }
       if (enemy != null)
       {
           enemy.TakeDamage(damage);
       }
        GameObject effect =Instantiate(hiteffect, transform.position, Quaternion.identity);
            
        Destroy(effect,1f);
        Destroy(gameObject);
    }

    
}
