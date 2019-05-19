using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class GamePhaseChange : MonoBehaviour {

	public Material eveningLight;
	public Material nightLight;
	public PostProcessingProfile ppProfile;
	public GameObject enemy1;
    public GameObject enemy2;
    public AudioSource howl;
    public int target = 60;
    public Text timerText;
 	private float time = 5; //240 original 4min



    void Start () {

        QualitySettings.vSyncCount = 1; 
        Application.targetFrameRate = target;


        StartCoroutine("LoseTime");

        RenderSettings.skybox = eveningLight; // set evening
        ppProfile.eyeAdaptation.enabled = false; // darkness PP off
        ppProfile.ambientOcclusion.enabled = false;
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        

	}
	

	void FixedUpdate () {

        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;

        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timerText.text = ("Time before nightfall: " + minutes + ":" + seconds);

        if (time < 0)
		{
			if (RenderSettings.skybox == eveningLight) 
            {
                RenderSettings.skybox = nightLight; //set night
			    ppProfile.eyeAdaptation.enabled = true; // darkness PP on
                ppProfile.ambientOcclusion.enabled = true; // darkness PP on #2
                enemy1.SetActive(true); // wolf near big tree spawns
                enemy2.SetActive(true); // wolf near houses spawns
                howl.PlayDelayed(1); // play wolf howl when dark
            }
		  timerText.enabled = false;
		}
	}


    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

	/*void StartCoundownTimer()
    {
          // 300 = 5min 
        // InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
     
     }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            //timerText.text = "Time before nightfall: " + minutes + ":" + seconds;
            Debug.Log(1.0f / Time.deltaTime);
        }
    }*/

}
