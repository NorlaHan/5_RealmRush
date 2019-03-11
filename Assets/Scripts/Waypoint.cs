using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector3Int gridPos;
    const int gridSize = 10;

    //public bool isStartPoint = false, isEndPoint = false;


    public int GetGridSize() {
        return gridSize;
    }

    public Vector3Int GetGridPos() {
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPos.y = Mathf.RoundToInt(transform.position.y / gridSize);
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize);
        return gridPos;
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //if (isStartPoint)
        //{
        //    topMeshRenderer.material.color = Color.green;
        //}
        //else if (isEndPoint)
        //{
        //    topMeshRenderer.material.color = Color.red;
        //}
        //else
        //{            
        //    topMeshRenderer.material.color = color;
        //}
        topMeshRenderer.material.color = color;
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
