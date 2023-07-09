using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject Arrow_Prefab;

    public float arrowspeed = 20f;

    public float Firerate = 0.1f;
    private float NextFire;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + Firerate;
            Shoot();
            
            
        }
    }

    void Shoot()
    {
        GameObject a_arrow= Instantiate(Arrow_Prefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = a_arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * arrowspeed, ForceMode2D.Impulse);
        

    }
}
