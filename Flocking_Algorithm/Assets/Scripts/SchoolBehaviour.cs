using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SchoolBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMove(SchoolAgent agent, List<Transform> context, School school);
}
