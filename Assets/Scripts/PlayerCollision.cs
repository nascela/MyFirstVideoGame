using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement Movement;
    private void OnCollisionEnter(Collision colInfo)
    {
        
        if (colInfo.collider.tag == "Obstacles")
        {
            Movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}
