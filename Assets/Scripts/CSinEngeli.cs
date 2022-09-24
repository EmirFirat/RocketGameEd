using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSinEngeli : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float period=2f;
    [SerializeField]Vector3 str;
    [SerializeField]Vector3 Movement_Vector;
    float MovementFactor=0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time/period;
        const float tau=Mathf.PI*2;
        float Raw_Sin_Wave = Mathf.Sin(cycles*tau);
        MovementFactor=(Raw_Sin_Wave + 1f) / 2.0f;
        Vector3 offset=Movement_Vector*MovementFactor;
        transform.position=str+offset;

    }
}
