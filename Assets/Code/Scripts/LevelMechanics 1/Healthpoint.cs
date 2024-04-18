using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpoint : MonoBehaviour
{
    
    //Referencias a los sprites que se ir�n alternando al activar o desactivar los checkpoints
    public Sprite cpOn, cpOff;

    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealthController>().FullHealPlayer();
            GetComponent<SpriteRenderer>().sprite = cpOn;
            //Llamamos al método del Singleton de AudioManager que reproduce el sonido
            AudioManager.audioMReference.PlaySFX(11);
        }
    }
    //Método para desactivar este Checkpoint concreto
    public void ResetCheckpoint()
    {
        //Cambiamos el sprite a Checkpoint apagado
        GetComponent<SpriteRenderer>().sprite = cpOff;
    }


}
