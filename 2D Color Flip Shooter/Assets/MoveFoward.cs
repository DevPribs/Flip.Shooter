using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0.1F, 0, 0);
	}
}
