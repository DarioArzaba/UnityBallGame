using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Creamos una variable publica vacia de tipo float asignando el nombre de speed. Estas variables aparecen en el inspector.
	// Creamos una variable privada vacia de tipo Rigidbody y le asignamos el nombre de rb. Estas variables no aparecen en el inspector.
	// Creamos dos variables tipo String para almacenar nuestro mensaje de UI.
	// Creamos una variable de tipo integral para almacenar la cantidad de puntos.

	public float speed;
	private Rigidbody rb;
	public Text countText;
	public Text winText;
	private int count;

	// Las funciones dentro de Start () se ejecutan al inicar la escena. 
	// En este caso llamamos a la variable privada tipo Rigidbody (rb) y le decimos que sus valores de tipo Rigidbody se apliquen al Rigidbody del objeto de juego.
	// Al inicio ponemos los puntos en 0.
	// Llamamos la funcion de la ui para escribir la cuenta, que al inicio se puso como 0.
	// La funcion de ganar va a estar vacia al inicio.

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	// las funciones dentro de FixedUpdate () se renderizaran constantemente (para que el input sea trasladado directamente al movimiento)

	void FixedUpdate ()
	{
		// FLOAT es el tipo de variable a usar, no usamos INT (Integral) porque normalmente el numero tendra un valor decimal infinito.
		// Despues de float va el nombre de la variable y a esta variable le asignamos el valor que introdusca (INPUT) el usuario con las teclas.
		// GetAxis es una funcion predefinida para que el valor de Input se tradusca al eje "X" u "Y" de la escena.

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Para que las dos variables float se traduscan en movimiento (o fuerza) en el cuerpo rigido se usa la funcion predeterminada ADDFORCE
		// Para que ADDFORCE funcione necesita un "VECTOR 3" este es otro tipo de variable que designa coordenadas: (X,Y,Z) 
		// [Recuerda que en Unity la Y es el eje de altura y Z el de produndidad]
		// Necesita el vector 3 porque necesita saber en que direccion va a añadir la fuerza.
		// Creamos el vector3 con el nombre de movement, diciendo que la direccion horizontal y vertical sean iguales a las que introdusca el usuario.
		// El segundo valor es 0.0f porque no queremos que se mueva en el eje Y es decir para arriba.

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Ya teniendo la direccion de la fuerza podemos asignarla a la variable rb (Que en el inicio se emparento con el Rigidbody del objeto de juego).
		// El primer parametro de ADDFORCE es la direccion (Que ya definimos en el vector) y la segunda es la velocidad.

		rb.AddForce (movement * speed);
	}

	// Las funciones dentro se ejecutaran cuando entren en contacto el collider de player (pues este es su script) con cualquier otro (other).

	void OnTriggerEnter(Collider other) 
	{
		// Entonces cuando colicione con algo si el collider otro pertenece a un objeto de juego con el tag "Capsule" volverlo "desapareserlo" si no tiene el Tag terminar.
		// Cuando colicione tambien aumentar 1 al contador y refrescarlo en el juego llamandolo.

		if (other.gameObject.CompareTag ("Capsule"))
		{
			count = count + 1;
			Destroy (other.gameObject);
			SetCountText ();
		}
	}

	// Las funciones dentro se ejecutaran cuando se llame a la funcion SetCountText ().
	// Las funcion primero escribe "Score: " + el valor que tenga el contador en ese momento.
	// Tambien cada ves que se llame esta fancion se checara si el contador es igual a 12, si lo es entonces pondra el texto "Ganaste".

	void SetCountText ()
	{
		countText.text = "Score: " + count.ToString ();
		if (count >= 8)
		{
			winText.text = "Ganaste!";
		}
	}
}

/*

{

    public float movementSpeed = 6.0f;

    void Update()
    {
        Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left * movementSpeed) + (Input.GetAxis("Vertical") * Vector3.forward * movementSpeed);
        movement *= Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(movement, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            MarbleGameManager.SP.FoundGem();
            Destroy(other.gameObject);
        }
        else
        {
            //Other collider.. See other.tag and other.name
        }
    }

}

*/
/*


public enum MarbleGameState {playing, won,lost };

public class MarbleGameManager : MonoBehaviour
{
	public static MarbleGameManager SP;

	private int totalGems;
	private int foundGems;
	private MarbleGameState gameState;


	void Awake()
	{
		SP = this; 
		foundGems = 0;
		gameState = MarbleGameState.playing;
		totalGems = GameObject.FindGameObjectsWithTag("Pickup").Length;
		Time.timeScale = 1.0f;
	}

	void OnGUI () {
		GUILayout.Label(" Found gems: "+foundGems+"/"+totalGems );

		if (gameState == MarbleGameState.lost)
		{
			GUILayout.Label("You Lost!");
			if(GUILayout.Button("Try again") ){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		else if (gameState == MarbleGameState.won)
		{
			GUILayout.Label("You won!");
			if(GUILayout.Button("Play again") ){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public void FoundGem()
	{
		foundGems++;
		if (foundGems >= totalGems)
		{
			WonGame();
		}
	}

	public void WonGame()
	{
		Time.timeScale = 0.0f; //Pause game
		gameState = MarbleGameState.won;
	}

	public void SetGameOver()
	{
		Time.timeScale = 0.0f; //Pause game
		gameState = MarbleGameState.lost;
	}
}

*/

/* 
NO JUMPING WALLS

using UnityEngine;
using System.Collections;

public class Nojumpingwalls : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
*/
/*

Here is a jump script.

using UnityEngine; using System.Collections;

public class JumpScript : MonoBehaviour
{
	public float jumpForce;

	private float jumpHeight;
	private bool isGrounded;
	private Vector3 jump;

	void Update()
	{
		jumpHeight = Input.GetAxis("Jump");
		jump = new Vector3(0.0f, jumpHeight, 0.0f);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			GetComponent<Rigidbody>().AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	void OnCollisionEnter()
	{
		isGrounded = true;
	}

	*/
	/* using UnityEngine;
	using System.Collections;

	public class GameoverTrigger : MonoBehaviour {

		void OnTriggerEnter()
		{
			MarbleGameManager.SP.SetGameOver();
		}
	}
	*/