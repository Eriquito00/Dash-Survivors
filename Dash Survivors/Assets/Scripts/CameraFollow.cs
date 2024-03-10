using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public List<BoxCollider2D> mapBounds; // Lista de BoxCollider2D que representan los límites del mapa
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - jugador.position;
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 desiredPosition = jugador.position + offset;

            // Calcula la mitad del tamaño de la cámara
            float camHalfHeight = UnityEngine.Camera.main.orthographicSize;
            float camHalfWidth = UnityEngine.Camera.main.aspect * camHalfHeight;

            // Inicializa los límites mínimos y máximos permitidos para la cámara
            float minX = float.PositiveInfinity, maxX = float.NegativeInfinity, minY = float.PositiveInfinity, maxY = float.NegativeInfinity;

            // Verifica si la nueva posición está dentro de los límites de cualquiera de los BoxCollider2D del mapa
            foreach (BoxCollider2D bounds in mapBounds)
            {
                // Ajusta los límites del mapa para tener en cuenta el tamaño de la cámara
                minX = Mathf.Min(minX, bounds.bounds.min.x + camHalfWidth);
                maxX = Mathf.Max(maxX, bounds.bounds.max.x - camHalfWidth);
                minY = Mathf.Min(minY, bounds.bounds.min.y + camHalfHeight);
                maxY = Mathf.Max(maxY, bounds.bounds.max.y - camHalfHeight);
            }

            // Ajusta los límites para evitar que se vea más allá de los límites del mapa
            float adjustment = 0.2f; // Puedes ajustar este valor según sea necesario
            minX += adjustment;
            maxX -= adjustment;
            minY += adjustment;
            maxY -= adjustment;

            // Asegura que la cámara siempre se mantenga dentro de los límites del mapa
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            transform.position = desiredPosition;
        }
    }
}

