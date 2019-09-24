using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    [Header("Transform references")]
    public Transform rootBody;
    public Transform pitchBody;

    [Header("Speeds")]
    public float playerSpeed = 2;
    public float mouseSpeed = 2f;

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
        // pitch += mouseSpeed * Input.GetAxis("Mouse Y"); // TODO: Bugged way, make it this for workshop template
        pitch -= mouseSpeed * Input.GetAxis("Mouse Y");
        // Limit rotation
        pitch = Mathf.Clamp(pitch, -45f, 15f);

        // Apply different rotation
        pitchBody.localEulerAngles = new Vector3(pitch, 0, 0);
        rootBody.eulerAngles = new Vector3(0, yaw, 0);

        // Movement
        Vector3 moveDirection = rootBody.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= playerSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
