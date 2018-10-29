using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour {

	public void CambiarEscena (string nombre){
		print ("cabiando ecena" + nombre);
		SceneManager.LoadScene (nombre);
	}

	public void Salir(){
		print ("Salir");
		Application.Quit ();
	}


}
