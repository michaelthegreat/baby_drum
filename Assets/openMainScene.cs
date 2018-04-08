using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMainScene : MonoBehaviour {
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Use this for initialization
    void Start () {

        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine("LoadMain");
    }
	
	// Update is called once per frame
	void Update () {

    }
    IEnumerator LoadMain()
    {
        float time = 3f;

        //Vector3 destinationScale = new Vector3(1.5f, 1.5f, 1.5f);

        float currentTime = 0.0f;
        do
        {
            currentTime += Time.deltaTime;
            yield return null;

        } while (currentTime <= time);
        Application.LoadLevel("main");
    }

}
