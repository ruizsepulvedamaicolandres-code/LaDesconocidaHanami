using UnityEngine;
using UnityEngine.UI;

public class PoderPlayer : MonoBehaviour 
{
   
    public Slider sliderPoder;

    
    private float poderMax = 100f;
    private float poderActual = 0f;

    
   [SerializeField] private float costoStrongAttack = 50f;
   [SerializeField] float costoSpecialAttack = 100f;

    void Start()
    {
        sliderPoder.maxValue = poderMax;
        sliderPoder.value = poderActual;
    }

    void Update()
    {
        sliderPoder.value = poderActual;
    }

    // ESTE MÉTODO SE LLAMA CUANDO EL JUGADOR HACE DAÑO
    public void AgregarPoder(float cantidad)
    {
        poderActual += cantidad;
        poderActual = Mathf.Clamp(poderActual, 0, poderMax);

        Debug.Log("PODER ACTUAL: " + poderActual);

        sliderPoder.value = poderActual;
    }

    public bool PuedeUsarStrong()
    {
        return poderActual >= costoStrongAttack;
    }

    public bool PuedeUsarSpecial()
    {
        return poderActual >= costoSpecialAttack;
    }

    public void UsarStrong()
    {
        if (PuedeUsarStrong())
        {
            poderActual -= costoStrongAttack;
        }
    }

    public void UsarSpecial()
    {
        if (PuedeUsarSpecial())
        {
            poderActual -= costoSpecialAttack;
        }
    }
}