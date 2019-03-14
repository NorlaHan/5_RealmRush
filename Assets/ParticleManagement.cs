using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagement : MonoBehaviour
{

    ParticleSystem particleSystem;
    float lifeTime;


    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        lifeTime = particleSystem.main.duration ;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (!particleSystem.main.loop && lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
