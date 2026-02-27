using UnityEngine;
using UnityEngine.UI;
public class UIArms : MonoBehaviour
{

    public Image bullet1;
    public Image bullet2;
    public Image bullet3;
    public Image bullet4;

    public Image strongUI;
    public Image specialUI;


    public AimedShot aimedShot;
    public PoderPlayer poder;
    
    private Color colorActivo = Color.white;
    private Color colorInactivo = Color.gray;

    void Update()
    {
        ActualizarBalas();
        ActualizarPoderes();
    }

    void ActualizarBalas()
    {
        int balaActual = aimedShot.GetBulletActual();

        if (balaActual == 1)
        {
            bullet1.color = colorActivo;
        }
        else
        {
            bullet1.color = colorInactivo;
        }

        if (balaActual == 2)
        {
            bullet2.color = colorActivo;
        }
        else
        {
            bullet2.color = colorInactivo;
        }

     
        if (balaActual == 3)
        {
            bullet3.color = colorActivo;
        }
        else
        {
            bullet3.color = colorInactivo;
        }

       
        if (balaActual == 4)
        {
            bullet4.color = colorActivo;
        }
        else
        {
            bullet4.color = colorInactivo;
        }
    }

    void ActualizarPoderes()
    {
        
        if (poder.PuedeUsarStrong())
        {
            strongUI.color = colorActivo;
        }
        else
        {
            strongUI.color = colorInactivo;
        }

      
        if (poder.PuedeUsarSpecial())
        {
            specialUI.color = colorActivo;
        }
        else
        {
            specialUI.color = colorInactivo;
        }
    }

}
