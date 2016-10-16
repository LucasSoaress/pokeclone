using UnityEngine;
using System.Collections;

public class spawnBall : MonoBehaviour 
{
	public GameObject pokebola;
	private  GameObject[] locaisBolas;
	private float tempoBola;

    private GameObject[] pokebolasInstanciadas;

	void Start () 
	{
		tempoBola = 0;
        locaisBolas = GameObject.FindGameObjectsWithTag("lugarPokebola");
	}

	void Update () 
	{
        pokebolasInstanciadas = GameObject.FindGameObjectsWithTag("pokebola");

		tempoBola += 1 * Time.deltaTime;

		if (tempoBola >= 5) 
		{ 
            if (pokebolasInstanciadas.Length == 0)
            {
                instanciarPokebolas();
                tempoBola = 0;
            }
            else
            {
                tempoBola = 0;
            }
		}
	}

    void instanciarPokebolas()
    {
        int lugarPokebola = Random.Range(0, locaisBolas.Length);

        Instantiate(pokebola, new Vector3(locaisBolas[lugarPokebola].transform.position.x, 
            locaisBolas[lugarPokebola].transform.position.y, 
            locaisBolas[lugarPokebola].transform.position.z),Quaternion.identity);
    }
}
