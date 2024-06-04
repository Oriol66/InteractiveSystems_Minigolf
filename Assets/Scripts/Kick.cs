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
                Debug.LogError("DriverScript in Driver is null");
                return;
            }

            //Obtain last position 
            Vector3 previousDriverPosition = driverScript.GetPreviousPosition(secondsVector);

            //Compute the kick direction
            Vector3 hitDirection = collision.contacts[0].point - previousDriverPosition;
            hitDirection = hitDirection.normalized;

            //Apply force
            pelotaRigidbody.AddForce(hitDirection * hitForce, ForceMode.Impulse);

            //Increase the colision counter
            GameManager.Instance.IncrementCollisionCount();

            //Reproduce a sound each time the ball is kicked
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayCollisionSound();
            }
        }
    }
}