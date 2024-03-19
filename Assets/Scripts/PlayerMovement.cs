using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //private Vector2 input;
    //private Vector3 direction;

    public float speed = 10f;

    [SerializeField]
    private float jumpForce = 10f;

    //private void Awake()
    //{
    //    controller = GetComponent<CharacterController>();
    //}

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //controller.Move(direction * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            controller.attachedRigidbody.AddForce(0f, jumpForce, 0f);
        }

        if (controller.isGrounded)
        {
            Debug.Log("Grounded");
        }
    }

    //public void Move(InputAction.CallbackContext context)
    //{
    //    input = context.ReadValue<Vector2>();
    //    direction = new Vector3(input.x, 0f, input.y);
    //}
}