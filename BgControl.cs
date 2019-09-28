using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BgControl : MonoBehaviour
{
    private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void move(float dir)
    {
        if(dir >0 )
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset += 0.3f * Time.deltaTime, 0));
        }
        else
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset -= 0.3f * Time.deltaTime, 0));
        }
    }

}
