using UnityEngine;
using UnityEngine.UI;

public class PedestalHealth : HealthManagement
{

    public Text healthDisplay;
    public bool isDead = false;

    void Update()
    {
        healthDisplay.text = "Pedestal Health: " + Health + "%";
    }

    public override void Die()
    {
        isDead = true;
    }
}
