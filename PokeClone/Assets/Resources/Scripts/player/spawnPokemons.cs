using UnityEngine;
using System.Collections;

public class spawnPokemons : MonoBehaviour 
{
	private  GameObject[] locaisPokemons;
	public  GameObject[] pokemons;
    private float tempoSpawn;

    private GameObject[] pokemonsIntanciados;
    

	void Start () 
	{
        locaisPokemons = GameObject.FindGameObjectsWithTag("lugarSpawnPokemon");
        tempoSpawn = 0;
	}

	void Update () 
	{
        pokemonsIntanciados = GameObject.FindGameObjectsWithTag("pokemon");

        tempoSpawn += Time.deltaTime;

	    if (tempoSpawn >= 10)
        {
            if (pokemonsIntanciados.Length == 0)
            {
                instanciarPokemon();
                tempoSpawn = 0;
                Debug.Log("pokemon");
            }
            else
            {
                tempoSpawn = 0;
            }
           
        }
	}

    private void instanciarPokemon()
    {
        int numeroPokemon = Random.Range(0, pokemons.Length); // sortear qual pokemon será instanciado

        int numeroLugar = Random.Range(0, locaisPokemons.Length); // sortear o lugar no qual o pokemon será instanciado

        Instantiate(pokemons[numeroPokemon], new Vector3(locaisPokemons[numeroLugar].transform.position.x, 
           0f, 
            locaisPokemons[numeroLugar].transform.position.z), Quaternion.identity);
    }
}
