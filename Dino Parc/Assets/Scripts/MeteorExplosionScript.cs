using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeteorExplosionScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem meteorExplosion;
    [SerializeField] private AudioSource explosionSound;
    private List<ParticleCollisionEvent> collisionEvents;


    void Start()
    {
        meteorExplosion = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = meteorExplosion.GetCollisionEvents(other, collisionEvents);
        int i = 0;

        while (i < numCollisionEvents)
        {
            GameObject.Destroy(Instantiate((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Particles/Explosion.prefab", typeof(GameObject)), collisionEvents[i].intersection, Quaternion.LookRotation(transform.up)), 8f);
            explosionSound.Play();
            i++;
        }
    }
}
