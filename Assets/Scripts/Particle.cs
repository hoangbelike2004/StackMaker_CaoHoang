using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem1;
    [SerializeField] ParticleSystem ParticleSystem2;


    private void OnEnable()
    {
        RemoveStack.ParticleEvent += StartParticle;
    }
    private void OnDisable()
    {
        RemoveStack.ParticleEvent -= StartParticle;
    }

    void StartParticle()
    {
        ParticleSystem1.Play();
        ParticleSystem2.Play();
    }
}
