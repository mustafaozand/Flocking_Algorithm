using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolAgent : MonoBehaviour
{
    private School theSchool;
    public School TheSchool
    {
        get { return theSchool; }
    }
    
    [Range(1f, 10f)] public float agentRadius;
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

    public void Initialize(School school)
    {
        theSchool = school; 
    }
}
