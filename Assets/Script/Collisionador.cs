using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas y reiniciar
using UnityEngine.UI; // Para manejar la interfaz de usuario (UI)

public class GameOverCollider : MonoBehaviour
{
    private int collisionCount = 0; // Contador de colisiones
    public int targetCollisions = 5; // Número de colisiones necesarias para terminar el juego
    public Text gameOverText; // Referencia al texto que mostrará el mensaje

    // Este método se llama cuando otro objeto con Collider2D entra en contacto con este objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es uno de los 'itemGood'
        if (other.CompareTag("itemGood"))
        {
            collisionCount++; // Incrementa el contador de colisiones
            Debug.Log("Colisiones: " + collisionCount);

            // Si alcanzamos el número de colisiones necesarias, finalizamos el juego
            if (collisionCount >= targetCollisions)
            {
                EndGame();
            }
        }
    }

    // Método para finalizar el juego
    void EndGame()
    {
        Debug.Log("¡Has perdido!");
        
        // Mostrar mensaje de fin de juego
        if (gameOverText != null)
        {
            gameOverText.text = "¡Has perdido!";
        }
        
        // Opcional: Reiniciar la escena o salir del juego
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
        Application.Quit(); // Cierra la aplicación (útil para la compilación final)
    }
}
