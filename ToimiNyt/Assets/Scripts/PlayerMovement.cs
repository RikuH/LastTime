using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    float normalCenter = 0.79f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        CrouchSystem();

        if (GetComponent<CharacterAnimation>().isCrouching == false)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void CrouchSystem()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            GetComponent<CharacterAnimation>().isCrouching = true;
            controller.center = new Vector3(0, 1.20f, 0); //Needed to hard code this because hurry... :(
        }
        else
        {
            GetComponent<CharacterAnimation>().isCrouching = false;
            controller.center = new Vector3(0, normalCenter, 0);
        }
    }
}
