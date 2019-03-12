using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class MoveArduino : MonoBehaviour
{
	SerialPort serial= new SerialPort("COM4",9600);
    // Start is called before the first frame update
    void Start()
    {
		serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
		if (serial.IsOpen) {
			
			string value = serial.ReadLine (); //Read the information
			Debug.Log ("value " + value);
		}
    }


		

}
