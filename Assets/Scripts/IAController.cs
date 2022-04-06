using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    public int velocidadAi;

    public GameObject ball;
    public GameObject ball2;

    Vector2 ballPosition;
    Vector2 ballPosition2;
 
    void Update()
    {
        MovimientoAi();

    }

    void MovimientoAi()
    {
        ballPosition = ball.transform.position;
        ballPosition2 = ball2.transform.position; 

        if (transform.position.y > ballPosition.y /*|| transform.position.y > ballPosition2.y*/)
        {
           transform.position += new Vector3(0, -velocidadAi * Time.deltaTime);
        }
        if (transform.position.y < ballPosition.y /*|| transform.position.y < ballPosition2.y*/)
        {

            transform.position += new Vector3(0, velocidadAi * Time.deltaTime);
        }

    }
}
