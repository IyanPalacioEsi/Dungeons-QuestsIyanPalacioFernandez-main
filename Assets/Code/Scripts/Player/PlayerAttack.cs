using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    

    //Referencia al Animator
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos la tecla de atacar asignada...
        if (Input.GetMouseButtonDown(0))
        {
            //Activa el parametro de tipo trigger que usamos para pasar
            //a la animacion de atacar
           
            anim.SetTrigger("Attack");
        }
    }
}
