using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Necesario para el parpadeo (Corrutinas)

public class SistemaVida : MonoBehaviour 
{
    [Header("Configuración")]
    public float vidaMax = 100f;
    public float vidaActual;
    public bool esJugador;

    [Header("Efectos")]
    public SpriteRenderer spritePersonaje; // Para que parpadee
    public Color colorDaño = Color.red;    // De qué color parpadea
    private Color colorOriginal;

    [Header("Animaciones")]
    private Animator anim;
    public Image fillImage;

    void Start() {
        vidaActual = vidaMax;
        anim = GetComponent<Animator>();
        if (spritePersonaje != null) colorOriginal = spritePersonaje.color;
    }

    public void RecibirDano(float cantidad) {
        vidaActual -= cantidad;

        if (esJugador) {
        // Buscamos la barra específica del jugador
        GameObject barraPlayer = GameObject.Find("BarraVidaPlayer");
        if (barraPlayer != null) 
        {
            Slider s = barraPlayer.GetComponent<Slider>();
            s.maxValue = vidaMax;
            s.value = vidaActual;

            Image fill = s.fillRect.GetComponent<Image>();
                if (vidaActual < vidaMax * 0.3f) 
                {
                    fill.color = Color.red;
                        } else {
                    fill.color = Color.green;
                }
        }
    } else {
            GameObject barra = GameObject.Find("BarraVidaenemigos");
            if (barra != null) {
                barra.SetActive(true);
                Slider s = barra.GetComponent<Slider>();
                s.maxValue = vidaMax;
                s.value = vidaActual;

                // EJEMPLO: Si la vida es menor al 30%, poner la barra roja
            Image fill = s.fillRect.GetComponent<Image>();
                if (vidaActual < vidaMax * 0.3f) 
                {
                    fill.color = Color.red;
                        } else {
                    fill.color = Color.green;
                }
            }
        }
        // Punto 2: Parpadeo
        StartCoroutine(EfectoParpadeo());

        // Si es el Jefe, aquí enviaremos el dato a la barra grande (lo vemos luego)

        if (vidaActual <= 0) {
            Morir();
        }
    }

    void Morir() {
        // Punto 1: Animación de muerte
        if (anim != null) { //Para el componente de animación
            anim.SetTrigger("Murió"); // Nombre del gatillo en el Animator
        }

        if (esJugador) {
            Debug.Log("GAME OVER");
            gameObject.SetActive(false);
            // Aquí llamarías a reiniciar nivel
        } else {
            GameObject barra = GameObject.Find("BarraVidaenemigos");
            if (barra != null) barra.SetActive(false);
            // Si es enemigo, esperamos un poco para que se vea la animación y luego destruimos
            Invoke("DestruirObjeto", 0.5f); 
        }
    }

    void DestruirObjeto() {
        Destroy(gameObject);
    }

    // Lógica del Parpadeo
    IEnumerator EfectoParpadeo() {
        if (spritePersonaje != null) {
            spritePersonaje.color = colorDaño; // Se pone rojo
            yield return new WaitForSeconds(0.1f); // Espera un suspiro
            spritePersonaje.color = colorOriginal; // Vuelve a la normalidad
        }
    }
}