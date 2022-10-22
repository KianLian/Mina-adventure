using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } = null;

    private static GameObject _player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void PickUpPlayer()
    {
        //TODO
    }
   
    //don't know why the @ but it seems cool.
    public static bool AddPlayer(GameObject @object)
    {
        if (!@object.CompareTag("Player"))
            return false;
        
        _player = @object;
        return true;

    }
}
