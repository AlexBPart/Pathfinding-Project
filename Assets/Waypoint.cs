using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;

    const int gridSize = 10;

    void Start()
    {
        
    }

    public int GetGridSize() //returns the grid size
    {
        return gridSize;
    }

    public Vector2Int GetGridPos() //returns the grid position
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>(); //gets the mesh renderer of linked object named "Top"
        topMeshRenderer.material.color = color; //set the material colour to "color"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
