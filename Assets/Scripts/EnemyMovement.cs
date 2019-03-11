using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Waypoint> pathBlocks;
	// Use this for initialization
	void Start () {
        //PrintAllWaypoints();
        //InvokeRepeating("PrintAllWaypoints", 0f, 1f);
        StartCoroutine(FollowPath());
        print("Back to start");
    }

    IEnumerator FollowPath(){
        print("Starting patrol...");
        foreach (Waypoint waypoint in pathBlocks)
        {      
            print("Visting " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
            // call a second
        }
        print("Ending patrol");
    }

    void PrintHello() {
        print("Hello");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
