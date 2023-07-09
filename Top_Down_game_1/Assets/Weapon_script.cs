using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon_script : MonoBehaviour
{
    public  Vector2 position;
    public Rigidbody2D player_body;
    public Rigidbody2D weapon_body;
    public Vector2 mousePos;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        position.x = (player_body.position.x ) ;
        position.y = (player_body.position.y -0.2f) ;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void FixedUpdate()
    {
        

        Vector2 lookDir = mousePos - player_body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        weapon_body.rotation = angle;
        weapon_body.MovePosition(lookDir.normalized * 1 + position); 
    }
}
