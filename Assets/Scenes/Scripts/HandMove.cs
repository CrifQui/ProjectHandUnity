using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class HandMove : MonoBehaviour
{
    // Start is called before the first frame update
	SerialPort serial= new SerialPort("COM6",9600,Parity.None,8,StopBits.One);
	float h,v;
	bool stopForward, stopBack;
	public Camera cam;
	public float speed = 50f;


	public  Transform onhand;
	public GameObject Obj;
	public GameObject player;
	public Animator anim;
	public float d ;
	public float Distance;

    void Start()
    {
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
				PickUp(f);

			} catch {

			}

		}
    }
	void stop(){
		stopForward= Physics.Raycast(onhand.transform.position, cam.transform.forward, 0.3f);
		stopBack= Physics.Raycast(onhand.transform.position, cam.transform.forward*-1, 0.5f);
		Debug.DrawRay(onhand.transform.position, cam.transform.forward,Color.green, 0.3f );
		Debug.DrawRay(onhand.transform.position, cam.transform.forward*-1, Color.yellow,0.3f);
	}

	void Move(float v ){
		
		stop ();

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



	void PickUp(float v){

		Distance = Vector3.Distance(Obj.transform.position, player.transform.position);
		if (v==3)
		{	
			Debug.Log ("what happen");
			anim.SetBool("take",true);
			if (Distance < d)
			{
				Obj.GetComponent<Rigidbody>().useGravity = false;
				Obj.transform.position = onhand.position;
				Obj.transform.parent = GameObject.Find("Player").transform;
				Obj.transform.parent = GameObject.Find("hand1").transform;

			}
		}
		else
			PickThrow(v);


	}

	void PickThrow(float v)
	{
		if(v==-3){
			Obj.transform.parent = null;
			Obj.GetComponent<Rigidbody>().useGravity=true;
			anim.SetBool("take",false);
		}


	}




}
