using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene 사용

public class woochiGame : MonoBehaviour
{
   public float movementSpeed = 3.0f;
   Vector2 movement = new Vector2();
   Rigidbody2D rigidbody2D;

   /*public float jumpPower;
   public bool isJump = false;*/

   Animator animator;
   string animationsState = "woochiState";

   enum States 
   {
	right = 1, 
	left = 2,
	down = 4
   }

   void Start()
   {
	animator = GetComponent<Animator>();
	rigidbody2D = GetComponent<Rigidbody2D>();
   }

   void Update() 
   {
   	UpdateState();
	/*Jump();

	// 화면 밖 -> 처음부터
	if (transform.position.y < -10)
	    SceneManager.LoadScene("GameScene");*/
   }

   
   private void FixedUpdate()
   {
	MoveCharacter();
   }

   private void MoveCharacter()
   {
	movement.x = Input.GetAxisRaw("Horizontal");

	movement.Normalize();

	rigidbody2D.velocity = movement * movementSpeed;
    }

    private void UpdateState() 
    {
	if (movement. x > 0)
	    animator.SetInteger(animationsState, (int)States.right);
	else if (movement.x < 0)
	    animator.SetInteger(animationsState, (int)States.left);
	else
	    animator.SetInteger(animationsState, (int)States.down);
	
    }

    /*void Jump()
    {
	if (Input.GetKeyDown(KeyCode.Space))
	{
	    if (!isJump)
	    {
		isJump = true;
		rigidbody2D.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
	    }
	
	}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
	if (other.gameObject.name.Equals("ground"))
	{
	    isJump = false;
	}
    }*/



}
