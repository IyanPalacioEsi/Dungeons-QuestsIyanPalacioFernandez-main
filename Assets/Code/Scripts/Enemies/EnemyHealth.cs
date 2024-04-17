﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; //Vida maxima que puede tener

    public int currentHealth = 3; //Vida que tiene actualmente

    public GameObject deathEffect;

    public float knockBackForce;

    private Rigidbody2D _theRB;

    void Start()
    {
        //Inicializar la vida al valor maximo
        currentHealth = maxHealth;

        //GetComponent => Va al objeto donde est� metido este c�digo y busca el componente indicado
        _theRB = GetComponent<Rigidbody2D>();

    }

    //Llamar a esta funcion cada vez que el enemigo tenga que recibir daño

    public void TakeDamage()
    {
        //Cada golpe que recibe tiene que restar 1 a su vida actual
        currentHealth--;
        //Si se queda sin vida, se muere :(

        Knockback();

        if(currentHealth <= 0)
        {
            //Desactivamos al enemigo padre
            transform.gameObject.SetActive(false);
            //Instanciamos el efecto de muerte del enemigo en la posición del primer hijo
            Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
            //Llamamos al método del Singleton de AudioManager que reproduce el sonido
            AudioManager.audioMReference.PlaySFX(3);
        }
    }
    public void Knockback()
    {
        //Paralizamos al jugador en X y hacemos que salte en Y
        _theRB.velocity = new Vector2( knockBackForce, 0f);
        //Cambiamos el valor del par�metro del Animator "hurt"
        //_anim.SetTrigger("Hurt");
    }
}