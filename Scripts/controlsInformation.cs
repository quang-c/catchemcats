using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlsInformation : MonoBehaviour {

    public Text controls;
    public GameObject controlsText;
    public float displayTimer;
	// Use this for initialization
	void Start () {
        displayTimer = 0;
        controlsText.SetActive(true);
        controls.text = "WASD to Move\nSpace to Jump";
    }
	
	// Update is called once per frame
	void Update () {
        displayTimer += Time.deltaTime;
        if( displayTimer > 5)
        {
            
            controlsText.SetActive(false);
        }
	}
}
