using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // The [SerializeField] annotation can be used to make a "private" field editable in the Unity editor, while still hiding it from other scripts
    [SerializeField] private float rotationSpeed = 90f;

    // [Range(min, max)] can be used to specify a valid input range (only validated in the editor, other scripts can set it to anything)
    [SerializeField, Range(0, 100)] private float movementSpeed = 2f;
    [SerializeField] private float delay = 2f;

    private Player playerRef;

    private CharacterController characterController;

    void Start()
    {
        playerRef = Player.Instance;
        characterController = GetComponent<CharacterController>();

        StartCoroutine(zombieWalk());
    }

    IEnumerator zombieWalk()
    {
        yield return new WaitForSeconds(delay);

        while (isActiveAndEnabled) {
             // Target could be easily swapped to something else! ;) ;) *nudge nudge* ;) ;)
            Vector3 target = playerRef.transform.position; // Destination position
            Vector3 hereToTarget = target - transform.position; // Vector from zombie to target (player)
            Quaternion requiredRotation = Quaternion.LookRotation(hereToTarget, Vector3.up); // Where the zombie needs to eventually look
            float alignmentWithTarget = Mathf.Max(0f, Vector3.Dot(hereToTarget.normalized, transform.forward));

            // Rotate a little bit towards where we want to look, with a maximum angle change of up to "rotationDegrees" degrees per second.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotationSpeed * Time.deltaTime);
            // .normalized will return a unit vector, which we can scale to define a move speed. Time.deltaTime is used to smooth it out
            characterController.Move(hereToTarget.normalized * movementSpeed * alignmentWithTarget * Time.deltaTime);

            // Wait until the next frame
            yield return null;
        }
    }
}
