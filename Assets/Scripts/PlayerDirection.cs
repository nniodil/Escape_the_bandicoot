using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        animator = GameObject.Find("Skin").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
    }
    
    
    
    
    private void PlayerAnimation()
    {
        //Running Animation
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }



        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }



        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);
            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Static_b", true);
            animator.SetFloat("Speed_f", 0.6f);

            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Static_b", false);
            animator.SetFloat("Speed_f", 0);
        }
 
    }
}


