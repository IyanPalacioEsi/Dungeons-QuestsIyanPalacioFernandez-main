using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
   //Referencia al objeto que queremos activar al entrar en esta zona
    public GameObject theBossBattle;

    //M�todo para detectar cuando un objeto entra en la zona del activador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador el que entra en esta zona
        if (collision.CompareTag("Player"))
        {
            //Activamos el jefe final
            theBossBattle.SetActive(true);
            //Desactivamos este objeto
            gameObject.SetActive(false);
            //Llamamos al m�todo que reproduce la m�sica del jefe final
            AudioManager.audioMReference.PlayBossMusic();
        }
    }
}
