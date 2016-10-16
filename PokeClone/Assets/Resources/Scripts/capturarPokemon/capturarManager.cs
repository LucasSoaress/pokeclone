using UnityEngine;
using System.Collections;

public class capturarManager : MonoBehaviour
{
    public GameObject localPokemon;

    void Start()
    {
        string nomePokemon = PlayerPrefs.GetString("nomePokemon");
        GameObject pokemon = Resources.Load<GameObject>("Prefabs/Pokemons/" + nomePokemon);

        Instantiate(pokemon, new Vector3(localPokemon.transform.position.x, 
            localPokemon.transform.position.y, 
            localPokemon.transform.position.z),Quaternion.identity);

        pokemon.GetComponent<destroyPokemon>().enabled = false;
    }
	
	void Update ()
    {
	
	}
}
