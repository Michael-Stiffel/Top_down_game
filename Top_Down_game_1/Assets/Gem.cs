using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int xpValue;
    public GameObject pickUpEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        xpValue = 1;
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player charakterStats = col.GetComponent<Player>();

        if (charakterStats != null)
        {
            charakterStats.getXp(xpValue);
            
            GameObject effect =Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }
}
