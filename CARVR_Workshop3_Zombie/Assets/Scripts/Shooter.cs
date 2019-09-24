using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;

    [SerializeField] private KeyCode triggerKey = KeyCode.Mouse0;

    [SerializeField] private float shootDistance = 30f;

    [SerializeField] private string enemyTag = "Zombie";

    void Update()
    {
        /*
        If the trigger key is pressed ( .GetKeyDown(key) )
            and if a raycast from bulletOrigin hits something ( Physics.Raycast(...) )
                and the transform on the thing it hit has a tag passes a comparison against our enemyTag ( .CompareTag(tag) )
                    then destroy the parent of the hit GameObject
        */

        if (Input.GetKeyDown(triggerKey))
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out raycastHit, shootDistance))
            {
                if (raycastHit.transform.CompareTag(enemyTag))
                {
                    Destroy(raycastHit.transform.parent.gameObject);
                }
            }
        }
    }
}