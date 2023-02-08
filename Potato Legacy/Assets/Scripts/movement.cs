using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float JumpForce;
    public Transform GroundCheck;
    Transform PlayerModel;
    public LayerMask Ground;
    public soundmanager soundmanager;
    public AudioClip jump;
    

    Rigidbody rb;
    inputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<inputManager>();
        PlayerModel = transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0 , rb.velocity.y, inputManager.horizontal * speed);

        PlayerModel.eulerAngles += new Vector3 (0, 0, inputManager.horizontal * rotationSpeed);

    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);

            soundmanager.playSound(jump);
        }


    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, 0.2f, Ground);

    }
}
