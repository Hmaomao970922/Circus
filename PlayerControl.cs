using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public BgControl bgControl;
    public int hp = 1;

    private Animator ani;
    private Rigidbody2D rBody;


    //是否在地面
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //玩家死亡
        if(hp <= 0)
        { return; }
        //水平轴
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
        {
            //移动
            ani.SetBool("isRun",true);
            //背景后移
            bgControl.move(horizontal);
        }
        else
        {
            ani.SetBool("isRun", false);
        }

        //跳跃
        if(Input.GetKeyDown(KeyCode.Space)&&isGround == true)
        {
            rBody.AddForce(Vector2.up * 170);
            AudioManager.Instance.PlayJump();
        }
    }
    //进入碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("isJump", false);
        }
    }
    //离开碰撞
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("isJump", true);
        }
    }

    //进入火圈触发区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            hp--;
            Destroy(rBody);
            ani.SetBool("Die", true);
            AudioManager.Instance.PlayDie();
        }
    }

}
