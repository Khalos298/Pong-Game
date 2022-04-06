using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float m_movimientoX, m_movimientoY;

    public float m_velocidad_bolaRef;
    //Estos indicadores permiten usar el valor desde otro script, mas no modificarlo. Es decir, el valor solo puede ser cambiado en su propia clase.
  
    float distanciaBolaVsLimite;
    float tiempoTotal;
    float tiempoEsperado;
     

    // Start is called before the first frame update
    void Start()
    {
        m_movimientoX = Random.Range(-1f, 1);
        m_movimientoY = Random.Range(-1f, 1);

       
        DistanciaBola();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEsperado >= tiempoTotal)
        {
            return;
        }
        tiempoTotal += Time.deltaTime;
        MovPelota();
    }

    public void MovPelota()
    {
        LimitesParaPelota();
        transform.position += new Vector3(m_movimientoX, m_movimientoY, 0) * m_velocidad_bolaRef * Time.deltaTime;

    }
    public void DistanciaBola()
    {
        distanciaBolaVsLimite = transform.position.x - GameManager.Instance.positionArribaDer.x;
        tiempoTotal = distanciaBolaVsLimite / (m_velocidad_bolaRef * m_movimientoX);
        tiempoTotal = Mathf.Abs(tiempoTotal);
    }
    public void LimitesParaPelota()
    {
        float dis = GameManager.Instance.positionArribaDer.x;
        if (transform.position.x >= dis && m_movimientoX >= 0)
        {
            GameManager.Instance.Marcador(1);
            this.gameObject.SetActive(false);
            
        }

        float dis2 = GameManager.Instance.positionArribaIzq.x;
        if (transform.position.x <= dis2 && m_movimientoX <= 0)
        {
            GameManager.Instance.Marcador(2);
            this.gameObject.SetActive(false);
           

        }
        float dis3 = GameManager.Instance.positionAbajoDer.y;
        if (transform.position.y <= dis3 && m_movimientoY <= 0)
        {
            m_movimientoY *= -1;
        }
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
