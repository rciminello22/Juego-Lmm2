using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class movimientoPP : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private AudioSource pasos;

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

    private bool dobleSalto = false;

    [Header("Vida")]
    
    [SerializeField] private float vida;

    private float vidaInicial = 0;

    [SerializeField] private BarraDeVida barraDeVida;

    public event EventHandler MuerteJugador;

    [SerializeField] private GameObject efectoMuerte;

    [Header("Pegarse")]

    [SerializeField] private float velocidadPegarse;
    

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colisionadorAgachado = GetComponent<CircleCollider2D>();
        pasos = GetComponent<AudioSource>();

        barraDeVida.InicializarBarraVida(vidaInicial);
    }

   
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

     
        movimientoHorizontal = input.x * velocidadDeMovimiento;
      
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        if(Input.GetButtonDown("Horizontal") && enPiso == true)
        {
           pasos.Play();

        }
        if (Input.GetButtonUp("Horizontal"))
        {
            pasos.Stop();
        }
        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if(Input.GetButtonDown("Jump") && enPiso)
        {
            salto = true;
        }
        if(Input.GetButtonUp("Jump"))
        {
            salto= false;
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
        animator.SetBool("DobleSalto", dobleSalto );

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
                dobleSalto = false;
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
            
           // ControladorSonido.PlaySound("saltarSonido");            
            Saltar();
            saltar = false;

        } 

       
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
        dobleSalto = true;
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

    public void TomarDano(float dano)
    {

        vida -= dano;
        vidaInicial += dano;
        barraDeVida.CambiarVidaActual(vidaInicial);
        if(vida<= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Muerte();
        }

    }

    public void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.CompareTag("Gomita"))
        {
            Debug.Log("Esta pegado");
            Pegarse();
        }

    }

    public void Pegarse()
    {
        animator.SetTrigger("Pegarse");
        rb2D.velocity = new Vector2(velocidadPegarse, rb2D.velocity.y);

    }

}
