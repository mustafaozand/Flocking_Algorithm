using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class School : MonoBehaviour
{
    private List<SchoolAgent> schoolAgents = new List<SchoolAgent>();
    public float spawnRadius = 10;
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
            // My flock agents are instantiated into my scene, within my given spawnRadius, at a random location, then these are added to a list of school agents
            SchoolAgent newBoid = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * spawnRadius,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), // Rotation at which each flock agent spawns is random.
                transform);

            newBoid.name = "Agent" + boid;
            newBoid.Initialize(this);
            schoolAgents.Add(newBoid);
        }
    }
    
    // Iterates through the list of flock agent objects and determines if the agent is nearby (is the offset of the neighbouring agent within the radius of the current agent.
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
            Vector2 move = behaviour.CalculateMove(agentPrefab, context, this);
            move *= driveFactor;
            
            // Checks if the velocity has exceeded the maxSpeed, if so the speed is normalised then multiplied to my maxSpeed
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed; 
            }
            
            agent.Move(move);
            
            // testing
            
            // agent.GetComponentInChildren<SpriteRenderer>().color =
            //     Color.Lerp(Color.white, Color.red, context.Count / 6f);
                

        }
    }
    
    


}
