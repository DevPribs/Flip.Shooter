using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSliderNumber : MonoBehaviour {

	public void updateSliderNumber(InputField inputfield)
    {
        int x;
        bool number = int.TryParse(inputfield.text,out x);
        if(number)
        {
            this.GetComponent<Slider>().value = x;
            if (x > 255)
            {
                inputfield.text = "" + 255;
            }
        }
        
    }
}
