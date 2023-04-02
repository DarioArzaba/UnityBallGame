using UnityEngine;
using System.Collections;
		
		// Este script se aplicara a Collectable		

public class Collectable : MonoBehaviour {
		
		// Se realizara la siguiente funcion una vez por frame
		void Update () 
		{	
			// Rotar con los siguientes valores xyz del vector3 y que no se actualize cada frame sino cada microsegundo desde la ultima frame actualizada.
			// Esto ultimo hace mucho mas real pero mas pesada la accion. Como es una simple rotacion no tiene mucho impacto en el rendimiento.

		Vector3 movement1 = new Vector3 (0, 75, 0);

		transform.Rotate (movement1 * Time.deltaTime, Space.World);
		}
}
