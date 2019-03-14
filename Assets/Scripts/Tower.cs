using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum WeaponType { bullet, laser, bazooka };

    [SerializeField] GameObject weapon;
    [Space(5f)]

    [Header("Attributes")]
    [SerializeField] WeaponType weaponType = WeaponType.bullet;
    [SerializeField] float attackRange = 30f;
    [SerializeField] WeaponBase[] armory;    
    [Space(5f)]

    [Header("Components")]
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;    

    void Start()
    {
        WeaponSelection();      // TODO Add weapon range change based on weapon type.
    }

    // Update is called once per frame
    void Update()
    {
        FireAtEnemy();
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
