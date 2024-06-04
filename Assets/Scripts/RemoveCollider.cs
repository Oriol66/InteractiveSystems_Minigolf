using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    public GameObject bubblePrefab; 
    public List<Transform> bubbleSpawnPoints = new List<Transform>(); 
    public GameObject boxCollider; 
    public float time = 10f;

    private List<GameObject> spawnedBubbles = new List<GameObject>(); 
    private bool isBubbleTouched = false;
    private int bubblesTouchedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ball") && !isBubbleTouched)
        {
            //Generating the bubbles to be touched
            isBubbleTouched = true;
            StartCoroutine(SpawnBubbles());
        }
    }

    private IEnumerator SpawnBubbles()
    {
        Debug.Log("Generating Bubbles");

        if (bubblePrefab == null)
        {
            Debug.LogError("bubblePrefab is not assigned");
            yield break;
        }

        //Iterate over the spawn points
        foreach (Transform spawnPoint in bubbleSpawnPoints)
        {
            if (spawnPoint == null)
            {
                Debug.LogError("A spawn point is not assigned");
                continue;
            }

            //Instantiate a bubble at the current spawn point and add it to the list
            GameObject bubble = Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedBubbles.Add(bubble);

            Bubble bubbleComponent = bubble.GetComponent<Bubble>();
            if (bubbleComponent == null)
            {
                Debug.LogError("prefab doesn't contain the component bubble");
                continue;
            }

            bubbleComponent.SetSpawner(this);
            
        }

        yield return new WaitForSeconds(time);
        DisappearBubbles();
    }

    private void DisappearBubbles()
    {
        Debug.Log("Desappearing bubbles");
        if (bubblesTouchedCount < bubbleSpawnPoints.Count)
        {
            foreach (GameObject bubble in spawnedBubbles)
            {
                if (bubble != null)
                {
                    Destroy(bubble);
                }
            }

            //The box collider remains active if the objects were not touched
            boxCollider.SetActive(true);
        }
        else
        {
            boxCollider.SetActive(false);

            //Reproduce a sound when the collider is removed
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayPopOutCollider();
            }
        }

        spawnedBubbles.Clear();
        bubblesTouchedCount = 0; 
        isBubbleTouched = false; 
    }


    public void BubbleTouched(GameObject touchedBubble)
    {
        Destroy(touchedBubble);
        spawnedBubbles.Remove(touchedBubble);
        bubblesTouchedCount++;

        //Check if all the bubbles have been touched
        if (bubblesTouchedCount == bubbleSpawnPoints.Count)
        {
            boxCollider.SetActive(false);

            //Reproduce a sound when the collider is removed
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayPopOutCollider();
            }
        }
    }
}