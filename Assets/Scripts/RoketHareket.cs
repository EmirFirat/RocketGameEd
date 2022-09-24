using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoketHareket : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float fuel=10.0f;
    AudioSource audioSource;
    [SerializeField]float boost=1.0f;
    [SerializeField]HealtBar hp;
    [SerializeField]float burnRate=2.0f;
    [SerializeField]float donus=1.0f;
    [SerializeField]AudioClip engine;

    [SerializeField]ParticleSystem upBoost;
    [SerializeField]ParticleSystem RightBoost;
    [SerializeField]ParticleSystem LeftBoost;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        thu();
        cikis();
    }


void cikis(){
    if(Input.GetKey(KeyCode.Escape)){
        Application.Quit();
    }
}
    void move(){
        if(Input.GetKey(KeyCode.Space)){
            if(fuel<0){
                audioSource.Stop(); 
                upBoost.Stop();
                return;
            }
            fuel -= burnRate * Time.deltaTime;
            rb.AddRelativeForce(Vector3.up*boost*Time.deltaTime);
            
            if(!audioSource.isPlaying){
            audioSource.PlayOneShot(engine);
            }if(!upBoost.isPlaying){
                upBoost.Play();
            }

        }
        else{
           audioSource.Stop(); 
           upBoost.Stop();
        }
        hp.setSizeBar(fuel/10);
        
    }
    void thu(){
        if(Input.GetKey(KeyCode.A)){
            rb.freezeRotation=true;
            transform.Rotate(Vector3.forward*donus*Time.deltaTime);
            if(!LeftBoost.isPlaying){
                LeftBoost.Play();
            }
            rb.freezeRotation=false;
            
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.freezeRotation=true;
            transform.Rotate(-Vector3.forward*donus*Time.deltaTime);
            if(!RightBoost.isPlaying){
                RightBoost.Play();
            }
            rb.freezeRotation=false;

        }
        else{
            LeftBoost.Stop();
            RightBoost.Stop();
        }

    }
    public void stopTheParticals(){
        LeftBoost.Stop();
        RightBoost.Stop();
        upBoost.Stop();
    }
}


    