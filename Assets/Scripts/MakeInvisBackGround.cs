using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void invisBG(){
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
    }
}
