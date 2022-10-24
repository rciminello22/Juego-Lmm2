using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    
    public static AudioClip saltarSonido, caerSonido;

    static AudioSource audioSource;

    void Start()
    {

        saltarSonido = Resources.Load<AudioClip>("saltarSonido");
        caerSonido = Resources.Load<AudioClip>("caerSonido");
  
        audioSource = GetComponent<AudioSource>();
    
    }

    public static void PlaySound (string clip)
    {

        switch (clip)
        {
            case "saltarSonido":
            audioSource.PlayOneShot(saltarSonido);
            break;
            case "caerSonido":
            audioSource.PlayOneShot(caerSonido);
            break;
        }

    }


}
