using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour {

	// Movimiento
	public float speed = 20f;
	public float maxSpeed = 2f;
	public bool grounded;
	public float poderSalto = 1f;
    public float saltoAtras = 1f;

	//-------------------------------
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	private bool movement = true;

	// Slider Vida
	public float vida = 100;
	public Slider sliderVida;
	public float desVida = 0.1f;

	// Slider Aguante
	public float aguante = 100;
	public float descAguante = 0.1f;
	public Slider sliderAguante;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool ("Grounded", grounded);

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = true;
		}

		// Barra Aguante
		aguante -= descAguante;
		sliderAguante.value = aguante;

		// Barra Vida
		if (aguante <= 0){
			vida -= desVida;
			sliderVida.value = vida;

		}
		if (vida <= 0){
			SceneManager.LoadScene ("End");
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			anim.SetTrigger ("Ataque");
		}
	}

	void FixedUpdate(){

		float h = Input.GetAxis ("Horizontal");
		if (!movement) h = 0;

		rb2d.AddForce (Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp (rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

		if (h < -0.1f) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
		if (jump) {
			rb2d.AddForce (Vector2.up * poderSalto, ForceMode2D.Impulse);
			jump = false;
		}
	}
    //re-aparecer en pantalla
    void OnBecameInvisible(){
		transform.position = new Vector3 (-1, 0, 0);
	}

	public void EnemyJump(){
		rb2d.AddForce (Vector2.left * saltoAtras, ForceMode2D.Impulse);
		jump = false;
	}

    public void EnemyKnockBack(float enemyPosX)
    {
        vida -= 10;
        sliderVida.value = vida;

        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * saltoAtras, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 1f);        

        anim.CrossFade("Player_Danho", 0);

    }
    void EnableMovement()
    {
        movement = true;

        anim.CrossFade("Player_Idle", 0);
    }

    
}
