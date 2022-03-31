using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_velocidadDeMovimiento;
    float direccionDeMovimiento;

    //Offset = Margen o area de seguridad
    public float offset;
  
    //se pregunta si el jugador esta al lado izquierdo.
    public bool estaALaIzq;

    private void Start()
    {
        UbicarJugador();
    }
    private void Update()
    {
        //El GetAxisRaw, arroja valores enteros. El GetAxis, arroja valores decimales. 
        //direccionDeMovimiento = Input.GetAxisRaw("Vertical");
       
        //Movimiento_Jugador();
    }

    void UbicarJugador()
    {
        //El If se ejecuta como una pregunta
        if (estaALaIzq)
        {
            //La transformasion del jugador es un nuevo vector 3 que consta de tres valores, el primero que hace referencia al min de la
            //pantalla, el segundo que es la posicion en Y, y el tercero que hace referencia a la posicion en z de la distancia de la camara.
            //NOTA: En este caso, al margen en x (limite min o max), se le debe restar o sumar el offset, que es el que da la distancia del 
            //margen al jugador. 
            transform.position = new Vector3(GameManager.Instance.positionArribaIzq.x + GameManager.Instance.offsetJugadorAMargen, 0, GameManager.Instance.m_distaciaCamara);
        }

        else
        {
            transform.position = new Vector3(GameManager.Instance.positionArribaDer.x - GameManager.Instance.offsetJugadorAMargen, 0, GameManager.Instance.m_distaciaCamara);
        }
        

    }

    //Al ponerle un int en los parentesis en el metodo, podemos usar luego ese valor en otros scripts, de tal modo que sse pueda usar el metodo sin escribirlo todo otra vez. 
    public void Movimiento_Jugador(int moverDirY)
    {
        //Esta es una acuacion para determinar que, sin importar el tamaño del Player, el offset siempre será igual. 
        offset = transform.localScale.y / 2;
        direccionDeMovimiento = moverDirY;

        //Si, la posicion del jugador en el eje Y es mayor o igual a la posicion del limite superior y aun estoy presionando la tecla hacia arriba
        if (transform.position.y + offset >= GameManager.Instance.positionArribaIzq.y && moverDirY > 0)
        {   //Entonces, la direccion en movimiento en Y se iguala a 0, la direccion se pone en 0 
            direccionDeMovimiento = 0;
        }

        // Aca se resta el offset, porque al ver el tamaño restado del centro hacia abajo, se el valor. 
        if (transform.position.y - offset <= GameManager.Instance.positionAbajoIzq.y && moverDirY < 0)
        {
            //Entonces, la direccion en movimiento en Y se iguala a 0, la direccion se pone en 0 
            direccionDeMovimiento = 0;
        }
        transform.Translate(new Vector3(0, direccionDeMovimiento, 0) * m_velocidadDeMovimiento * Time.deltaTime);
    }

    
}

