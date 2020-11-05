using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sfera_coll : MonoBehaviour
{


    public UnityEvent SendTriggerEnterEvent;
    public UnityEvent SendTriggerExitEvent;
    void Start()
    {
        print("Я работаю");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        //bool is_ground;
        //if (col.tag == "Ground") //is_ground = true;
        //Sfera.Enter();
        //go.GetComponent<Player>.Enter();
        print("Сработал тригер входа пустышки");
        if (SendTriggerEnterEvent != null)
            SendTriggerEnterEvent.Invoke();
    }
    private void OnTriggerExit(Collider col)
    {
        //bool is_ground;
        //if (col.tag == "Ground") //is_ground = false;
        //Sfera.Exit();
        print("Сработал тригер выхода пустышки");
        if (SendTriggerExitEvent != null)
            SendTriggerExitEvent.Invoke();

    }
}
