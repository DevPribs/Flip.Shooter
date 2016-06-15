using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public float BulletSpeed = 100f;

    GameObject bulletItem;
    Vector2 currentPosition;
    Vector3 pointingDirection;
    float angle;
    Quaternion rotation;
	// Use this for initialization
	void Start () {

        bulletItem = Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        int numberTouches = Input.touchCount;

        if(numberTouches > 0)
        {
            Touch touch = Input.GetTouch(0);
            currentPosition = touch.position;
            currentPosition = new Vector2(currentPosition.x - Screen.width / 2, currentPosition.y - Screen.height / 2);
            angle = Mathf.Atan(currentPosition.y / currentPosition.x);
            if(currentPosition.x < 0)
            {
                angle += Mathf.PI;
            }
            transform.rotation = Quaternion.AngleAxis((angle*180)/Mathf.PI, Vector3.forward);

            currentPosition = currentPosition.normalized;

            //Vector3 lastPositionV3 = new Vector3(currentPosition.x, currentPosition.y);
            //pointingDirection = (lastPositionV3 - transform.position).normalized;
            //rotation = Quaternion.LookRotation(pointingDirection);
            //transform.rotation = rotation;


            if(touch.phase == TouchPhase.Ended)
            {
                GameObject bulletObject = Instantiate(bulletItem) as GameObject;
                bulletObject.transform.position = transform.position;
                Rigidbody2D rigidbody = bulletObject.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(currentPosition * BulletSpeed);
            }
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    GameObject bulletObject = Instantiate(bulletItem) as GameObject;
        //    bulletObject.transform.position = transform.position;
        //    Rigidbody2D rigidbody = bulletObject.GetComponent<Rigidbody2D>();
        //    rigidbody.AddForce(rigidbody.transform.forward * 0.1f);
        //}
	
	}
}
