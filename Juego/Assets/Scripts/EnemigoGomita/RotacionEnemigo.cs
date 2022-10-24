using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEnemigo : MonoBehaviour
{
    [SerializeField] public Transform objetivo;

    void Start()
    {
        
    }


    void Update()
    {
        Vector2 objetivoOrientacion = objetivo.position - transform.position;
        Debug.DrawRay(transform.position, objetivoOrientacion, Color.green);

        transform.rotation = Quaternion.LookRotation(objetivoOrientacion);
    }
}
