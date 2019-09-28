using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private PlayerControl pc;

    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();

    }

    void Update()
    {
        //如果玩家死亡
        if(pc.hp < 1)
        { return; }
        //如果出屏幕，销毁
        if(transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
        //移动
        transform.Translate(Vector3.left * Time.deltaTime * 1f);
    }
}
