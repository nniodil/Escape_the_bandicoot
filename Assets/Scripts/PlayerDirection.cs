using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager gameManager;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        animator = GameObject.Find("Skin").GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
    }
    
    
    
    
    private void PlayerAnimation()
    {
        //Running Animation
        if (Input.GetKey(KeyCode.W) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.W) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }



        if (Input.GetKey(KeyCode.S) && gameManager.gameOver.activeInHierarchy == false)
        {

            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.S) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }



        if (Input.GetKey(KeyCode.A) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.A) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }


        if (Input.GetKey(KeyCode.D) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);

            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.D) && gameManager.gameOver.activeInHierarchy == false)
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }
 
    }
}


