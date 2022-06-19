using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene 사용

public class woochiGame : MonoBehaviour
{
   public float movementSpeed = 3.0f;
   Vector2 movement = new Vector2();
   Rigidbody2D rigidbody2D;
   float jumpForce = 680.0f;

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

	// 점프
	if (Input.GetKeyDown(KeyCode.Space) && rigidbody2D.velocity.y == 0)
	{
	    rigidbody2D.AddForce(transform.up * jumpForce);
	}

	// 화면 밖 -> 처음부터
	/*if (transform.position.y < -10)
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


}
