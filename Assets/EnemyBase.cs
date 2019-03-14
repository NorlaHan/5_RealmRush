using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // Status
    [Header("Attributes")]
    [SerializeField] int hitPoint = 3;
    [SerializeField] int damage;
    [SerializeField] int score;
    [Space(10)]

    [Header("Effects")]
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject explosionEffect;

    GameObject parent;

    void Start()
    {
        if (!GameObject.Find("SpawnedAtRuntime"))
        {
            parent = new GameObject("SpawnedAtRuntime");
        }
        else
        {
            parent = GameObject.Find("SpawnedAtRuntime");
        }
    }

    void Update()
    {

    }


    // Hit point system

    // Projectile collide with the enemy
    // Damage effect trigger
    private void OnCollisionEnter(Collision obj)
    {
        print(obj + " collision Hit");
    }

    private void OnTriggerEnter(Collider obj)
    {
        print(obj + " trigger Hit");
    }

    private void OnParticleCollision(GameObject obj)
    {
        //print(obj + " particle hit " + name);
        WeaponBase weapon = obj.GetComponent<WeaponBase>();
        if (weapon.GetFaction() == WeaponBase.Faction.player || weapon.GetFaction() == WeaponBase.Faction.neutral)   // Avoid friendly fire.
        {
            TakeDamage(weapon);
        }
        
    }

    private void TakeDamage(WeaponBase weapon)
    { 
        hitPoint -= weapon.GetDamage();
        if (hitPoint <= 0)
        {
            // Die event
            GameObject FX = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            FX.transform.SetParent(parent.transform);
            Destroy(gameObject);
        }
        else {
            // Damage event
            GameObject FX = Instantiate(hitEffect, transform.Find("HitPos").position, Quaternion.identity);
            FX.transform.SetParent(parent.transform);
        }
    }
}
