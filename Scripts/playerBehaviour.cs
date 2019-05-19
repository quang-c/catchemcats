using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour {
    public bool isHidden;
	// Use this for initialization
	void Start () {
        isHidden = false;
	}
	





     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Bush"))
         {
             isHidden = true;
         }


     }
    
    void OnTriggerExit(Collider other)
    {
        isHidden = false;
    }
}
