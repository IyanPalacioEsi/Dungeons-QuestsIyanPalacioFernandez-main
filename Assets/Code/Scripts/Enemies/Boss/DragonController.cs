using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    //Lista de estados por los que puede pasar el jefe final (M�quina de estados)
    public enum bossStates { shooting, hurt, moving, ended};
    //Atributo de las variables que me permite asociar una descripci�n visible a la variable en el editor de Unity
    [Tooltip("Elegimos el estado actual en el que se encuentra el jefe final")]
    //Creamos una referencia al estado actual del jefe final
    public bossStates currentState;

    //Atributo de las variables que genera un encabezado en el editor de Unity
    [Header("Movement")]
    //Atributo de las variables que me permite asignar una barra de selecci�n a una variable
    [Range(0, 100)]
    //Velocidad del jefe final
    public float moveSpeed;
    //Puntos entre los que se mueve el enemigo
    public Transform leftPoint, rightPoint;
    //Para conocer hacia donde se mueve
    private bool _movingRight;

    [Header("References")]
    //Posici�n del Boos
    public Transform theBoss;
    //Referencia al Animator del jefe final
    private Animator _bAnim;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Animator del jefe final
        _bAnim = GetComponentInChildren<Animator>();
        //Inicializamos el estado en el que empieza el jefe final
        currentState = bossStates.shooting;//currentState = bossStates.shooting <=> currentState = 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
