using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene 사용

public class woochiVillage : MonoBehaviour
{
   public float movementSpeed = 3.0f;
   Vector2 movement = new Vector2();
   Rigidbody2D rigidbody2D;

   Animator animator;
   string animationsState = "woochiState";

   enum States 
   {
	right = 1, 
	left = 2, 	
	up = 3, 
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
   }

   
   private void FixedUpdate()
   {
	MoveCharacter();
   }

   private void MoveCharacter()
   {
	movement.x = Input.GetAxisRaw("Horizontal");
	movement.y = Input.GetAxisRaw("Vertical");

	movement.Normalize();

	rigidbody2D.velocity = movement * movementSpeed;
    }

    private void UpdateState() 
    {
	if (movement. x > 0)
	    animator.SetInteger(animationsState, (int)States.right);
	else if (movement.x < 0)
	    animator.SetInteger(animationsState, (int)States.left);
	else if (movement.y > 0)
	    animator.SetInteger(animationsState, (int)States.up);
	else if (movement.y < 0)
	    animator.SetInteger(animationsState, (int)States.down);
	else
	    animator.SetInteger(animationsState, (int)States.down);
    }

    // 게임씬 변경
    void OnTriggerEnter2D(Collider2D other)
    {
	SceneManager.LoadScene("game1");
    }

}

