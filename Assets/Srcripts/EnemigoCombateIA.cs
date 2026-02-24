using UnityEngine;
using UnityEngine.UI;

public class EnemigoCombateIA : MonoBehaviour
{
    public float velocidad = 3f;
    public float distanciaDetencion = 5f;
    public Bullet prefabBalaEnemiga;
    public Transform puntaArma;
    public float tiempoEntreDisparos = 1.5f;

    [Header("UI del Subjefe")]
    public GameObject panelBarraVida; // El objeto del Canvas que contiene la barra
    public UnityEngine.UI.Slider sliderVidaSubjefe; // El componente Slider
    private SistemaVida miVida;
    
    private Transform jugador;
    private Rigidbody2D rb;
    private float cronometro;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        miVida = GetComponent<SistemaVida>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) jugador = p.transform;

        

        GameObject barra = GameObject.Find("BarraVidaenemigos");
        if (barra != null) {
            panelBarraVida = barra;
            sliderVidaSubjefe = barra.GetComponent<Slider>();
            
            /*if (sliderVidaSubjefe != null && miVida != null) {
            sliderVidaSubjefe.maxValue = miVida.vidaMax;
            sliderVidaSubjefe.value = miVida.vidaActual;
            }*/
        }
        
         // Empezamos con la barra oculta
        if (panelBarraVida != null) panelBarraVida.SetActive(false);
    }
    

        void FixedUpdate() 
    {
        if (jugador == null || !jugador.gameObject.activeInHierarchy)
        {
             rb.linearVelocity = Vector2.zero; // Que el enemigo se detenga
             return; 
        }  

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Mostrar barra si el jugador está cerca
        if (distancia < distanciaDetencion + 2f)
        {
            if (panelBarraVida != null) panelBarraVida.SetActive(true);
            
                
                if (sliderVidaSubjefe != null && miVida != null && miVida.vidaActual < miVida.vidaMax) 
                {
                sliderVidaSubjefe.maxValue = miVida.vidaMax;
                sliderVidaSubjefe.value = miVida.vidaActual;
                }
            }
            
        

        // Actualizar el slider
        /*if (sliderVidaSubjefe != null && miVida != null) {
            sliderVidaSubjefe.value = miVida.vidaActual;
        }*/

        Vector2 direccion = (Vector2)jugador.position - rb.position;
        float dist = direccion.magnitude;

        // Movimiento
        if (dist > distanciaDetencion) {
            rb.linearVelocity = direccion.normalized * velocidad;
        } else {
            rb.linearVelocity = Vector2.zero;
        }

        // Rotación
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angulo;

        // Disparo (Corregido Time)
        cronometro -= Time.deltaTime; 
        if (cronometro <= 0) {

            PoderesJEfes scriptPoder = GetComponent<PoderesJEfes>();

            if (scriptPoder != null) {
                // SI TIENE PODER: Lo ejecuta
                scriptPoder.EjecutarPoder(direccion.normalized);
            } else {
                // NO TIENE PODER: Disparo normal de subenemigo
                Disparar(direccion.normalized);
            }
            cronometro = tiempoEntreDisparos;
        }
    }
       
    

    void Disparar(Vector2 dir) 
    {
        if (prefabBalaEnemiga != null) 
        {
            Bullet bala = Instantiate(prefabBalaEnemiga, puntaArma.position, puntaArma.rotation);
            bala.Shoot(dir);
        }
    }
}
