using UnityEngine;

public class GeneradorOleadas : MonoBehaviour
{
   public GameObject enemigoPrefab;
    public Transform[] puntosAparicion;
    public float tiempoEntreEnemigos = 3f;
    public int enemigosPorOleada = 5;
    
    private int enemigosGenerados = 0;
    private float cronometro;

    void Update() 
    {
        if (enemigosGenerados < enemigosPorOleada) {
            cronometro -= Time.deltaTime;
            if (cronometro <= 0) {
                GenerarEnemigo();
                cronometro = tiempoEntreEnemigos;
            }
        }
    }

    void GenerarEnemigo() 
    {
        int indiceAleatorio = Random.Range(0, puntosAparicion.Length);
        Instantiate(enemigoPrefab, puntosAparicion[indiceAleatorio].position, Quaternion.identity);
        enemigosGenerados++;
    }
}
