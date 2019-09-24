using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class allows all the zombies to quickly have a reference to the player
// Note: this assumes we will only ever have one player in our game, and would break if we wanted to add multiplayer :(
public class Player : MonoBehaviour
{
    // "static" means we can can access this field by only knowing the class name ("Player"), instead of needing an object instance.
    public static Player Instance;

    // Awake is always called before Start (when the scene is loaded), so if we set this up in Awake,
    // then other scripts can reference Player.Instance in their Start methods.
    private void Awake()
    {
        Instance = this;
    }
}
