using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collisions : MonoBehaviour
{

    [SerializeField]AudioClip succ;
    [SerializeField]AudioClip crash;


    [SerializeField]ParticleSystem basari;
    [SerializeField]ParticleSystem patlama;

    [SerializeField]RoketHareket rk;
    AudioSource audioSource;
    bool situation=false;
    bool colDisable=false;
    [SerializeField] HealtBar hp;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        respondToDebugKeys();
    }

    void respondToDebugKeys(){
        if(Input.GetKeyDown(KeyCode.L)){
            newEp();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            colDisable=!colDisable;
        }

    }
    private void OnCollisionEnter(Collision other) {
        
        
        if(!situation&&!colDisable){
            if(other.gameObject.tag=="Dusman"){
                crashSeq();
            }
            else if(other.gameObject.tag=="Bitis"){
                sucSeq();  
            }
        } 

    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Fuel"){
            Destroy(other.gameObject);
            gameObject.GetComponent<RoketHareket>().fuel=10.0f;
        }
    }
    void newEp(){
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1)%5);
    }
    void reLoad(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void crashSeq(){
        rk.stopTheParticals();
        hp.invis();
        audioSource.Stop();
        situation=true;
        patlama.Play();
        gameObject.GetComponent<RoketHareket>().enabled=false;
        audioSource.PlayOneShot(crash);
        Invoke("reLoad",2);
    }
    void sucSeq(){
        rk.stopTheParticals();
        hp.invis();
        audioSource.Stop();
        situation=true;
        basari.Play();
        gameObject.GetComponent<RoketHareket>().enabled=false;
        if(situation){
        audioSource.PlayOneShot(succ);
        }
        Invoke("newEp",2);

    }
}


