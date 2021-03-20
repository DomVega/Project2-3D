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
    
    [SerializeField]
    GameObject LeverOneUp;
    [SerializeField]
    GameObject LeverOneDown;
    [SerializeField]
    GameObject LazerDoorOne;

    [SerializeField]
    GameObject LeverTwoUp;
    [SerializeField]
    GameObject LeverTwoDown;
    [SerializeField]
    GameObject LazerDoorTwo;

    [SerializeField]
    GameObject LeverThreeUp;
    [SerializeField]
    GameObject LeverThreeDown;
    [SerializeField]
    GameObject LazerDoorThree;

    private bool CloseToLeverOne;
    private bool CloseToLeverTwo;
    private bool CloseToLeverThree;

    private bool AtKeypad;

    //public Image keypadScreen;

    // Start is called before the first frame update
    void Start()
    {
      rigidBody = GetComponent<Rigidbody>(); 
      collider = GetComponent<CapsuleCollider>();

      LeverOneUp.gameObject.SetActive (true);
      LeverOneDown.gameObject.SetActive (false);
      LazerDoorOne.gameObject.SetActive (true);

      LeverTwoUp.gameObject.SetActive (true);
      LeverTwoDown.gameObject.SetActive (false);
      LazerDoorTwo.gameObject.SetActive (true);

      LeverThreeUp.gameObject.SetActive (true);
      LeverThreeDown.gameObject.SetActive (false);
      LazerDoorThree.gameObject.SetActive (true);

      CloseToLeverOne = false;
      CloseToLeverTwo = false;
      CloseToLeverThree = false;

      AtKeypad = false;

      //keypadScreen.enabled = false;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //moveDirection = x * transform.right + z * transform.forward
        
        if (Input.GetKey(KeyCode.E))
        {
            if (CloseToLeverOne == true)
            {
              LeverOneUp.gameObject.SetActive (false);
              LeverOneDown.gameObject.SetActive (true);
              LazerDoorOne.gameObject.SetActive (false);

              CloseToLeverOne = false;
            }

            if (CloseToLeverTwo == true)
            {
                LeverTwoUp.gameObject.SetActive (false);
                LeverTwoDown.gameObject.SetActive (true);
                LazerDoorTwo.gameObject.SetActive (false);

                CloseToLeverTwo = false;
            }

            if (CloseToLeverThree == true)
            {
                LeverThreeUp.gameObject.SetActive (false);
                LeverThreeDown.gameObject.SetActive (true);
                LazerDoorThree.gameObject.SetActive (false);

                CloseToLeverThree = false;
            }

            if (AtKeypad == true)
            {
                //keypadScreen.enabled = true;
            }
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeverOne"))
        {
            CloseToLeverOne = true;
        }

        if (other.gameObject.CompareTag("LeverTwo"))
        {
            CloseToLeverTwo = true;
        }

        if (other.gameObject.CompareTag("LeverThree"))
        {
            CloseToLeverThree = true;
        }

        if (other.gameObject.CompareTag("Keypad"))
        {
            AtKeypad = true;
        }
    }
        
}
