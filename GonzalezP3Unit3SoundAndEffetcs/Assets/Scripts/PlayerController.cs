using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
       
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if(collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}




