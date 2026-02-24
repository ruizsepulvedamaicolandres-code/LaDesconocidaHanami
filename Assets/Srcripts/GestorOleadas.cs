using UnityEngine;

public class GestorOleadas : MonoBehaviour {
    public GameObject jefeFinal; // Arrastra tu Prefab de Jefe aquí
    public Transform puntoAparicionJefe;
    
    private bool jefeInvocado = false;

    void Update() {
        // Buscamos cuántos enemigos con el script SistemaVida quedan en la escena
        // Excluimos al jugador y al jefe si ya salió
        int enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemigosRestantes <= 0 && !jefeInvocado) {
            InvocarJefe();
        }
    }

    void InvocarJefe() {
        jefeInvocado = true;
        Debug.Log("¡Todos los subenemigos derrotados! Aparece el JEFE.");
        
        if (jefeFinal != null && puntoAparicionJefe != null) {
            Instantiate(jefeFinal, puntoAparicionJefe.position, Quaternion.identity);
            // Aquí podrías activar también la música de jefe
        }
    }
}