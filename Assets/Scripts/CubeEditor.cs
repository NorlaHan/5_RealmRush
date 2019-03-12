using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

	//[SerializeField][Range(5,15)] int gridSize = 10;
    Vector3 gridPos;
    Waypoint waypoint;

    void Awake() 
	{
        //print(name + ", awake");
        waypoint = GetComponent<Waypoint>();
	}
	void Start () {
		//print(name + ", start");
		
	}
	
	void Update ()
    {
        //print(name + ", updated");
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        if (!waypoint & GetComponent<Waypoint>()) {
            waypoint = GetComponent<Waypoint>();
        }
        int gridSize = waypoint.GetGridSize();
        gridPos = waypoint.GetGridPos();
        transform.position = gridPos * gridSize;
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string lableText = gridPos.x.ToString() + " , " + gridPos.z.ToString();
        textMesh.text = lableText;
        gameObject.name = "(" + lableText + ")";
    }
}
