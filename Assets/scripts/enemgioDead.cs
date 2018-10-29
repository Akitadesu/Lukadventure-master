using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemgioDead : MonoBehaviour {

	public GameObject drop;
	public Transform tDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {

		if (col.tag == "Player")
        {
			
			col.gameObject.GetComponent<Player_controller> ().EnemyJump ();
            if (transform.position.y < col.transform.position.y)
            {
                Destroy(transform.parent.gameObject);
                Instantiate(drop, tDrop.position, tDrop.rotation);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
			
		}
	}
}
