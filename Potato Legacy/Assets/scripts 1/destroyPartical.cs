using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;


public class destroyPartical : MonoBehaviour
{
    ParticleSystem particl;
    // Start is called before the first frame update
    void Start()
    {
        particl = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
    }
}
