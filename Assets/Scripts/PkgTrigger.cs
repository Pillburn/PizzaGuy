using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PkgTrigger : MonoBehaviour
{
    public int speed = 30;
    public float pkgdesttim = 0.1f;
    public Color32 pickedUpPkg = new Color32(1,1,1,1);
    public Color32 noPkgClr = new Color32(1,1,1,1);
    bool gotpkg = false;

    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.tag == "Pkg" && gotpkg == false)
        {
            gotpkg = true;
            Debug.Log("Package Acquired");
            Destroy(other.gameObject,pkgdesttim);
            spriteRenderer.color = pickedUpPkg;
        }
        
        if(other.tag == "Cust" && gotpkg == true)
        {
            Debug.Log("Package Delivered");
            gotpkg = false;
            spriteRenderer.color = noPkgClr;
        }
        else if(other.tag == "Cust" && gotpkg == false){

            Debug.Log("You haven't picked up the package yet!!!");
        }

        if(other.tag == "Boost")
        {
            Debug.Log("SPEEEEEEEED BOOST!!");
            speed = speed + 100;  
        }

        if(other.tag == "Slow")
        {
            Debug.Log("SLOOOOOOOW DOOOOOOOWN!!");
            speed = speed - 100;
        }
        
    }
}
