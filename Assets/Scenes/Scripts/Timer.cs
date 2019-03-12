using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text timer;
	public float start;
	public bool finish;
	// Start is called before the first frame update
	void Start()
	{
		start=Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		float t = Time.time - start;
		string minutes=((int) t/60).ToString("00");
		string seconds= (t%60).ToString("00");
		timer.text= minutes + ":" + seconds;
	}

}
