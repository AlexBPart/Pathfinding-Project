using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))] //adds Waypoint.cs automatically

public class EditorSnap : MonoBehaviour
{


    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void SnapToGrid() //gets grid size & position from Waypoint and snaps transform to those values
    {
        int gridSize = waypoint.GetGridSize();
        var gridPos = waypoint.GetGridPos();

        transform.position = new Vector3(
            waypoint.GetGridPos().x, 
            0f, 
            waypoint.GetGridPos().y
            );
    }

    private void UpdateLabel() //gets grid size and position from Waypoint and translates into coordinates
    {
        int gridSize = waypoint.GetGridSize();
        var gridPos = waypoint.GetGridPos();
        string labelText = GetComponentInChildren<TextMesh>().text = gridPos.x / gridSize + ", " + gridPos.y / gridSize;
        gameObject.name = labelText;
    }
}
