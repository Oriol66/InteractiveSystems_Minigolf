using UnityEngine;

public class Kick : MonoBehaviour
{
    public float hitForce = 10f; // Fuerza que se aplicará a la pelota

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Driver"))
        {
            Debug.Log("Colisión con el Driver detectada");

            Rigidbody pelotaRigidbody = GetComponent<Rigidbody>();
            if (pelotaRigidbody == null)
            {
                Debug.LogError("Rigidbody en la pelota es null");
                return;
            }

            Driver driverScript = collision.gameObject.GetComponent<Driver>();
            if (driverScript == null)
            {
                Debug.LogError("DriverScript en el Driver es null");
                return;
            }

            // Obtener la posición del Driver hace 0.5 segundos
            Vector3 previousDriverPosition = driverScript.GetPreviousPosition(0.5f);

            // Calcular la dirección del golpe
            Vector3 hitDirection = collision.contacts[0].point - previousDriverPosition;
            hitDirection = hitDirection.normalized;
            Debug.Log("Dirección del golpe: " + hitDirection);

            // Aplicar la fuerza a la pelota
            pelotaRigidbody.AddForce(hitDirection * hitForce, ForceMode.Impulse);
            Debug.Log("Fuerza aplicada a la pelota: " + hitDirection * hitForce);
        }
    }
}