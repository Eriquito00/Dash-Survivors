using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesPowerUp : MonoBehaviour
{
    public GameObject panelPowerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PowerUp1()
    {
        Player.nuevoDaño += 0.5f;
        EnemyN1.velocidadE = EnemyN1.velExtra = 0.25f + EnemyN1.velocidadE;
        EnemyN2.velocidadE = EnemyN2.velExtra = 0.25f + EnemyN2.velocidadE;
        EnemyN3.moveSpeed = EnemyN3.velExtra = 0.25f + EnemyN3.moveSpeed;
        Player.weaponLevel += 1;
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
    public void PowerUp2()
    {
        PuntoAtaque.cooldownBala -= 0.05f;
        Player.weaponLevel += 1;
        if (PuntoAtaque.cooldownBala <= 0f)
        {
            PuntoAtaque.cooldownBala = 0.01f;
        }
        PuntoAtaqueN2.cooldownBala -= 0.1f;
        if (PuntoAtaqueN2.cooldownBala <= 0f)
        {
            PuntoAtaqueN2.cooldownBala = 0.01f;
        }
        PuntoAtaqueN3.cooldownBala -= 0.1f;
        if (PuntoAtaqueN3.cooldownBala <= 0f)
        {
            PuntoAtaqueN3.cooldownBala = 0.01f;
        }
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
    public void PowerUp3()
    {
        Player.vidaP = 25f + Player.vidaP;
        EnemyN1.incremento += 1;
        EnemyN2.incremento += 1;
        EnemyN3.incremento += 1;
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
}