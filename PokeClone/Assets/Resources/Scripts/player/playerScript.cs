using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "pokemon")
        {
            Destroy(col.gameObject);
            string nomePokemon = col.gameObject.name;
            string nomeFinal = nomePokemon.Replace("(Clone)", "");
            Debug.Log(nomeFinal);
            Application.LoadLevel("game");
            PlayerPrefs.SetString("nomePokemon", nomeFinal);
        }
    }
}
