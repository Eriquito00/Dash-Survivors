using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoAtaqueN2 : MonoBehaviour
{
    public GameObject balaEP;
    public Transform puntoAtaque;
    private float velocidadBala = 10f;
    public static float cooldownBala = 1.5f;
    public static float ultimoDisparo;
    private float rangoDisparo = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparo", 1f, cooldownBala);
    }
    void Update()
    {

    }
    void Disparo()
    {
            GameObject enemigo = GameObject.FindGameObjectWithTag("Player");
        if (enemigo != null)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia <= rangoDisparo)
            {
                Vector3 direccion = (enemigo.transform.position - puntoAtaque.position).normalized;
                GameObject bala = Instantiate(balaEP, puntoAtaque.position, Quaternion.LookRotation(Vector3.forward, direccion));
                Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
                rb.velocity = direccion * velocidadBala;
            }
        }
        
    }
}
