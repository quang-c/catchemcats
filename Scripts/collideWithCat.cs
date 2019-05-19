using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collideWithCat : MonoBehaviour {


	public GameObject Cat;
    public Text catCountText;
    public int catCount;

	// Use this for initialization
	void Start () {
        catCount = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        catCountText.text = "Cats found: " + catCount + "/8";
	}

	/*void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Kitty")) 
        {
            inZone = true;
			if (Input.GetKey(KeyCode.E))
			{
				other.gameObject.SetActive (false);
                catCount++;
			}
            
            
        }
    }**/
}
