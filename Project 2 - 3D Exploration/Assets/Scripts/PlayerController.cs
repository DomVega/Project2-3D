using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpStr = 4f;

    private Rigidbody rigidBody;
    private CapsuleCollider collider;
    private Vector3 moveDirection;
    private Vector3 velocity;
    private float x;
    private float z;
    
   
    // Start is called before the first frame update
    void Start()
    {
      rigidBody = GetComponent<Rigidbody>(); 
      collider = GetComponent<CapsuleCollider>();

    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //moveDirection = x * transform.right + z * transform.forward
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        moveDirection = x * transform.right + z * transform.forward;
        if (isGrounded() && Input.GetKeyDown("space"))
        {
            rigidBody.AddForce(Vector3.up * jumpStr, ForceMode.VelocityChange);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + .3f);
    }

    void Move()
    {
        Vector3 yVel = new Vector3 (0f, rigidBody.velocity.y, 0f);
        rigidBody.velocity = moveDirection * moveSpeed * Time.deltaTime;
        rigidBody.velocity += yVel;
    }
        
}
