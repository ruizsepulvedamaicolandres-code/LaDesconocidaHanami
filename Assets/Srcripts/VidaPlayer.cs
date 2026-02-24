using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour 
{
    public Slider sliderVida;
    public SistemaVida sistemaVidaPlayer; // Arrastra al Player aquí
    
    [Header("Ajustes de Regeneración")]
    public float tiempoParaRegenerar = 10f;
    private float cronometroRegen;
    private float vidaUltimoFrame;

    void Start() {
        sliderVida.maxValue = sistemaVidaPlayer.vidaMax;
        vidaUltimoFrame = sistemaVidaPlayer.vidaActual;
    }

    void Update() {
        // Actualizar la barra visualmente
        sliderVida.value = sistemaVidaPlayer.vidaActual;

        // Lógica de Regeneración
        if (sistemaVidaPlayer.vidaActual < sistemaVidaPlayer.vidaMax) {
            // Si recibimos daño, el cronómetro se reinicia
            if (sistemaVidaPlayer.vidaActual < vidaUltimoFrame) {
                cronometroRegen = 0;
            }

            cronometroRegen += Time.deltaTime;

            // Si pasan los X segundos sin recibir daño, curar al máximo
            if (cronometroRegen >= tiempoParaRegenerar) {
                sistemaVidaPlayer.vidaActual = sistemaVidaPlayer.vidaMax;
                cronometroRegen = 0; // Resetear para la próxima vez
            }
        }

        vidaUltimoFrame = sistemaVidaPlayer.vidaActual;
    }
}