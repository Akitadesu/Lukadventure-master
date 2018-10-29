using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieControl : MonoBehaviour {

	public float speed;
	public float length;
	private float counter;
	private float startPosition;

	private float actualPosition;
	private float lastPosition;
	private Animator anim;


	// Use this for initialization
	void Start () {

		startPosition = transform.position.x;
		
	}

	void Update(){

		counter += Time.deltaTime * speed;

		transform.position = new Vector2 (Mathf.PingPong (counter, length) + startPosition, transform.position.y);
		actualPosition = transform.position.x;
		if (actualPosition < lastPosition) transform.localScale = new Vector3 (1, 1, 1);
		if (actualPosition > lastPosition) transform.localScale = new Vector3 (-1, 1, 1);
		lastPosition = transform.position.x;
		
	
	}
		

}
