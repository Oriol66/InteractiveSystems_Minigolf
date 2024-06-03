using UnityEngine;

public class Kick : MonoBehaviour
{
    public float hitForce = 10f; 
    public float secondsVector = 0.5f;
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("Driver"))
        {

            Rigidbody pelotaRigidbody = GetComponent<Rigidbody>();
            if (pelotaRigidbody == null)
            {
                return;
            }

            Driver driverScript = collision.gameObject.GetComponent<Driver>();
            if (driverScript == null)
            {
                Debug.LogError("DriverScript en el Driver es null");
                return;
            }

            // Obtain last position 
            Vector3 previousDriverPosition = driverScript.GetPreviousPosition(secondsVector);

            // Kick direction
            Vector3 hitDirection = collision.contacts[0].point - previousDriverPosition;
            hitDirection = hitDirection.normalized;
            //Debug.Log("Kick direction: " + hitDirection);

            // Apply force
            pelotaRigidbody.AddForce(hitDirection * hitForce, ForceMode.Impulse);

            GameManager.Instance.IncrementCollisionCount();

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayCollisionSound();
            }
        }
    }
}