using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyN3 : MonoBehaviour
{
    public Transform player; 
    public GameObject puntoAtaque;
    public GameObject powerUp1;
    public GameObject powerUp2;
    public static float moveSpeed = 3.25f;
    public static float velExtra;
    private float stoppingDistance = 5f;
    public Transform childTransform; // Referencia al objeto hijo
    private int dodgeCount = 0; // Contador de esquivas
    private int maxDodges = 3; // Número máximo de esquivas
    private bool isDodging = false; // Add this line
    private float health;
    public float vidaInicial = 10;
    public static float incremento;
    private float dañoP = 1; // Add this line
    public static int killslvl3; // Add this line
    public SpriteRenderer healthBar; // Add this line
    public Transform healthBarTransform; // Add this line

    public int maxHealth = 10; // Add this line

    void Start()
    {
        health = vidaInicial + incremento;
        dodgeCount = maxDodges; // Inicializa el contador de esquivas
        player = GameObject.FindGameObjectWithTag("Player").transform; //Busca al jugador
    }
    void Update()
    {
        if (player != null) //Si el jugador no es nulo
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position); //Calcula la distancia entre el enemigo y el jugador
            if (distanceToPlayer > stoppingDistance && !isDodging) //Si la distancia es mayor que la distancia de parada y el enemigo no está esquivando
            {
                MoveTowardsPlayer(); //Mueve el enemigo hacia el jugador
            }
            else
            {
                StopMoving(); //Deja de moverse
            }

            // Make the child object look at the player
            Vector3 direction = player.position - childTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // Subtract 90 from the angle
            childTransform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Check if the player has fired
            if (PuntoAtaque.disparar)
            {
                StartCoroutine(Dodge());
            }
        }

        /*Placeholder de barra de vida luego se cambia */ float healthPercentage = (float)health / maxHealth;
        healthBarTransform.transform.localScale = new Vector3(healthPercentage * 5, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy collided with a bullet
        if (collision.gameObject.tag == "BalaP")
        {
            // Subtract the bullet damage from the enemy's health
            health -= dañoP;

            // Destroy the bullet
            Destroy(collision.gameObject);
        }

        // Check if the enemy collided with the player
        else if (collision.gameObject.tag == "Player")
        {
            // Subtract 1 from the enemy's health
            health -= 1;
        }

        // Check if the enemy's health is 0 or less
        if (health <= 0)
        {
            // Destroy the enemy
            Destroy(gameObject);
            killslvl3++;
            int randomNumero = Random.Range(1, 11);
            int randomNumero2 = Random.Range(1, 31);
            if (randomNumero2 == 3)
            {
                Instantiate(powerUp2, transform.position, Quaternion.identity);
            }
            else if (randomNumero == 3)
            {
                Instantiate(powerUp1, transform.position, Quaternion.identity);
            }
        }
    }
    private void MoveTowardsPlayer() //Mueve el enemigo hacia el jugador
    {
        puntoAtaque.SetActive(false);
        Vector2 direction = (player.position - transform.position).normalized; //Calcula la dirección hacia el jugador
        transform.Translate(direction * moveSpeed * Time.deltaTime); //Mueve el enemigo hacia el jugador
    }
    private IEnumerator ReloadDodge()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Reload one dodge if the dodge count is less than the maximum
        if (dodgeCount < maxDodges)
        {
            dodgeCount++;
        }
    }

    private IEnumerator Dodge()
    {
        // Check if the enemy has dodged the maximum number of times
        if (dodgeCount > 0)
        {
            isDodging = true;

            // Calculate the direction to the player
            Vector2 directionToPlayer = (player.position - transform.position).normalized;

            // Calculate a direction that is perpendicular to the direction to the player
            Vector2 dodgeDirection = new Vector2(-directionToPlayer.y, directionToPlayer.x);

            // Randomly choose whether to dodge to the left or the right
            if (Random.Range(0, 2) == 0)
            {
                dodgeDirection = -dodgeDirection;
            }

            // Dodge for 0.5 seconds
            float dodgeTime = 0.5f;
            while (dodgeTime > 0)
            {
                // Move the enemy in the dodge direction at half the move speed
                transform.Translate(dodgeDirection * (moveSpeed / 2) * Time.deltaTime);

                // Decrease the remaining dodge time
                dodgeTime -= Time.deltaTime;

                // Yield control to the next frame
                yield return null;
            }

            // Decrement the dodge count
            dodgeCount--;

            // Start the reload dodge coroutine
            StartCoroutine(ReloadDodge());
            isDodging = false;
        }
    }


        private void StopMoving() //Deja de moverse
    {
        puntoAtaque.SetActive(true);
        transform.Translate(Vector2.zero); //Deja de moverse
    }
}