using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower[] towerPrefabs = new Tower[1];

    Queue<Tower> towerQueue = new Queue<Tower>();

    private GameObject towers;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!towers)
        {
            towers = GameObject.Find("Towers");
        }else {
            towers = new GameObject("Towers");
        }
    }

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimit)
        {            
            Tower towerSpawned = Instantiate(towerPrefabs[0], baseWaypoint.transform.position, Quaternion.identity);
            towerSpawned.transform.SetParent(towers.transform);

            towerQueue.Enqueue(towerSpawned);
            baseWaypoint.isPlaceable = false;
            towerSpawned.baseWaypoint = baseWaypoint;
        }
        else {
            MoveExistingTower(baseWaypoint);
        } 
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);       
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
