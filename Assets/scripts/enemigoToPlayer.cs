using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoToPlayer : MonoBehaviour {

	public float damageTime;
	private float counter;
	private bool hasHit;
	public float damage;

	public Player_controller player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (hasHit) {
			counter += Time.deltaTime;
			if (counter > damageTime) {

				counter = 0;
				hasHit = false;
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player"){
			if (!hasHit) {
				player.aguante -= damage;
				hasHit = true;
			}
		}
	}
}
