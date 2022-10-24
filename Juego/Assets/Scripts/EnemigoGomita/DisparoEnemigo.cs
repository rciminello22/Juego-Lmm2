using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject bala;

    public Transform aparicionBala;

    public float delay;

    public float DisparoRate;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        InvokeRepeating("Disparar", delay, DisparoRate);
    }

    
    void Update()
    {
        
    }

    void Disparar()
    {
        Instantiate(bala, aparicionBala.position, aparicionBala.rotation);
        audioSource.Play();
    }
}
