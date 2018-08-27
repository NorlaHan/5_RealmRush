using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour {

	[SerializeField][Range(5,15)] int gridSize = 10;

	TextMesh textMesh;
	// Use this for initialization
	void Awake() 
	{
		print(name + ", awake");
	}
	void Start () {
		print(name + ", start");
		
	}
	
	// Update is called once per frame
	void Update () {
		print(name + ", updated");
		Vector3 snapPos;		

		snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize);
		snapPos.y = Mathf.RoundToInt(transform.position.y/gridSize);
		snapPos.z = Mathf.RoundToInt(transform.position.z/gridSize);
		transform.position = snapPos*gridSize;

		textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text =snapPos.x.ToString() +" , "+snapPos.z.ToString();
	}
}
