using UnityEngine;
using System.Collections; // Añade esta línea

public class PuntoAtaque : MonoBehaviour
{
    public GameObject balaPP;
    public Transform puntoAtaque;
    private float velocidadBala = 10f;
    public static float cooldownBala = 0.75f;
    public static float ultimoDisparo;
    private float rangoDisparo = 10f;
    public static bool disparar = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Time.time >= ultimoDisparo + cooldownBala)
        {
            ultimoDisparo = Time.time;
            Disparo();
        }
    }
    void Disparo()
    {
        disparar = true;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject enemigoMasCercano = null;
        float distanciaMasCercana = Mathf.Infinity;
        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMasCercana)
            {
                distanciaMasCercana = distancia;
                enemigoMasCercano = enemigo;
            }
        }
        if (enemigoMasCercano != null && distanciaMasCercana <= rangoDisparo)
        {
            Vector3 direccion = (enemigoMasCercano.transform.position - puntoAtaque.position).normalized;
            GameObject bala = Instantiate(balaPP, puntoAtaque.position, Quaternion.LookRotation(Vector3.forward, direccion));
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            rb.velocity = direccion * velocidadBala;
        }
        StartCoroutine(ResetDisparar());
    }
    private IEnumerator ResetDisparar()
    {
        yield return new WaitForSeconds(1f);
        disparar = false;
    }
}