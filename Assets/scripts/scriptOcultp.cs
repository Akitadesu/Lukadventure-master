using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptOcultp : MonoBehaviour {

	public GameObject paredFalsa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "paredFalsa") {

			if (paredFalsa.activeSelf == true) {
			
				paredFalsa.SetActive (false);
			} 
		}

	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag != "paredFalsa") {

			if (paredFalsa.activeSelf == false) {

				paredFalsa.SetActive (true);
			} 
		}
	}
		
}
