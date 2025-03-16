using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : MonoBehaviour
{
    private List<SchoolAgent> schoolAgents;
    private float spawnRadius;
    private SchoolAgent agent;

    [Range(10f, 50f)] public int populationSize;
    [Range(1f, 100f)] private float maxSpeed;

    void Start()
    {
        for (int boid = 0; boid < populationSize; boid++)
        {
            SchoolAgent newBoid = Instantiate(
                agent,
                Random.insideUnitCircle * populationSize,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            newBoid.name = "Agent" + boid;
            newBoid.Initialize(this);
            schoolAgents.Add(newBoid);
        }
    }


}
