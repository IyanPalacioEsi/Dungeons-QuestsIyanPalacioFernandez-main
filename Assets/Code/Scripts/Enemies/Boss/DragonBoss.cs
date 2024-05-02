using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBoss : MonoBehaviour
{
    //Array de puntos por los que se mueve el enemigo
    public Transform[] points;

    //Velocidad de movimiento del enemigo
    public float moveSpeed;
    //Variable para conocer el punto del recorrido en el que se encuentra el enemigo
    public int currentPoint;

    //Atributo de las variables que genera un encabezado en el editor de Unity
    [Header("Shooting")]
    //Referencia a los proyectiles del enemigo
    public GameObject bullet;
    //Punto desde el que salen los proyectiles
    public Transform firePoint;
    //Tiempo entre disparos
    public float timeBetweenShots;
    //Contador de tiempo entre disparos
    private float _shotCounter;

   

    //Distancia del jugador para poder atacar, velocidad de persecuci�n
    public float distanceToAttackPlayer, chaseSpeed;
    //Objetivo del enemigo
    private Vector3 attackTarget;

    //Tiempo entre ataques
    public float waitAfterAttack;
    //Contador de tiempo entre ataques
    private float _attackCounter;

    //Referencia al SpriteRenderer del enemigo
    private SpriteRenderer _sR;
    //Referencia al PlayerController
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la distancia entre el jugador y el enemigo es suficientemente grande
        if (Vector3.Distance(transform.position, _player.transform.position) > distanceToAttackPlayer)
        {
            //Reiniciamos el objetivo del ataque
            attackTarget = Vector3.zero;

            //Movemos al enemigo
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

            //Si el enemigo pr�cticamente ha llegado a su punto de destino
            if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.01f)
            {
                //Pasamos al siguiente punto
                currentPoint++;

                //Comprobamos si hemos llegado al �ltimo punto del array
                if (currentPoint >= points.Length)
                    //Reseteamos al primer punto del array
                    currentPoint = 0;
            }

            //Si el enemigo ha llegado al punto m�s a la izquierda
            if (transform.position.x < points[currentPoint].position.x)
                //Rotamos al enemigo para que mire en direcci�n contraria
                _sR.flipX = true;
            //Si el enemigo ha llegado al punto m�s a la derecha
            else if (transform.position.x > points[currentPoint].position.x)
                //Dejamos al enemigo mirando a la izquierda
                _sR.flipX = false;
        }
    }
}
