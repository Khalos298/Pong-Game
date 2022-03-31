using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBola : MonoBehaviour
{

    float m_movimientoX, m_movimientoY;

    public float m_velocidad_bolaRef; 
    //Estos indicadores permiten usar el valor desde otro script, mas no modificarlo. Es decir, el valor solo puede ser cambiado en su propia clase.
    public float m_velocidad { get; private set; }

    float distanciaBolaVsLimite;
    float tiempoTotal;
    float tiempoEsperado;
    
   
    // Start is called before the first frame update
    void Start()
    {
        m_movimientoX = Random.Range(0.1f, 1);
        m_movimientoY = Random.Range(0.1f, 1);
        m_velocidad_bolaRef = m_velocidad;
        DistanciaBola();
    }

    // Update is called once per frame
    void Update()
    { 
        //if (tiempoEsperado >= tiempoTotal)
        //{
        //    return;
        //}
        //tiempoEsperado += Time.deltaTime;
        MovPelota();
    }


    public void MovPelota()
    {
        LimitesParaPelota();
        //Vector2 randomVector = new Vector2 (Random.Range(0f, 2f), Random.Range(0f, -2f));
        transform.position += new Vector3(m_movimientoX, m_movimientoY, 0) * m_velocidad * Time.deltaTime;

    }
    public void DistanciaBola()
    {
        
        //Esta es la distancia y el tiempo que demora para llegar al limite. 
        distanciaBolaVsLimite = transform.position.x - GameManager.Instance.positionArribaDer.x;
        tiempoTotal = distanciaBolaVsLimite / (m_velocidad * m_movimientoX);
        //Abs= Absoluto. Mathf es una libreria que trae Unity. Esta linea se usa para pasar el valor negativo a positivo. 
        tiempoTotal = Mathf.Abs(tiempoTotal);

        Debug.Log("Tiempo esperado " + tiempoEsperado);
        Debug.Log("Tiempo Total  " + tiempoTotal);
        
    }
    public void LimitesParaPelota()
    {
        // Si el transform de nuestra posicion en x es mayor o igual al ancho de la pantalla, entonces toma un movimiento en x
        // Hya que ver que el tranform que estamos poniendo de la bola no debe ser mayor que el valor que le damos, en este caso, el tamaño de la pantalla.
        // Si la pelota cruza dicho valor, se regresa. 
        //Estos valores con tomados como referencia para poner las posiciones o limites de izquierda o derecha. 
        float dis = GameManager.Instance.positionArribaDer.x;
        
        if (transform.position.x >= dis && m_movimientoX >= 0)
        {
            GameManager.Instance.Marcador(1);
        }

        float dis2 = GameManager.Instance.positionArribaIzq.x;
        if (transform.position.x <= dis2 && m_movimientoX <= 0)
        {
            GameManager.Instance.Marcador(2);
        }

        //Este valore es tomados como referencia para poner las posicion o limite de abajo. 
        float dis3 = GameManager.Instance.positionAbajoDer.y;
        if (transform.position.y <= dis3 && m_movimientoY <= 0)
        {
            m_movimientoY *= -1;
        }

        //Una vez obtenidos las posiciones de izquierda, derecha y abajo, se repite una de las referencias de arriba. 
        float dis4 = GameManager.Instance.positionArribaDer.y;
        if (transform.position.y >= dis4 && m_movimientoY >= 0)
        {
            m_movimientoY *= -1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_movimientoX *= -1;
        }
    }
}
