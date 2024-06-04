using UnityEngine;

public class Player2AntiCollider : MonoBehaviour
{
    public GameObject Ceil;
    public float fixedYPosition = 8f; 

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collision is with the invisible ceiling
        if (collision.gameObject == Ceil)
        
        {
            //Ignore collision with the invisible ceiling
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    void Update()
    {
        //set y position as a constant
        Vector3 newPosition = transform.position;
        newPosition.y = fixedYPosition;
        transform.position = newPosition;
    }
}