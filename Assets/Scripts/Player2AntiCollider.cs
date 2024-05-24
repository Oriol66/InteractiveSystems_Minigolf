using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    // Referencia al techo invisible
    public GameObject Ceil;
    public float fixedYPosition = 8f; // Fixed position

    // Método llamado cuando el jugador colisiona con otros objetos
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con el techo invisible
        if (collision.gameObject == Ceil)
        
        {
            // Ignora la colisión con el techo invisible
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    void Update()
    {
        // set y position constant
        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;
    }
}