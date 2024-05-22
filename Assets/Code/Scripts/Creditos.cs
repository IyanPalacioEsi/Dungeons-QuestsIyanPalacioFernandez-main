using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librería para poder usar las escenas

public class Creditos : MonoBehaviour
{

    //Variable de tiempo para la corrutina
    public float waitToRespawn;

    //Variable para guardar el nombre del nivel al queremos ir
    public string levelToLoad;

    //Referencia al UIController
    private CreditsFundido _cfReference;



    private void Start()
    {


        //Inicializamos la referencia al UIController
        _cfReference = GameObject.Find("Canvas").GetComponent<CreditsFundido>();


        //Llamamos a la corrutina de salir del nivel de carga
        LoadLevelExit();
            
        

    }

    public void Cronometro()
    {
        StartCoroutine(CronometroCo());
    }

    //Corrutina para respawnear al jugador
    private IEnumerator CronometroCo()
    {
        yield return new WaitForSeconds(waitToRespawn);
    }

    //Método para terminar un nivel
    public void ExitLevel()
    {
        //Llamamos a la corrutina de salir del nivel
        StartCoroutine(ExitLevelCo());
    }

    //Corrutina de terminar el nivel
    public IEnumerator ExitLevelCo()
    {
        //Paramos los inputs del jugador
        //_pCReference.stopInput = true;
        //Paramos el movimiento del jugador
        //_pCReference.StopPlayer();
        
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(1.5f);
        
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(1.5f);
        //Hacemos fundido a negro
        _cfReference.FadeToBlack();
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(1.5f);
        //Ir a la pantalla de carga o al selector de niveles
        SceneManager.LoadScene(levelToLoad);
    }

    //Método para salir del nivel de carga
    public void LoadLevelExit()
    {
        //Llamamos a la corrutina que nos saca del nivel de carga
        StartCoroutine(LoadLevelExitCo());
    }



    //Corrutina para salir del nivel de carga
    IEnumerator LoadLevelExitCo()
    {
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(3.5f);
        //Hacemos fundido a negro
        _cfReference.FadeToBlack();
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(1.5f);
        //Ir a la pantalla de carga o al selector de niveles
        SceneManager.LoadScene(levelToLoad);
    }

    
}
