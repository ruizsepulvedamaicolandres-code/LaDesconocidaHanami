using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedBullet;

    [SerializeField] private float destroyTime;
    private Rigidbody2D bulletRigidbody2D;

    private void Awake()
    {
        bulletRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        bulletRigidbody2D.linearVelocity = direction * speedBullet;
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ---  Lógica de Daño ---
        SistemaVida vida = collision.gameObject.GetComponent<SistemaVida>();
        if (vida != null) {
            vida.RecibirDano(10); // Puedes crear una variable para el daño si quieres
        }
        // -----------------------------
        Destroy(gameObject);
    }
}

