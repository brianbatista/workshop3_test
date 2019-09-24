using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Transform references")]
    public Transform rootBody; // Transform to move and rotate side to side
    public Transform pitchBody; // Transform to rotate up and down (the head)

    [Header("Speeds")]
    public float playerSpeed = 2f;
    public float mouseSpeed = 2f;

    // Private references
    private CharacterController characterController;
    // Private state
    private float yaw = 0f;
    private float pitch = 0f;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        //Camera Control
        yaw += mouseSpeed * Input.GetAxis("Mouse X");
        // pitch += mouseSpeed * Input.GetAxis("Mouse Y"); // TODO: Bugged way, make it this for workshop template
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");
        // Limit rotation
        pitch = Mathf.Clamp(pitch, -45f, 15f);

        // Apply different rotation
        pitchBody.localEulerAngles = new Vector3(pitch, 0, 0);
        rootBody.eulerAngles = new Vector3(0, yaw, 0);

        // Movement
        Vector3 moveDirection = rootBody.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 moveVector = moveDirection * playerSpeed * Time.deltaTime;
        characterController.Move(moveVector); //TODO uncomment this
    }
}
