using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem ghost_particles;
    public GameObject lemon;

    // Start is called before the first frame update
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lemon.transform.position, transform.position) <= 5.0f)
        {
            Debug.Log("IN RANGE");
            ghost_particles.Play();            
            var em = ghost_particles.emission;
            em.enabled = true;
        }

        
        /*else
        {
            Debug.Log("OUT OF RANGE");
            ghost_particles.Stop();   
        }*/

    }
}
