using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cadastro : MonoBehaviour
{
    public InputField usuarioNome;
    public InputField usuarioSenha;

    private const string URL = "http://jogounity.esy.es/cadastro.php";
    
    public void fazerCadastro()
    {
        string usuario = usuarioNome.text;
        string senha = usuarioSenha.text;

        if (usuario == "" || senha == "")
        {
            Debug.Log("preencha todos os dados para realizar o cadastro");
        }

        else
        {
            WWW www = new WWW(URL + "?nome=" + usuario + "&senha=" + senha);
            StartCoroutine(validarCadastro(www));
        }

    }

    private IEnumerator validarCadastro(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            string status = www.text;

            if (status == "1")
            {
                Debug.Log("usuario ja cadastrado");
            }
            else if (status == "10") // usuario cadastrado com sucesso
            {
                Debug.Log("usuario cadastrado com sucesso");
                PlayerPrefs.SetString("nomeUsuario", usuarioNome.text);
                Application.LoadLevel("mapa");
            }

            else
            {
                Debug.Log("ocorreu um erro para cadastrar o usuario");
            }
        }

        else
        {
            Debug.Log("ocorreu um erro na conexão com o banco de dados");
        }
    }
}
