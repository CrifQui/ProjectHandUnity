using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	//SerialPort serial= new SerialPort("COM4",9600);
	private Animator anim;
	public float speed=50f;
	public Camera cam;

	public bool stopForward;
	private bool stopBack;
	//private bool isTurn=true;
	float v,h;


	void Start()
	{
		anim= GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		/**if(!serial.IsOpen)
			serial.Open();
		float f = int.Parse(Serial.Readline());

		moved(f);
		*/
		moved();
		stop();
	}

	void stop(){
		
		stopForward= Physics.Raycast(transform.position, cam.transform.forward, 0.3f);
		Debug.DrawRay(transform.position,cam.transform.forward * 0.3f, Color.red);
		stopBack = Physics.Raycast(transform.position, cam.transform.forward*-1,0.3f);
		Debug.DrawRay(transform.position,cam.transform.forward*-1* 0.3f, Color.yellow);
	}

	void moved(/**float h*/){
		h=Input.GetAxis("Horizontal");
		v=Input.GetAxis("Vertical");
		anim.SetFloat("Walk",v);
		if(v>0 && !stopForward){
			transform.Translate(Vector3.forward*Time.deltaTime);
		}
		if(v<0 && !stopBack){
			transform.Translate(Vector3.forward*-1f*Time.deltaTime);

		}
		if(h!=0){
			transform.Rotate(0f,speed*h*Time.deltaTime,0f);
		}
	}


}
