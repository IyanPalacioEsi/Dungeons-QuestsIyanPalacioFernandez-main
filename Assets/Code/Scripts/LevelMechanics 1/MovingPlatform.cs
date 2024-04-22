using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Array de puntos por los que se mueve la plataforma móvil
    public Transform[] points;
    //Velocidad de movimiento de la plataforma
    public float moveSpeed;
    //Variable para conocer en que punto del recorrido se encuentra la plataforma
    public int currentPoint;

    //Referencia a la posición de la plataforma
    public Transform _platformPosition;

    // Update is called once per frame
    void Update()
    {
        
    }
}
