using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycastCat : MonoBehaviour {

    public float distanceToSee;
    public Text touchingCat;
    public Text catCountText;
    public int catCount;

    public Text victory;
    public float restartDelay = 3f;
    float restartTimer;

    public GameObject touchingCatText;
    public bool catIsDestroyed;
    RaycastHit whatIHit;
	void Start () {
        touchingCatText.SetActive(false);
        catCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {

            if (whatIHit.collider.tag == "Kitty")
            {
                touchingCatText.SetActive(true);
                touchingCat.text = "Press E to pick up the cat";
            }
            else
            {
                touchingCatText.SetActive(false);
            }

            
            Debug.Log("im touching " + whatIHit.collider.gameObject.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("i picked up " + whatIHit.collider.gameObject.name);
                if (whatIHit.collider.tag == "Kitty")
                {
                    catIsDestroyed = true;
                    Destroy(whatIHit.collider.gameObject);
                    catCount++;
                   
                }
            }

            if (catIsDestroyed)
            {
                touchingCatText.SetActive(false);
                catIsDestroyed = false;
            }
        }
        catCountText.text = "Cats found: " + catCount + "/8";

        if(catCount == 8)
        {
            victory.text = "You won!";

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
