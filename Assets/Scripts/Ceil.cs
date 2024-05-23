using UnityEngine;

public class TechoInvisibleScript : MonoBehaviour
{
    public Transform fondoDeEscena; // Transform de un objeto en la parte inferior de la escena

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            Rigidbody pelotaRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (pelotaRigidbody != null)
            {
                // Invertir la velocidad en el eje Y para hacer que la pelota rebote
                pelotaRigidbody.velocity = new Vector3(pelotaRigidbody.velocity.x, -pelotaRigidbody.velocity.y, pelotaRigidbody.velocity.z);

                // Posicionar la pelota en la parte inferior de la escena
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, fondoDeEscena.position.y, collision.gameObject.transform.position.z);
            }
        }
    }
}