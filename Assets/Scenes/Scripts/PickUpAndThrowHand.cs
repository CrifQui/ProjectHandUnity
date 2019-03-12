using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndThrowHand : MonoBehaviour
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
			anim.SetBool("take",true);
			if (Distance < d)
			{
				GetComponent<Rigidbody>().useGravity = false;
				this.transform.position = onhand.position;
				this.transform.parent = GameObject.Find("Player").transform;
				this.transform.parent = GameObject.Find("hand1").transform;

			}
		}
		else
			PickThrow();


	}

	void PickThrow()
	{
		this.transform.parent = null;
		GetComponent<Rigidbody>().useGravity=true;
		anim.SetBool("take",false);

	}
}
