using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
       private Rigidbody2D rb2D;

    private AudioSource pasos;

    private bool estaCaminando;


    [Header("Movimiento")]

    private float movimientoHorizontal= 0f;

    [SerializeField] private float velocidadDeMovimiento;

    [Range(0,0.3f)][SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    public Vector2 input;

    [Header("Salto")]

    [SerializeField] private  float fuerzaDeSalto;

    [SerializeField] private LayerMask queEsPiso;

    [SerializeField] private Transform controladorPiso;

    [SerializeField] private Vector3 dimensionesCaja;

    [SerializeField] private bool enPiso;

    private bool salto = false;


    [Header("Animacion")]

    private Animator animator;

    [Header("Rebote")]

    [SerializeField] private float velocidadRebote;

    [Header("Agacharse")]

    [SerializeField] private Transform controladorTecho;
 
    [SerializeField] private float radioTecho;

    [SerializeField] private float multiplicadorVelocidadAgachado;

   [SerializeField] public Collider2D colisionadorAgachado;

    private bool estabaAgachado = false;

    private bool agachar = false;

    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colisionadorAgachado = GetComponent<CircleCollider2D>();
        pasos = GetComponent<AudioSource>();
    }

   
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");


        movimientoHorizontal = input.x * velocidadDeMovimiento;
      
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

         if(Input.GetButtonDown("Horizontal") )
        {
           pasos.Play();

        }
        if (Input.GetButtonUp("Horizontal"))
        {
            pasos.Pause();
        }

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if(input.y < 0 )
        {
            agachar = true;
            
        }
        else 
        {
            agachar = false;
            
        }
    }

    private void FixedUpdate() 
    {
        enPiso = Physics2D.OverlapBox(controladorPiso.position, dimensionesCaja, 0f, queEsPiso);
        animator.SetBool("enPiso", enPiso);
        animator.SetBool("Agacharse", estabaAgachado);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto, agachar);
    
        salto = false;

      
    }

    private void Mover(float mover, bool saltar, bool agachar) {
    
        if(!agachar)
        {
            //si arriba el personaje tiene "piso" lo va a mantener agachado, aunque no siga presionando la tecla
            if(Physics2D.OverlapCircle(controladorTecho.position, radioTecho, queEsPiso))
            {
                agachar = true;
            }

        }
        if(agachar)
        {

            if(!estabaAgachado)
            {
                estabaAgachado = true;
            }

            mover *= multiplicadorVelocidadAgachado;

            colisionadorAgachado.enabled = false;

            if(estabaAgachado)
            {
                if(saltar)
                {
                    SaltoDoble();
                }
            }

        }
        else
        {
            colisionadorAgachado.enabled = true;

            if(estabaAgachado)
            {
                estabaAgachado = false;
            }
        }

        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
    
        if(mover> 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if(mover<0 && mirandoDerecha)
        {
            Girar();
        }

        if(enPiso && saltar) {
            
            Saltar();
            
        }

        saltar = false;

        
    }

    private void Saltar()
    {
    
        rb2D.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse); 
        enPiso = false;

    }

    private void SaltoDoble()
    {
        
        rb2D.AddForce(Vector2.up * fuerzaDeSalto * 1.5f, ForceMode2D.Impulse) ; 
        enPiso = false;

    }

   public void Rebote()
    {

        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);

    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
