using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class PickUpAndThrowHand : MonoBehaviour
{	
	
	SerialPort sp= new SerialPort("COM6",9600,Parity.None,8,StopBits.One);
	public  Transform onhand;
	public GameObject Obj;
	public GameObject player;
	public Animator anim;
	public float d ;
	public float Distance;

	void Start(){
		Connection ();
	}
	void FixedUpdate() {
		
		if (sp.IsOpen) {
			try {
				float f = float.Parse(sp.ReadLine ());
				Debug.Log(f);
				PickUp(f);

			} catch {

			}

		}
	

	}

	void PickUp(float v){
		
		Distance = Vector3.Distance(Obj.transform.position, player.transform.position);
		if (v==3)
		{	
			Debug.Log ("what happen");
			//anim.SetBool("take",true);
			if (Distance < d)
			{
				GetComponent<Rigidbody>().useGravity = false;
				this.transform.position = onhand.position;
				this.transform.parent = GameObject.Find("Player").transform;
				this.transform.parent = GameObject.Find("hand1").transform;

			}
		}
		else
			PickThrow(v);


	}

	void PickThrow(float v)
	{
		if(v==-3){
			this.transform.parent = null;
			GetComponent<Rigidbody>().useGravity=true;
			anim.SetBool("take",false);
		}


	}

	void Connection(){
		if (sp != null) {

			if (sp.IsOpen) {
				sp.Close ();
				Debug.Log ("Port closing, because it was already opened");
			} else {
				sp.Open ();
				sp.ReadTimeout = 100;
				Debug.Log ("The port was Opened ");
			}
		} else {
			if (sp.IsOpen) {
				Debug.Log ("The port is open");
			} else
				Debug.Log ("The port is null");

		}

	}	
}
