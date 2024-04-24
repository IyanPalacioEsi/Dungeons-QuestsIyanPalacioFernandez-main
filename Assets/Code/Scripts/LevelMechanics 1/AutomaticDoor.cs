using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public float moreCounter;
    public float counter;

    private Animator AutoOpen;
    public bool isOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        counter = moreCounter;
        AutoOpen = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0) 
        {
            counter = counter - Time.deltaTime;
        }
        if (counter <= 0) 
        {
            counter = moreCounter;
            if (isOpen) 
            {
                isOpen = false;
                AutoOpen.SetBool("isOpen",false);
            }
            else 
            {
                isOpen = true;
                AutoOpen.SetBool("isOpen", true);
            }
        }
    }
}
