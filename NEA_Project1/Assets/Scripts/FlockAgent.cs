using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgent : MonoBehaviour
{
    private Flock theFlock;
    public Flock TheFlock
    {
        get { return theFlock; }
    }
    
    private float agentRadius;
    private Vector2 agentPosition;
    private Collider2D agentCollider;


    void Awake()
    {
        Vector2 agentPosition = transform.position; 
    }
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock)
    {
        theFlock = flock; 
    }
}
