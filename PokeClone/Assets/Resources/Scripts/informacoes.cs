using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class informacoes : MonoBehaviour
{
    public Text nomeUsuario;
    public Text pontosUsuario;

	void Start ()
    {
        nomeUsuario.text = PlayerPrefs.GetString("nomeUsuario");
	}
	
	void Update ()
    {
	    
	}
}
