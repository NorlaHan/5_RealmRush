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
    [SerializeField] GameObject attackEffect;

    GameObject particleParent;
    Transform hitPos;
    PlayerHealth playerHealth;

    public int GetDamage() {
        return damage;
    }

    public int GetScore() {
        return score;
    }

    void Start()
    {
        if (!GameObject.Find("SpawnedAtRuntime"))
        {
            particleParent = new GameObject("SpawnedAtRuntime");
        }
        else
        {
            particleParent = GameObject.Find("SpawnedAtRuntime");
        }
        if (!hitPos)
        {
            hitPos = transform.Find("hitPos");
        }
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {

    }


    public void ReachGoal() {
        GameObject FX = Instantiate(attackEffect, transform.position, Quaternion.identity);
        FX.transform.SetParent(particleParent.transform);
        Destroy(FX, FX.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision obj)
    {
        print(obj + " collision Hit");
    }

    private void OnTriggerEnter(Collider obj)
    {
        //print(obj + " trigger Hit");
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
            playerHealth.GetScore(score);
            GameObject FX = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            FX.transform.SetParent(particleParent.transform);
            Destroy(FX, FX.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
        else {
            hitEffect.GetComponent<ParticleSystem>().Play();
            hitEffect.GetComponent<AudioSource>().Play();
        }
    }
}
