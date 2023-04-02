using UnityEngine;
using System.Collections;
	
	//Este script se aplicara a la camara del jugador.

public class CameraController : MonoBehaviour {

	// Creamos una variable publica vacia de tipo objeto de juego y le asignamos el nombre de player. 
	// Esto para que en el inspector relacionemos el objeto de juego "player" con la variable player.
	// Creamos una variable privada vacia de tipo vector3 con el nombre de offset.

	public GameObject player;
	private Vector3 offset;

	// Al iniciar la escena asingale a la variable offset de tipo vector3 el valor direccional de la posicion de la inicial (de la camara) menos la posicion inicial del jugador.
	// En otras palabras estamos creando offset con el valor de la diferencia entre la camara y el jugador.

	void Start ()
		{
			offset = transform.position - player.transform.position;
		}

	// Usamos LateUpdate porque queremos checar que la accion se completo incluso despues de ejecutarla.
	// Ve moviendo (transdorm) la camara al valor que se movio el jugador + offset. (En donde offset es la diferencia que ya existia al inicio).

	void LateUpdate ()
		{
			transform.position = player.transform.position + offset;
		}
	}

