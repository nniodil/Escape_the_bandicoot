using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce;
    public float doubleJumpForce;

    private AudioSource pizzaSound;
    public GameManager gameManager;


    public bool isOnGround = true;
    public bool doubleJump = false;
    private Rigidbody playerRb;
    private CapsuleCollider playerCollider;

    public float horizontalInput;
    public float verticalInput;

    public float gravityModifier;
    public PlayerDirection playerAnimator;



    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        pizzaSound = GetComponent<AudioSource>();
        gameManager = FindAnyObjectByType<GameManager>();
        playerAnimator = FindAnyObjectByType<PlayerDirection>();
        


    }

    // Update is called once per frame
    void Update()
    {
        JumpPlayer();
    }

    void FixedUpdate()
    {
        MovePlayer();



    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnimator.animator.SetBool("Jump_b", true);
            
        }

    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump == true && !isOnGround)
        {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            doubleJump = false;
        }



        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.animator.SetTrigger("Jump_trig");
            isOnGround = false;
            playerAnimator.animator.SetBool("Jump_b", false);
            doubleJump = true;
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {

            gameManager.score += 5;
            pizzaSound.Play();
            Destroy(other.gameObject);
        }
    }

}
