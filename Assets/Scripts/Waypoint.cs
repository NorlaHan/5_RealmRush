using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [SerializeField] Color exploredColor = Color.cyan;

    private TowerFactory towerFactory;

    // public ok here as is a data class
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Waypoint exploredFrom;
    
    Vector3Int gridPos = new Vector3Int(0,0,0);
    const int gridSize = 10;
      
    
    public int GetGridSize() {
        return gridSize;
    }

    public Vector3Int GetGridPos() {        // This is not the real vector
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPos.y = Mathf.RoundToInt(transform.position.y / gridSize);
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize);
        return gridPos;
    }

    public void SetTopColor(Color color) {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }


    // Use this for initialization
    void Start () {
        towerFactory = FindObjectOfType<TowerFactory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isExplored && exploredFrom)
        {
            SetTopColor(exploredColor);
        }
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                towerFactory.AddTower(this);
            }else {
                print("Can't touch this.");
            }
        }
    }



}
