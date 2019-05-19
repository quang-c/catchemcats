using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideText : MonoBehaviour {

	public string text;
	public bool display = false;

	public GameObject DisplayText;
    public GameObject Cat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider theCollide)
	{
		if(theCollide.transform.name == "Player")
		{
			display = true;

            //Cat.SetActive(false);

		}
	}

	void OnTriggerExit(Collider noCollide)
	{
		if(noCollide.transform.name == "Player")
		{
			display = false;
			DisplayText.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void OnGUI()
	{
		if (display == true)
		{
			GUI.Box (new Rect(Screen.width/2, Screen.height/2, 200, 50), text);
		}
	}
}
