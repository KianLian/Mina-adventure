using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType
{
    Gt_Money,
    Gt_Powerup,

}

public abstract class Collectible : MonoBehaviour
{

    protected bool bCanBePicked = false;
    [SerializeField]
    protected CollectibleType type;

    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {

        }
            //PickUp();
    }
}
