using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    GameObject bulletItem;
	// Use this for initialization
	void Start () {

        bulletItem = Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bulletItem) as GameObject;
            bulletObject.transform.position = transform.position;
            Rigidbody2D rigidbody = bulletObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(rigidbody.transform.forward * 0.1f);
        }
	
	}
}
