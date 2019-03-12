using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndThrowController : MonoBehaviour
{

	public  Transform onhand;
	public GameObject Obj;
	public GameObject player;
	public Animator anim;
	public float d ;
	public float Distance;


	void FixedUpdate() {

		PickUp();

	}

	void PickUp(){
		Distance = Vector3.Distance(Obj.transform.position, player.transform.position);


		if (Input.GetButton("Jump"))
		{
			anim.SetBool("Take",true);
			if (Distance < d)
			{
				GetComponent<Rigidbody>().useGravity = false;
				this.transform.position = onhand.position;
				this.transform.parent = GameObject.Find("Player").transform;
				this.transform.parent = GameObject.Find("Hips").transform;
				this.transform.parent = GameObject.Find("Spine").transform;
				this.transform.parent = GameObject.Find("Spine1").transform;
				this.transform.parent = GameObject.Find("Spine2").transform;
				this.transform.parent = GameObject.Find("LeftShoulder").transform;
				this.transform.parent = GameObject.Find("LeftArm").transform;
				this.transform.parent = GameObject.Find("LeftForeArm").transform;
				this.transform.parent = GameObject.Find("LeftHand").transform;
				this.transform.parent = GameObject.Find("LeftHandThumb1").transform;


			}
		}
		else
			PickThrow();


	}

	void PickThrow()
	{
		this.transform.parent = null;
		GetComponent<Rigidbody>().useGravity=true;
		anim.SetBool("Take",false);

	}


}
