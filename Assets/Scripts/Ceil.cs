using UnityEngine;

public class TechoInvisibleScript : MonoBehaviour
{
    public Transform fondoDeEscena;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            Rigidbody pelotaRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (pelotaRigidbody != null)
            {
                //Invert the velocity on the Y-axis to make the ball bounce
                pelotaRigidbody.velocity = new Vector3(pelotaRigidbody.velocity.x, -pelotaRigidbody.velocity.y, pelotaRigidbody.velocity.z);

                //Position the ball at the bottom of the scene
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, fondoDeEscena.position.y, collision.gameObject.transform.position.z);
            }
        }
    }
}