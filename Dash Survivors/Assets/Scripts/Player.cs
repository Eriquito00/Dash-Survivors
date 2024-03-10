using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidad = 5f;
    public int maxHealth = 100;
    public Transform healthBarTransform;
    public SpriteRenderer healthBar;
    public static float vidaP = 100;
    public static float nuevoDaño;
    public GameObject panelPowerup;
    public GameObject panelGameOver;
    public GameObject flechaGameOver;
    public GameObject flechaPause;
    public GameObject panelPause;
    public static int powerUp1;
    public static int powerUp2;

    public static int weaponLevel;
    // Start is called before the first frame update
    void Start()
    {
        EnemyN1.killslvl1 = 0;
        EnemyN2.killslvl2 = 0;
        EnemyN3.killslvl3 = 0;
        EnemyN1.incremento = 0;
        EnemyN2.incremento = 0;
        EnemyN3.incremento = 0;
        nuevoDaño = 0;
        powerUp1 = 0;
        powerUp2 = 0;
        weaponLevel = 0;
        vidaP = 100;
        maxHealth = 100;
        panelPowerup.SetActive(false);
        panelGameOver.SetActive(false);
        flechaGameOver.SetActive(false);
        panelPause.SetActive(false);
        PuntoAtaqueN2.cooldownBala = 1.5f;
        PuntoAtaqueN3.cooldownBala = 1.5f;
        PuntoAtaque.cooldownBala = 0.75f;
        EnemyN1.velocidadE = 2.5f;
        EnemyN2.velocidadE = 2f;
        EnemyN3.moveSpeed = 3.25f;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, vertical, 0);
        transform.Translate(movimiento * velocidad * Time.deltaTime);

        /*Placeholder de barra de vida luego se cambia */ float healthPercentage = (float)vidaP / maxHealth;
        healthBarTransform.transform.localScale = new Vector3(healthPercentage * 6, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        if (vidaP >= 100)
        {
            vidaP = 100;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            panelPause.SetActive(true);
            flechaPause.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
        {
            flechaPause.SetActive(false);
            panelPause.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BalaE"))
        {
            vidaP--;
            if (vidaP <= 0)
            {
                panelGameOver.SetActive(true);
                flechaGameOver.SetActive(true);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            panelPowerup.SetActive(true);
            powerUp1 += 1;
        }
        if (collision.gameObject.CompareTag("PowerUp2"))
        {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        powerUp2 += 1;
        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo.GetComponent<EnemyN1>())
            {
                EnemyN1.killslvl1++;
            }
            else if (enemigo.GetComponent<EnemyN2>())
            {
                EnemyN2.killslvl2++;
            }
            else if (enemigo.GetComponent<EnemyN3>())
            {
                EnemyN3.killslvl3++;
            }
            Destroy(enemigo);
        }
        Destroy(collision.gameObject);
        }
    }
}