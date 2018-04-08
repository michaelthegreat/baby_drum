using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Began;
    // Update is called once per frame
    void Update () {

        for (int i = 0; i < Input.touchCount; ++i)

            
        {
            if (Input.GetTouch(i).phase == touchPhase)
            {
                //We transform the touch position into word space from screen space and store it.
                touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //We now raycast with this information. If we have hit something we can process it.
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (hitInformation.collider != null)
                {
                    //We should have hit something with a 2D Physics collider!
                    GameObject touchedObject = hitInformation.transform.gameObject;
                    if ((touchedObject.GetComponent("HandleClick") as HandleClick ) != null)
                    {
                        (touchedObject.GetComponent("HandleClick") as HandleClick).StartCoroutine("HandleClickEvent");
                        
                    }
                }
            }

        }
    }


}
