using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera playerCam;

    [SerializeField] private Transform bulletOrigin;

    [SerializeField] private KeyCode triggerKey = KeyCode.Mouse0;

    [SerializeField] private float shootDistance = 30f;

    [SerializeField] private List<string> enemyTags = new List<string>(new string[] {"Zombie"});

    void Start()
    {
        if (bulletOrigin == null) {
            bulletOrigin = transform;
        }
    }

    void Update()
    {
        /*
        If the trigger key is pressed ( .GetKeyDown(key) ) (Unity Scripting Docs)
            and if a raycast from bulletOrigin hits something ( Physics.Raycast(...) ) (Unity Scripting Docs)
                and the thing it hit has a tag contained within the enemyTags list ( .Contains(tag) ) (Google)
                    then destroy the parent of the hit GameObject
        */

        if (Input.GetKeyDown(triggerKey)) {
            RaycastHit raycastHit;

            Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out raycastHit, shootDistance))
            {
                if (enemyTags.Contains(raycastHit.transform.tag))
                {
                    Destroy(raycastHit.transform.parent.gameObject);
                }
            }
            /*if (Physics.Raycast(bulletOrigin.position, bulletOrigin.forward, out raycastHit, shootDistance)) {
                if (enemyTags.Contains(raycastHit.transform.tag)) {
                    Destroy(raycastHit.transform.parent.gameObject);
                }
            }*/
        }
    }
}