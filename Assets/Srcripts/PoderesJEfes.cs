using UnityEngine;

public class PoderesJEfes : MonoBehaviour
{
    public enum TipoPoder { Rafaga, Circular, Escopeta }
    public TipoPoder poderActual;

    public Bullet prefabBala;
    public Transform puntaArma;

    public void EjecutarPoder(Vector2 direccionJugador) {
        switch (poderActual) {
            case TipoPoder.Rafaga:
                // Dispara 3 balas seguidas (puedes usar una Corrutina)
                Invoke("Disparar", 0.1f);
                Invoke("Disparar", 0.2f);
                Invoke("Disparar", 0.3f);
                break;

            case TipoPoder.Circular:
                // Dispara balas en todas las direcciones (360 grados)
                for (int i = 0; i < 8; i++) {
                    float angulo = i * 45f;
                    Quaternion rotacion = Quaternion.Euler(0, 0, angulo);
                    Bullet bala = Instantiate(prefabBala, puntaArma.position, rotacion);
                    bala.Shoot(rotacion * Vector2.up);
                }
                break;

            case TipoPoder.Escopeta:
                // Dispara 3 balas en abanico
                float[] angulos = { -15f, 0f, 15f };
                foreach (float a in angulos) {
                    Quaternion rot = Quaternion.Euler(0, 0, transform.eulerAngles.z + a);
                    Bullet b = Instantiate(prefabBala, puntaArma.position, rot);
                    b.Shoot(rot * Vector2.up);
                }
                break;
        }
    }

    void Disparar() {
        Bullet b = Instantiate(prefabBala, puntaArma.position, puntaArma.rotation);
        b.Shoot(puntaArma.up);
    }
}
