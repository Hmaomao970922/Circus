using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource player;

    public AudioClip jump;
    public AudioClip die1;
    public AudioClip die2;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = GetComponent<AudioSource>();
    }

    //播放跳跃音效
    public void PlayJump()
    {
        player.PlayOneShot(jump);
    }

    //播放死亡音效
    public void PlayDie()
    {
        //BGM停止
        player.Stop();
        //播放死亡音效
        player.PlayOneShot(die1);
        //1s后调用PlayDie2
        Invoke("PlayDie2", 1f);
    }

    //后续音效
    void PlayDie2()
    {
        player.PlayOneShot(die2);
    }

}
