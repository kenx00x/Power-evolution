using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMover : MonoBehaviour
{
    //Gaat naar waypoints
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;

    private Transform currentWaypoint;
    [SerializeField] private float distanceThreshold = 0.1f;

    void Start()
    {
        // eerste waypoint
        currentWaypoint = waypoints.GetNewWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // volgende waypoint
        currentWaypoint = waypoints.GetNewWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

    }

   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) {
            currentWaypoint = waypoints.GetNewWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);

        }

    }
}
