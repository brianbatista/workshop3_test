using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventMasterScript : MonoBehaviour
{
    [Header("Light that makes building the scene easier.")]
    public Light buildingLight;

    // Start is called before the first frame update
    void Awake()
    {
        buildingLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
