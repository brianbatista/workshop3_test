using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // Note: this assumes we will only ever have one player in our game, and would break if we wanted to add multiplayer :(
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);
        }
    }
}
