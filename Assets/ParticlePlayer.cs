using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour{
    [SerializeField] private Transform spawnPoint;
    public void PlayParticle(ParticleSystem particle){
        ParticleSystem spawnedParticle = Instantiate(particle, spawnPoint);
        spawnedParticle.Play();
    }

    public void PlayerParticleInPosition(ParticleSystem particleSystem, Vector3 position){
        ParticleSystem spawnedParticle = Instantiate(particleSystem, position,Quaternion.identity);
        spawnedParticle.Play();
    }
}
