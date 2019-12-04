using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    //This script is attached to all four of the spawnable game objects
    //It detects if the player has pressed "r" to reset
    //If so, this game object destroys itself


    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            demo_manager.spawnCount = 0;
            Destroy(gameObject);
        }
    }
}
