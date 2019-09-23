using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    [Header("First Person Camera")]
    public Camera fpCamera;

    [Header("Player's Speed")]
    public float playerSpeed = 2;
    [Header("Gravity")]
    public float gravity = 20f;
    [Header("Mouse Look Speed")]
    public float mouseSpeed = 2f;

    [Space]

    // Private Variables
    private CharacterController characterController;
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
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");
        // Limit rotation
        pitch = Mathf.Clamp(pitch, -45f, 30f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Movement
        Vector3 moveDirection = fpCamera.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= playerSpeed;
        characterController.Move(moveDirection * Time.deltaTime);

    }
}
