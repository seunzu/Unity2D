using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene

public class clearDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	// 플레이어 화면 밖 -> 다음 씬
	if (transform.position.y < -10)
	{
	    SceneManager.LoadScene("GameScene");
	}   
    }
}
