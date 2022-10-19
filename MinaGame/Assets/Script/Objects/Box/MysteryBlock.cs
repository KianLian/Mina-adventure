using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MysteryBlock : MonoBehaviour
{


    private GameObject objectGifted;

    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player") && otherCollider.contacts[0].normal.y > 0.5f)
        {
            //TODO
        }
    }

    void ChooseRandomlyAType()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
