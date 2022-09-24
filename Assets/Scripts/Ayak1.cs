using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayak1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 v3=new Vector3(0.06f,0.5f,0.06f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G)){
            transform.RotateAround(new Vector3(0f,3.5f,0f),new Vector3(0f,0f,1f),120*Time.deltaTime);

        }
    }
}
