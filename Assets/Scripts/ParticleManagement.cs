using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagement : MonoBehaviour
{

    ParticleSystem thisParticleSystem;
    float lifeTime;


    // Start is called before the first frame update
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
        lifeTime = thisParticleSystem.main.duration ;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //lifeTime -= Time.deltaTime;
        //if (!particleSystem.main.loop && lifeTime <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
}
