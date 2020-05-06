using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script attaches to the Waypoint parent object "World". Its job is understanding the location and pathing of all Waypoint Blocks.

public class Pathfinder : MonoBehaviour
{
    Waypoint waypoint;
    [SerializeField] Waypoint startPoint, endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>(); //creates an index of Waypoints. Waypoints can be looked up by their coordinates (Vector2Int). Index is called "grid".
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    

    void Start()
    {
        StartEndColor();
        LoadBlocks();
        ExploreNeighbours();

    }

    private void ExploreNeighbours()
    {
        
        foreach (Vector2Int direction in directions)
        {
            print("Exploring " + startPoint.GetGridPos() + direction);
        }
    }

    private void LoadBlocks() //loads blocks into the dictionary and logs a warning if any are overlapping
    {
        var waypoints = FindObjectsOfType<Waypoint>();        //finds all objects with Waypoint script
        foreach (Waypoint waypoint in waypoints)              //for each individual waypoint object in waypoints
        {
            var gridPos = waypoint.GetGridPos();             //fetches GetGridPos from Waypoint.cs and defines variable gridPos
            if (grid.ContainsKey(gridPos))                   //IF that Key already contains the gridPos value, then...
            {
                Debug.LogWarning("Overlapping block " + waypoint);  //...log a console warning that two waypoint blocks are overlapping, OTHERWISE...
            }
            else
                grid.Add(gridPos, waypoint);                     //...create a dictionary entry for the waypoint object findable by coordinates.
            //waypoint.SetTopColor(Color.black);

        }

    }

    private void StartEndColor()
    {
        startPoint.SetTopColor(Color.black);
        endPoint.SetTopColor(Color.red);
    
    }

}
