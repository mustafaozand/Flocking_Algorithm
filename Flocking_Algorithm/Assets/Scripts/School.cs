using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class School : MonoBehaviour
{
    private List<SchoolAgent> schoolAgents = new List<SchoolAgent>();
    public float spawnRadius;
    [FormerlySerializedAs("agent")] public SchoolAgent agentPrefab;
    public SchoolBehaviour behaviour;

    [Range(10f, 50f)] public int populationSize;
    [Range(1f, 100f)] private float maxSpeed;
    [Range(1f, 100f)] public float driveFactor = 10f;

    public float squareMaxSpeed; 

    private void Awake()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        
    }

    void Start()
    {
        for (int boid = 0; boid < populationSize; boid++)
        {
            SchoolAgent newBoid = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * populationSize,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            newBoid.name = "Agent" + boid;
            newBoid.Initialize(this);
            schoolAgents.Add(newBoid);
        }
    }

    public List<Transform> GetNearbyObjects(SchoolAgent currentAgent)
    {
        List<Transform> context = new List<Transform>();
        float radiusSquared = (currentAgent.agentRadius) * (currentAgent.agentRadius);

        foreach (SchoolAgent neighbour in schoolAgents)
        {
            if (neighbour != currentAgent)
            {
                Vector2 offset = currentAgent.transform.position - neighbour.transform.position;
                float distanceSquared = offset.sqrMagnitude;

                
                if (distanceSquared <= radiusSquared)
                {
                    context.Add(neighbour.transform);
                }
            }
        }

        return context;
    }
    
    
    void Update()
    {
        foreach (SchoolAgent agent in schoolAgents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            agent.GetComponentInChildren<SpriteRenderer>().color =
                Color.Lerp(Color.white, Color.red, context.Count / 6f);
            //Vector2 velocity = behaviour.CalculateMove(agent, context, this);
            //velocity *= driveFactor;

            //if (velocity.sqrMagnitude > squareMaxSpeed)
            //{
            // velocity = velocity.normalized * maxSpeed; 
            // }

            //agent.Move(velocity);
        }
    }
    
    


}
