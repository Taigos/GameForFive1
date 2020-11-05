using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Kusok : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Kusok;
    public float Skolika;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Kusok.position = new Vector3(Kusok.position.x, Kusok.position.y - Skolika * Time.fixedDeltaTime, 0);
    }
}
