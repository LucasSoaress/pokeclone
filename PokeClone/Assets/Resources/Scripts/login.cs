using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class login : MonoBehaviour
{
    public InputField usuaroNome;
    public InputField usuarioSenha;
    public Toggle lembrarDados;

    private const string URL = "http://jogounity.esy.es/login.php"; // variavel de acesso a url para conexao

	void Start ()
    {
	    if (PlayerPrefs.HasKey("lembrar") && PlayerPrefs.GetInt("lembrar") == 1)
        {
                // entrar na proxima cena, verifica se ele ja logou salva os dados e entra na proxima cena - > simulando android studio 
                //Application.LoadLevel("game");
        }
	}
	
    /// <summary>
    /// Método para o clique do botão de fazer o login
    /// </summary>
    public void fazerLogin()
    {
        string usuario = usuaroNome.text;
        string senha = usuarioSenha.text;

        if (usuario == "" || senha == "")
        {
            Debug.Log("preencha todos os dados para conseguir logar");
        }
        else
        {
            PlayerPrefs.SetString("nomeUsuario", usuario);

            if (lembrarDados.isOn)
            {
                PlayerPrefs.SetInt("lembrar", 1);
            }

            WWW www = new WWW(URL + "?nome=" + usuario + "&senha=" + senha);  // conexao com os logins e passa os dados
            StartCoroutine(validarLogin(www));
        }     
    }

    /// <summary>
    /// Método para validar se os dados que o usuário digitou são válidos, faz o login
    /// </summary>
    /// <param name="www">Requer o www com os dados ja inseridos </param>
    /// <returns>Retorna a conexão</returns>
    private IEnumerator validarLogin(WWW www)
    {
        yield return www;

        if (www.error == null) //conexão realizada com sucesso
        {
            string status = www.text;

            if (status == "1")
            {
                //Usuario logou corretamente
                Application.LoadLevel("game");
            }
            else if (status == "0")
            {
                Debug.Log("ocorreu um erro para logar");
            }
        }

        else // erro na conexão
        {
            Debug.Log(www.error);
        }
    }
}
