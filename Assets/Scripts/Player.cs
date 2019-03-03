using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    private Animator anim;  //动画组件
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	

    void walk()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, vertical, 0); //x, y轴上移动，所以z取0
        if (horizontal > 0)
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
        }
        else if (horizontal < 0)         // 播放向左走动画
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
        }
        else                                 //静止 Idle 动画
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
        }
        if(vertical > 0)
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
        }
        else if (vertical < 0)
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
        }
        else
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
    }

	// Update is called once per frame
	void Update () {
        walk();
	}

    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {

    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }
}
