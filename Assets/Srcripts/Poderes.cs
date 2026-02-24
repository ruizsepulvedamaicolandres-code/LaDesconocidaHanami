using UnityEngine;

public class Poderes : MonoBehaviour 
{
    public float danyoBala = 10f;
    
    // Aquí es donde escribes el TAG en Unity (ej: "Enemigo" o "Player")
    public string etiquetaAAtacar; 

    void OnTriggerEnter2D(Collider2D otro) 
    {
        // 1. ¿El objeto que toqué tiene el TAG que busco?
        if (otro.CompareTag(etiquetaAAtacar)) 
        {
            
            // 2. Intentamos buscar su "Ficha Médica" (SistemaVida)
            SistemaVida vida = otro.GetComponent<SistemaVida>();
            
            // 3. Si tiene vida, le quitamos puntos
            if (vida != null) 
            {
                vida.RecibirDano(danyoBala);
            }

            // 4. La bala se destruye porque ya impactó
            Destroy(gameObject);
        }
        
        // OJO: Si choca con una PARED (Tag "Pared"), también se destruye
        if (otro.CompareTag("Wall")) 
        {
            Destroy(gameObject);
        }
    }
}
