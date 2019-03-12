using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    PathFinder pathFinder;
    List<Waypoint> path;

    //[SerializeField] List<Waypoint> pathBlocks;
    // Use this for initialization
    void Start () {
        pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
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
