using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class MoveArduino : MonoBehaviour
{
	SerialPort serial= new SerialPort("COM6",9600,Parity.None,8,StopBits.One);
	bool stopForward, stopBack;
	private Animator anim;
	public Camera cam;
	private float speed=100,a;
    // Start is called before the first frame update
    void Start()
    {
		anim= GetComponent<Animator>();
		Connection ();
    }

    // Update is called once per frame
    void Update()
	{
		if (serial.IsOpen) {
			Debug.Log ("Yes, Already is Open");
			try {
				float f = float.Parse (serial.ReadLine ());
				Debug.Log(f);
				Move(f);


			} catch {

			}
				
		}
	}

	void stop(){

		stopForward= Physics.Raycast(transform.position, cam.transform.forward, 0.3f);
		Debug.DrawRay(transform.position,cam.transform.forward * 0.3f, Color.red);
		stopBack = Physics.Raycast(transform.position, cam.transform.forward*-1,0.3f);
		Debug.DrawRay(transform.position,cam.transform.forward*-1* 0.3f, Color.yellow);
	}

	void Move(float v ){
		stop ();
		if(v<=1 && v>=-1){
			anim.SetFloat("Walk",v);
		}

		if(v==1 && !stopForward){
			transform.Translate(Vector3.forward*Time.deltaTime);
		}
		if(v==-1 && !stopBack){
			transform.Translate(Vector3.forward*-1f*Time.deltaTime);

		}
		if(v==2){
			transform.Rotate(0f,speed*Time.deltaTime,0f);
		}
		if(v==-2){
			transform.Rotate(0f,speed*-1*Time.deltaTime,0f);
		}
	}


	void Connection(){
		if (serial != null) {

			if (serial.IsOpen) {
				serial.Close ();
				Debug.Log ("Port closing, because it was already opened");
			} else {
				serial.Open ();
				serial.ReadTimeout = 100;
				Debug.Log ("The port was Opened ");
			}
		} else {
			if (serial.IsOpen) {
				Debug.Log ("The port is open");
			} else
				Debug.Log ("The port is null");
			
		}

	}	

}
