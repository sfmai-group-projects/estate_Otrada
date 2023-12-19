using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    public Rigidbody rb;


    public float speed = 1.0f;
    public float mouseSense = 100.0f;

    private float mouseX;
    private float mouseY;

    float xrotation = 0f;
    float yrotation = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rb.MovePosition(transform.position + Vector3.ClampMagnitude(Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right, 1) * speed);


        xrotation -= Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        xrotation = Mathf.Clamp(xrotation, -45f, 45f);
        yrotation += Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        playerCamera.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        player.localRotation = Quaternion.Euler(0f, yrotation, 0f);
    }
}
