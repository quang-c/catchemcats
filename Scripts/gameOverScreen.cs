using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverScreen : MonoBehaviour {

    public Animator anim;
    public EnemyController enemy;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyController>();
    }
	
	// Update is called once per frame
	public void Update () {
       // if (enemy.touchedPlayer)
      //  {
       //     anim.SetTrigger("GameOver");
      //  }
    }


}
