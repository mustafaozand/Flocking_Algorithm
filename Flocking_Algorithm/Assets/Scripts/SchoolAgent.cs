using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SchoolAgent : MonoBehaviour
{
    private School theSchool;
    public School TheSchool
    {
        get { return theSchool; }
    }
    
    [Range(1f, 10f)] public float agentRadius = 1.5f;
    private Vector2 agentPosition;
    private Collider2D agentCollider;


    void Awake()
    {
        Vector2 agentPosition = transform.position; 
    }
    void Start()
    {
        agentCollider = GetComponent<CircleCollider2D>();
    }

    public void Initialize(School school)
    {
        theSchool = school; 
    }

    public void Move(Vector2 velocity)
    {
        if (velocity != Vector2.zero) // This if statement will prevent errors when velocity is zero.
        {
            transform.up = velocity.normalized; // Normalises to set the direction, back to original
        }
    
        transform.position += (UnityEngine.Vector3)(velocity) * Time.deltaTime;
    }
    
}
