using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorPicker : MonoBehaviour {

    GameObject colorPicker;
    Texture2D colorImage;

	// Use this for initialization
	void Start () {

        colorPicker = GameObject.Find("ColorPicker");
        colorImage = colorPicker.GetComponent<RawImage>().texture as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {

        int touches = Input.touchCount;
        if(touches > 0)
        {
            if( Input.GetTouch(0).phase == TouchPhase.Began)
            {



                print(colorPicker.GetComponent<RectTransform>().position.x);
                print(colorPicker.GetComponent<RectTransform>().position.y);
            }
        }
            
	}
}
