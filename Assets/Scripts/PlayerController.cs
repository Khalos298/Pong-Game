using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement scriptMovimientoJugador;
    [SerializeField] private bool isJugadorUno;
 
    private void Awake()
    {
        //Se accede al otro script con el Get Component
        scriptMovimientoJugador = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(isJugadorUno)
        {
            //Se hace referencia a la variable, luego a la funcion de ese script que se necesita. A ese valor del parentesis, se le añade el GetInputAxis, para hacer referencia a los controles. El int en los paréntesis, se usa para convertir el valor del Axis en entero. 
            scriptMovimientoJugador.Movimiento_Jugador((int)Input.GetAxisRaw("Vertical"));
        }
        else
        {
            scriptMovimientoJugador.Movimiento_Jugador((int)Input.GetAxisRaw("Vertical2"));
        }
       
    }
}
