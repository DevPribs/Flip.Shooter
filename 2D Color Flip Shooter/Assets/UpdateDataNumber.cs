using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateDataNumber : MonoBehaviour {

	public void updateDataNumber(Slider slider)
    {
        this.GetComponent<InputField>().text = "" + slider.value;
    } 
}
