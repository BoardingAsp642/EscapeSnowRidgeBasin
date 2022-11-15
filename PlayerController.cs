using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    //movement
    public float speed;
    public float verticalInput;
    public float horizontalInput;
    public float turnSpeed;
    public KeyCode jumpKey;
    public KeyCode crouchKey;
    //Model
    public Rigidbody playerRB;
    public float jumpForce;
    //Respawn
    public GameObject spawnPoint;
    //Attacking
    public GameObject projectilePrefab;
    public GameObject projectileSpawner;
    public KeyCode attackKey;
    //restriction
    public float xRange = 20;
    public float gravityModifier;
    public bool isOnGround = true;
    //Animation
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        transform.Rotate(Vector3.up * 90);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        playerAnim.SetFloat("VerticalInput", verticalInput);
        //Jumping
        if (Input.GetKeyDown(jumpKey) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //ForwardMovement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        //Turning
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //Attacking
        //Punching
        playerAnim.SetTrigger("AttackKey");
        //Shooting
       // if (Input.GetKeyDown(KeyCode.Space))
            //Instantiate(projectilePrefab, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
       // isOnGround = false;

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}

