using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClick : MonoBehaviour {
    Vector3 originalScale;
    Vector3 destinationScale;
    // Use this for initialization
    void Start () {
        this.originalScale = this.gameObject.transform.localScale;
        this.destinationScale = new Vector3(this.originalScale.x * 1.5f, this.originalScale.y * 1.5f, this.originalScale.z * 1.5f);
        
    }

    // Update is called once per frame
    void Update () {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        /*
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }*/
    }
 

    IEnumerator HandleClickEvent()
    {
        this.GetComponent<AudioSource>().Play();
        GameObject gameObject = this.gameObject;
        float time = 0.2f;
       
        //Vector3 destinationScale = new Vector3(1.5f, 1.5f, 1.5f);

        float currentTime = 0.0f;
        do
        {
            gameObject.transform.localScale = Vector3.Lerp(this.originalScale, this.destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp( this.destinationScale, this.originalScale,currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        gameObject.transform.localScale = this.originalScale;
    }

    private void OnMouseDown()
    {
        //StartCoroutine("ScaleOverTime");
        //Debug.Log("MouseDown");
    }

}
