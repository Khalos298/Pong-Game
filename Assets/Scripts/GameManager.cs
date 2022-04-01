using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Camera Camara;
    public GameObject ball;
    float posicionBola; 

    //Variables de  las posiciones. 
    public Vector3 positionArribaDer;
    public Vector3 positionAbajoDer;
    public Vector3 positionArribaIzq;
    public Vector3 positionAbajoIzq;
    public float m_distaciaCamara;
    //float m_SphereRadius = 0.5f;

    //Se crean estas variable para acceder a ellas desde el script de la bola
   [SerializeField] private int m_puntajeJugador1;
   [SerializeField] private int m_puntajeJugador2;

    //Distancia jugador a la distancia min. 
    public float offsetJugadorAMargen;

    //esto se llama un metodo sigletos, donde se pone en las variables el gamemanager de tipo stattic, de tal modo que solo se reconozca este.
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
        //con esta linea, no se elimina el codigo, sino que puede usarse en otra escena.es decir, se conserva la forma sin ser destruido totalmente.
        //dontdestroyonload(this);
        LimitesPantalla();
    }

    //Se crea este metodo para darle valor al puntaje
   public void Marcador(int jugadorQueAnota)
    {
        if (jugadorQueAnota == 1)
        {
            m_puntajeJugador1++;
        }

        else if(jugadorQueAnota == 2)
        {
            m_puntajeJugador2++;
        }
    }
    public void LimitesPantalla()
    {
        //Este es un vector3 desechable o temporal, es decir, solo se podra usar dentro de esta funcion. 
        //Para tener un mayor control desde el inspector de ese valor. 
        Vector3 AbajoIzq = new Vector3(0, 0, m_distaciaCamara);

        //Unity necesita saber donde ubicar el punto respecto a la pantalla, entonces se crea la camara.
        //La posicion agregada, es la creada en el vector desechable. 
        positionAbajoIzq = Camara.ScreenToWorldPoint(AbajoIzq);

        Vector3 ArribaI = new Vector3(0, Screen.height, m_distaciaCamara);
        positionArribaIzq = Camara.ScreenToWorldPoint(ArribaI);

        Vector3 AbajoD = new Vector3(Screen.width, 0, m_distaciaCamara);
        positionAbajoDer = Camara.ScreenToWorldPoint(AbajoD);

        Vector3 ArribaDere = new Vector3(Screen.width, Screen.height, m_distaciaCamara);
        positionArribaDer = Camara.ScreenToWorldPoint(ArribaDere);
    }
    /*
    private void OnDrawGizmos()
     {
         LimitesPantalla();
         Gizmos.DrawSphere(Camara.ScreenToWorldPoint(positionAbajoIzq), m_SphereRadius);
         Gizmos.DrawWireSphere(Camara.ScreenToWorldPoint(positionArribaIzq), m_SphereRadius);
         Gizmos.DrawSphere(Camara.ScreenToWorldPoint(positionAbajoDer), m_SphereRadius);
         Gizmos.DrawSphere(Camara.ScreenToWorldPoint(positionArribaDer), m_SphereRadius);
     }
    */



}
