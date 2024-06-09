using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce;
    public float doubleJumpForce;

    public AudioSource pizzaSound;
    public AudioSource appleSound;
    public AudioSource jumpSound;
    public AudioSource backgroundMusic;
    public AudioSource deathSound;

    public GameManager gameManager;

    public bool isOnGround = true;
    public bool doubleJump = false;

    private Rigidbody playerRb;
    private CapsuleCollider playerCollider;

    private float horizontalInput;
    private float verticalInput;

    public ParticleSystem deathParticle;

    private PlayerDirection playerAnimator;
    




    // Start is called before the first frame update
    void Start()
    {
        transform.position = gameManager.respawnPosition.transform.position;
        isOnGround = true;
        playerCollider = GetComponent<CapsuleCollider>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -29.43f, 0);
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

        }

    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (gameManager.gameOver.activeInHierarchy == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }


    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump == true && !isOnGround && gameManager.gameOver.activeInHierarchy == false)
        {
            jumpSound.Play();
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            doubleJump = false;
        }



        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameManager.gameOver.activeInHierarchy == false)
        {
            jumpSound.Play();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.animator.SetTrigger("Jump_trig");
            isOnGround = false;
            playerAnimator.animator.SetBool("Jump_b", false);
            doubleJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DeathBarrier(other);
        Collectables(other);
        NextLevel(other);
    }


    void DeathBarrier(Collider other)
    {
        if (other.CompareTag("DeathBarrier") && gameManager.lives > 0)
        {
            transform.position = gameManager.respawnPosition.transform.position;
        }
        if (other.CompareTag("DeathBarrier") && gameManager.lives <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathParticle.Play();
            deathSound.Play();
            gameManager.gameOver.SetActive(true);
            playerAnimator.animator.SetBool("Death_b", true);
            playerAnimator.animator.SetInteger("DeathType_int", 1);
            doubleJump = false;
            isOnGround = false;
            playerCollider.enabled = false;
            playerRb.isKinematic = true;

        }
        if (other.CompareTag("DeathBarrier") && gameManager.lives > 0)
        {
            gameManager.lives--;
        }
    }

    void Collectables(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {

            gameManager.score += 1;
            pizzaSound.Play();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Apple"))
        {

            gameManager.lives += 1;
            appleSound.Play();
            Destroy(other.gameObject);
        }
    }

    void NextLevel(Collider other)
    {
        if (other.CompareTag("Next Level"))
        {
            if (gameManager.currentScene == "Level 1" && gameManager.score >= gameManager.totalpizza)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (gameManager.currentScene == "Level 1" && gameManager.score < gameManager.totalpizza)
            {
                gameManager.missingPizza.gameObject.SetActive(true);
            }

            
            if (gameManager.currentScene == "Level 2" && gameManager.score >= gameManager.totalpizza)
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (gameManager.currentScene == "Level 2" && gameManager.score < gameManager.totalpizza)
            {
                gameManager.missingPizza.gameObject.SetActive(true);
            }
            
            if (gameManager.currentScene == "Level 3" && gameManager.score >= gameManager.totalpizza)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gameManager.endGame.SetActive(true);
                gameManager.missingPizza.gameObject.SetActive(false);
                gameManager.endGameBarrier.enabled = true;
                
            }
            else if (gameManager.currentScene == "Level 3" && gameManager.score < gameManager.totalpizza)
            {
                gameManager.missingPizza.gameObject.SetActive(true);
            }


        }
    }

}
