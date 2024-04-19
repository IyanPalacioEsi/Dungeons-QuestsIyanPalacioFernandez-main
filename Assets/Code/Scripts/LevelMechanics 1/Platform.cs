using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //Referenciamos el collider de la plataforma
    Collider2D _platformCollider;
    //Variable que nos permite usar bajar de la plataforma si estamos sobre ella
    public bool _onPlatform = false;

    public bool FallPlatform;
    private Rigidbody2D fallingPlat;
    Vector2 position;
    private bool IsFall;


    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el collider de la plataforma
        _platformCollider = GetComponent<EdgeCollider2D>();

        fallingPlat = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos abajo y estamos sobre la plataforma
        if (Input.GetAxisRaw("Vertical") < -0.5f && _onPlatform)
        {
            //Llamamos a la corrutina que activa y desactiva la plataforma
            StartCoroutine(ActDeactPlatformCo());
        }
        if (IsFall)
        {
            StartCoroutine(FallPlatformMetodo());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (FallPlatform)
        {
            IsFall = true;
        }
    }
    //Mientras un collider est� tocando al de este objeto
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Si el que est� colisionando es el jugador
        if (collision.gameObject.CompareTag("Player"))
            //Estamos sobre la plataforma
            _onPlatform = true;
    }

    //M�todo para saber cuando algo ha dejado de colisionar
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si el que deja de colisionar es el jugador
        if (collision.gameObject.CompareTag("Player"))
            //No estamos sobre la plataforma
            _onPlatform = false;
    }

    //Corrutina que activa y desactiva el collider de la plataforma
    private IEnumerator ActDeactPlatformCo()
    {
        //Desactivamos el componente collider
        _platformCollider.enabled = false; //Enabled nos permite activar o desactivar un componente espec�fico del objeto
        //Esperamos una cantidad de tiempo espec�fica
        yield return new WaitForSeconds(.5f);
        //Activamos el componente collider
        _platformCollider.enabled = true;
    }

    IEnumerator FallPlatformMetodo()
    {
        yield return new WaitForSeconds(1f);
        fallingPlat.velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(4f);
        fallingPlat.velocity = new Vector2(0, 0);
        transform.position = position;
        IsFall = false;
        
    }
}
