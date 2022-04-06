using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    private void Start()
    {
       
    }
    public void RestartEscena1()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.Jugador1.SetActive(true);
        GameManager.Instance.Jugador2.SetActive(true);
        StartCoroutine(reinicio());
        
        IEnumerator reinicio()
        {
            yield return new WaitForSeconds(5);
            Time.timeScale = 1;
            GameManager.Instance.bolita.SetActive(true);

        }

    }

    public void RestartEscena2()
    {
        SceneManager.LoadScene(2);
        GameManager.Instance.Jugador1.SetActive(true);
        GameManager.Instance.Jugador2.SetActive(true);
        StartCoroutine(reinicio());

        IEnumerator reinicio()
        {
            yield return new WaitForSeconds(5);
            Time.timeScale = 1;
            GameManager.Instance.bolita.SetActive(true);

        }

    }
     public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void UnoVsUno()
    {
        SceneManager.LoadScene(1);
    }

    public void UnoVsIa()
    {
        SceneManager.LoadScene(2);
    }

    public void SalirAplicacion()
    {
        Application.Quit();
    }



}


