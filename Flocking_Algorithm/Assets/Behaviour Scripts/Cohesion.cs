using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "School/SchoolBehavior/Cohesion")]
public class Cohesion : SchoolBehaviour
{
    public override Vector2 CalculateMove(SchoolAgent agent, List<Transform> context, School school)
    {
        // Checks if the context array is empty, if so then returns vector 0, as there are no neighbouring flock agents
        if (context.Count == 0)
        {
            return Vector2.zero;
        }
        // Iterates through the context array, and calculates the average position of the local flockmate

        Vector2 totalOfVectors = Vector2.zero;
        
        foreach (Transform neighbour in context)
        {
            totalOfVectors += (Vector2)neighbour.transform.position; 
        }


        Vector2 avgPosition = totalOfVectors / (context.Count);
        
        // Create an offset from the vector position, rather than the global position. 

        avgPosition -= (Vector2)agent.transform.position;

        return avgPosition; 
    }
}
