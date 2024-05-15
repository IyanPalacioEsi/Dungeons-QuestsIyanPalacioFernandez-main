using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public int maxHp = 3; //Vida maxima que puede tener

    public int hp = 3; //Vida que tiene actualmente




    private void Start()
    {
        maxHp = hp;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon") 
        {
            hp--;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    IEnumerator Invincibility()
    {
        yield return null;
    }

    IEnumerator KnockBack()
    {
        yield return null;
    }


}
