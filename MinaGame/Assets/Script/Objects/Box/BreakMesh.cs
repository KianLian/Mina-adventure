using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BreakMesh : MonoBehaviour
{

    public System.Action<List<GameObject>> OnFragmentsGenerated;

    [SerializeField]
    private bool bCanBeFragmented;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
