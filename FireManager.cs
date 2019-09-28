using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{

    public GameObject Fire;

    //间隔时间
    private float cd = 2f;

    private PlayerControl pc;
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.hp < 1)
        {
            return;
        }
        cd -= Time.deltaTime;
        if(cd <= 0)
        {
            //创建火圈
            Instantiate(Fire, transform.position, Quaternion.identity);
            //重置CD
            cd = 2f + Random.Range(-0.5f, 0.5f);
        }
    }
}
