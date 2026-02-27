using TMPro;
using UnityEngine;

public class AimedShot: MonoBehaviour
{
    [SerializeField] private Bullet bullet1;
    [SerializeField] private Bullet bullet2;
    [SerializeField] private Bullet bullet3;
    [SerializeField] private Bullet bullet4;

    [SerializeField] private Bullet strongAttack;
    [SerializeField] private Bullet specialAttack;

    [SerializeField] private float bulletInterval1;
    [SerializeField] private float bulletInterval2;
    [SerializeField] private float bulletInterval3;
    [SerializeField] private float bulletInterval4;

    [SerializeField] private float strongAttackInterval;
    [SerializeField] private float specialAttackInterval;

    [SerializeField] private Transform shotPosition;

    private Bullet bulletActual;

    private float bulletIntervalCurrent;
    private float nextShootTime;
    private Camera camera;

    public PoderPlayer sistemaPoderPlayer;

    private void Start()
    {
        camera = Camera.main;

        bulletActual = bullet1;
        bulletIntervalCurrent = bulletInterval1;
    }

    private void Update()
    {
        Pointed();
        ChangeBullet();
        Shot();
    }
    private void Pointed()
    {
        Vector2 mouseWorldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        transform.up = direction;
    }

 
    public void ChangeBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bulletActual == bullet1)
            {
                bulletActual = bullet2;
                bulletIntervalCurrent = bulletInterval2;
            }
            else
            {
                bulletActual = bullet1;
                bulletIntervalCurrent = bulletInterval1;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (bulletActual == bullet1 || bulletActual == bullet2)
            {
                bulletActual = bullet3;
                bulletIntervalCurrent = bulletInterval3;
            }
            else if (bulletActual == bullet3)
            {
                bulletActual = bullet4;
                bulletIntervalCurrent = bulletInterval4;
            }
            else if (bulletActual == bullet4)
            {
                bulletActual = bullet3;
                bulletIntervalCurrent = bulletInterval3;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Time.time > nextShootTime)
            {
                if (sistemaPoderPlayer.PuedeUsarStrong())
                {
                    DispararEspecial(strongAttack);
                    sistemaPoderPlayer.UsarStrong();

                    nextShootTime = Time.time + strongAttackInterval;
                }
            }
        }
    }

    void DispararEspecial(Bullet bala)
    {
        Bullet bullet = Instantiate(bala, shotPosition.position, transform.rotation);
        bullet.Shoot(transform.up);
    }
    private void Shot()
    {

        if (Input.GetMouseButton(0))
        {

            if (Time.time > nextShootTime)
            {
                Bullet bullet = Instantiate(bulletActual, shotPosition.position, transform.rotation);
                bullet.Shoot(transform.up);

                nextShootTime = Time.time + bulletIntervalCurrent;
            }

        }
    }





}
