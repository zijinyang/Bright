using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingController : MonoBehaviour
{
    [SerializeField] Transform target;
    AILerp agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AILerp>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
