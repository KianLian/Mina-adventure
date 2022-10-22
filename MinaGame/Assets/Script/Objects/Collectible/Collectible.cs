using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public enum CollectibleType
{
    GtMoney,
    GtPowerUp,
    GtStamina,
}

public abstract class Collectible : MonoBehaviour
{

    // protected bool bCanBePicked = false;

    [SerializeField]
    protected CollectibleType type;

    protected ParticleSystem particleSystem = null;
    
    protected virtual void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
           // GameManager.instance.PickUpPlayer();
        }
          
    }


}
