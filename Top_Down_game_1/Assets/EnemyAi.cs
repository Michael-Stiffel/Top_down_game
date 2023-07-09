using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAi : MonoBehaviour
{



    public Transform target ;
   
    public float speed = 10f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachEndOfPath = false;

    private Seeker seeker;

    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target =  GameObject.FindWithTag("Player").transform;
        
        InvokeRepeating("UpadtePath",0f, 1f);

        
    }


    // ReSharper disable Unity.PerformanceAnalysis
    void UpadtePath()
    {   
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return; 
        }
        else
        {
            reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]- rb.position).normalized;
        Vector2 force = direction * (speed * Time.deltaTime);
        
        rb.AddForce(force);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
