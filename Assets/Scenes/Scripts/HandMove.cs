using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    // Start is called before the first frame update
	float h,v;
	bool stopForward, stopBack;
	public Camera cam;
	public float speed = 50f;
    void Start()
    {
	 	
    }

    // Update is called once per frame
    void Update()
    {
		moved();
		stop();
    }
	void stop(){
		stopForward= Physics.Raycast(transform.position, cam.transform.forward, 0.3f);
		stopBack= Physics.Raycast(transform.position, cam.transform.forward*-1, 0.3f);
		Debug.DrawRay(transform.position, cam.transform.forward,Color.green, 0.3f );
		Debug.DrawRay(transform.position, cam.transform.forward*-1, Color.yellow,0.3f);
	}
	void moved(){


		h=Input.GetAxis("Horizontal");
		v= Input.GetAxis("Vertical");
	

			if(v>0 && !stopForward){
				transform.Translate(Vector3.forward*Time.deltaTime);
			}
			if(v<0 && !stopBack){
				transform.Translate(Vector3.forward*-1*Time.deltaTime);
			}
			if(h!=0){
				transform.Rotate(0,speed*h*-1*Time.deltaTime,0);
			}
	}
}
