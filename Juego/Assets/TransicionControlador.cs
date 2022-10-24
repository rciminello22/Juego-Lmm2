using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionControlador : MonoBehaviour
{
   
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene(1);
    }
}
