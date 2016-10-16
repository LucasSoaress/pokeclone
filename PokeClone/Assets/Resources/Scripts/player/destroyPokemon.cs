using UnityEngine;
using System.Collections;

public class destroyPokemon : MonoBehaviour
{
    private float temposDestruir;

	void Start ()
    {
        temposDestruir = 0;
	}
	
	void Update ()
    {
        temposDestruir += Time.deltaTime;

	    if (temposDestruir >= 10)
        {
            Destroy(this.gameObject);
        }
	}
}
