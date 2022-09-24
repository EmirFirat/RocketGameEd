using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{
    // Start is called before the first frame update
    Transform bar;
    SpriteRenderer first;
    [SerializeField]MakeInvisBackGround makeInvisBackGround;
    [SerializeField]MakeInvisBar makeBar;
    [SerializeField]CMakeInvisText canvasftxt;
    void Start()
    {
        bar=transform.Find("Bar");
        

    }
    public void setSizeBar(float size){
        bar.localScale=new Vector3(size,1f,0.09f);
    }
    public void invis(){
        makeInvisBackGround.invisBG();
        makeBar.invisBar();
        canvasftxt.invisText();

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
