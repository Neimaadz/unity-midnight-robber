using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpForce = 4f;      // Force applied when jumping

    [SerializeField]
    private float groundCheckDistance = 0.2f;  // Distance to check for ground

    [SerializeField]
    private LayerMask groundLayer;      // Layer mask for ground detection

    private Vector3 lastPosition;
    private bool isGrounded = false;    // Flag to track if player is grounded
    private Rigidbody rb;               // Player's Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var currentPosition = this.gameObject.transform.position;
        var velocity = Vector3.Distance(currentPosition, lastPosition);
        GetComponent<Animator>().SetFloat("forwardSpeed", 0);
        GetComponent<Animator>().SetFloat("runRightSpeed", 0);
        GetComponent<Animator>().SetFloat("runLeftSpeed", 0);
        GetComponent<Animator>().SetFloat("strafeRight", 0);
        GetComponent<Animator>().SetFloat("strafeLeft", 0);
        GetComponent<Animator>().SetFloat("backwardSpeed", 0);
        GetComponent<Animator>().SetFloat("backwardRightSpeed", 0);
        GetComponent<Animator>().SetFloat("backwardLeftSpeed", 0);

        // Run FORWARD, FORWARD Right, FORWARD Left
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                GetComponent<Animator>().SetFloat("runRightSpeed", velocity);
                this.gameObject.transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            {
                GetComponent<Animator>().SetFloat("runLeftSpeed", velocity);
                this.gameObject.transform.Translate(new Vector3(-1, 0, 1) * Time.deltaTime * speed);
            }
            else
            {
                GetComponent<Animator>().SetFloat("forwardSpeed", velocity);
                this.gameObject.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            }
        }
        // Run BACKWARD, BACKWARD Right, BACKWARD Left
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                GetComponent<Animator>().SetFloat("backwardRightSpeed", velocity);
                this.gameObject.transform.Translate(new Vector3(1, 0, -1) * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            {
                GetComponent<Animator>().SetFloat("backwardLeftSpeed", velocity);
                this.gameObject.transform.Translate(new Vector3(-1, 0, -1) * Time.deltaTime * speed);
            }
            else
            {
            GetComponent<Animator>().SetFloat("backwardSpeed", velocity);
            this.gameObject.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
            }
        }
        // Run RIGHT, Run LEFT
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //this.gameObject.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed * speed);
                GetComponent<Animator>().SetFloat("strafeRight", velocity);
                this.gameObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            {
                //this.gameObject.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationSpeed * speed);
                GetComponent<Animator>().SetFloat("strafeLeft", velocity);
                this.gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            }
        }

        lastPosition = currentPosition;
    }

    private void Jump()
    {
        // Check if the player is grounded (need to set Layer to object ground in unity to detect)
        isGrounded = Physics.Raycast(this.gameObject.transform.position, Vector3.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply upward force to simulate jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Trigger jump animation
            GetComponent<Animator>().SetTrigger("jump");
        }

        GetComponent<Animator>().SetBool("isJumping", !isGrounded);
    }
}
