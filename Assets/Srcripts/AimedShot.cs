using TMPro;
using UnityEngine;

public class AimedShot: MonoBehaviour
{
    [SerializeField] private Bullet bullet1;
    [SerializeField] private Bullet bullet2;
    [SerializeField] private Transform shotPosition;
     private Camera camera;
    private Bullet bulletActual;

    private void Start()
    {
        camera = Camera.main;

        bulletActual = bullet1;
    }

    private void Update()
    {
        Pointed();
        ChangeBullet();
        Shot();
    }
    private void Pointed()
    {
      Vector2 mouseWorldPoint  = camera.ScreenToWorldPoint(Input.mousePosition);
      Vector2 direction = mouseWorldPoint - (Vector2) transform.position;
      transform.up = direction;
    }

    private void ChangeBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bulletActual == bullet1)
            {
                bulletActual = bullet2;
            }
            else
            {
                bulletActual = bullet1;
            }
        }
    }
    private void Shot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Bullet bullet =Instantiate(bulletActual,shotPosition.position,transform.rotation);
            bullet.Shoot(transform.up);
        }
    }





}
