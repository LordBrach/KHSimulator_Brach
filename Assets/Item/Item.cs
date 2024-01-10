using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] SphereCollider itemCollider;
    [SerializeField] ParticleSystem potionParticles;
    [SerializeField] MeshRenderer potionVisuals;

    private void Start()
    {
        float totalDuration = potionParticles.main.duration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(itemCollider != null && other.gameObject.CompareTag("Player"))
        {
            this.potionVisuals.enabled = false;
            ItemEffect(other.gameObject);
            if(potionParticles)
            {
                Instantiate(potionParticles, transform.position, transform.rotation);
                potionParticles.Play(true);
            }
            Destroy(transform.gameObject);
        }
    }

    public abstract void ItemEffect(GameObject go);
}
