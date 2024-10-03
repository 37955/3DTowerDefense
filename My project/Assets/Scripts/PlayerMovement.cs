using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 2f;
    bool canJump = true;
    float jumpForce = 5f;
    [SerializeField]
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);

        //output to log the position change

        //if raycast = true
        // canjump = true


    }
    private void FixedUpdate()
    {
        int layerMask = 1 << 3;
        layerMask = ~layerMask;
        if (Input.GetButton("Jump") && canJump)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            canJump = false;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f, layerMask))
        {
            Debug.Log(hit.transform.gameObject.layer);
            canJump = true;

        }
    }
}