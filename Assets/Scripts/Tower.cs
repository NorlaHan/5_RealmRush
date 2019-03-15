using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Tower : MonoBehaviour
{
    public enum WeaponType { bullet, laser, bazooka };

    [Header("State")]
    [SerializeField] GameObject weapon;
    [SerializeField] Transform targetEnemy;
    public Waypoint baseWaypoint;
    [Space(5f)]

    [Header("Attributes")]
    [SerializeField] WeaponType weaponType = WeaponType.bullet;
    [SerializeField] float attackRange = 30f;
    [SerializeField] WeaponBase[] armory;    
    [Space(5f)]

    [Header("Components")]
    [SerializeField] Transform objectToPan;
      

    void Start()
    {
        WeaponSelection();      // TODO Add weapon range change based on weapon type.
        if (!objectToPan)
        {
            Debug.LogWarning("objectToPan missing, auto grab by name");
            objectToPan = transform.Find("Tower_A_Top");
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        FireAtEnemy();
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyBase>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (var enemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
        //GetClosest(sceneEnemies);
    }

    private Transform GetClosestEnemy(Transform A,Transform B) {
        float distance2A = Vector3.Distance(transform.position, A.position);
        float distance2B = Vector3.Distance(transform.position,B.position);
        if (distance2A < distance2B){
            return A;
        }
        return B;
    }

    private void GetClosest(EnemyBase[] sceneEnemies)
    {
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (var testEnemy in sceneEnemies)
        {
            float originalDistance = Vector3.Distance(transform.position, closestEnemy.transform.position);
            float testDistance = Vector3.Distance(transform.position, testEnemy.transform.position);
            if (testDistance < originalDistance)
            {
                closestEnemy = testEnemy.transform;
            }
        }
        targetEnemy = closestEnemy;
    }

    private void FireAtEnemy()
    {
        //print(Vector3.Distance(targetEnemy.position, transform.position));
        if (targetEnemy && Vector3.Distance(targetEnemy.position, transform.position) <= attackRange)
        {
            objectToPan.LookAt(targetEnemy, Vector3.up);
            weapon.SetActive(true);
        }
        else
        {
            weapon.SetActive(false);
        }
    }

    private void WeaponSelection()
    {
        int index = 99;
        if (weaponType == WeaponType.bullet)
        {
            index = 0;
        }
        else if (weaponType == WeaponType.laser)
        {
            index = 1;
        }
        else if (weaponType == WeaponType.bazooka)
        {
            index = 2;
        }
        weapon = armory[index].gameObject;
        attackRange = armory[index].GetRange();
    }
}
