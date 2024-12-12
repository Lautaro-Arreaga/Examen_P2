using UnityEngine;
using UnityEngine.UI; // Necesario si deseas mostrar los puntos en la UI

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    private Rigidbody2D rb; // Referencia al Rigidbody2D del jugador
    private float moveInput; // Valor de entrada del movimiento

    public int points = 0; // Variable para llevar el puntaje
    public Text pointsText; // Referencia al texto de la UI para mostrar los puntos

    void Start()
    {
        // Obtiene la referencia al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener la entrada horizontal del jugador (A/D o las flechas)
        moveInput = Input.GetAxisRaw("Horizontal"); // -1 para izquierda, 1 para derecha

        // Mover al jugador
        MovePlayer();
    }

    void MovePlayer()
    {
        // Aplicar el movimiento al Rigidbody2D
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Solo afectamos el movimiento en X
    }

    // Método que se llama cuando el jugador entra en contacto con otro objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto con el que colisionó tiene la etiqueta "itemGood"
        if (other.CompareTag("itemGood"))
        {
            // Aumentar los puntos del jugador
            points++;

            // Actualizar el texto de puntos en la UI
            if (pointsText != null)
            {
                pointsText.text = "Puntos: " + points;
            }

            // Destruir el objeto "itemGood" después de la colisión
            Destroy(other.gameObject);
        }
    }
}
