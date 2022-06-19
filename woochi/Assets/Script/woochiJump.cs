using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene

public class woochiJump : MonoBehaviour
{
    Rigidbody2D rigid2D;
        Animator animator;
        float jumpForce = 500.0f;
        float walkForce = 40.0f;
        float maxWalkSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y ==0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우이동
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key,1,1);
        }

        this.animator.speed = speedx / 6.0f;  

 	// 화면 밖 -> 처음부터
	if (transform.position.y < -10)
	{
	    SceneManager.LoadScene("game2");
	}
    }

}
