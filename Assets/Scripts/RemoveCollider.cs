using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    public GameObject bubblePrefab; // El prefab de la burbuja que aparecerá al impactar con la caja
    public List<Transform> bubbleSpawnPoints = new List<Transform>(); // Los puntos de spawn donde aparecerán las burbujas
    public GameObject boxCollider; // El collider que desaparecerá al tocar los objetos
    public float time = 10f; // Tiempo límite para tocar las burbujas
    private List<GameObject> spawnedBubbles = new List<GameObject>(); // Lista de burbujas instanciadas
    private bool isObjectTouched = false; // Indica si las burbujas han sido tocadas

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha colisionado con el collider");
        if (other.CompareTag("Ball")) // Verifica si el objeto que colisionó es la pelota
        {
            Debug.Log("Pelota ha impactado con el collider");
            StartCoroutine(SpawnBubbles());
        }
    }

    private IEnumerator SpawnBubbles()
    {
        Debug.Log("Generando burbujas");

        // Verificar si bubblePrefab está asignado
        if (bubblePrefab == null)
        {
            Debug.LogError("bubblePrefab no está asignado en el Inspector");
            yield break;
        }

        // Iterar sobre los puntos de spawn
        foreach (Transform spawnPoint in bubbleSpawnPoints)
        {
            // Verificar si el punto de spawn es nulo
            if (spawnPoint == null)
            {
                Debug.LogError("Un punto de spawn en bubbleSpawnPoints no está asignado");
                continue;
            }

            GameObject bubble = Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedBubbles.Add(bubble);

            // Verificar si la burbuja instanciada tiene el componente Bubble
            Bubble bubbleComponent = bubble.GetComponent<Bubble>();
            if (bubbleComponent == null)
            {
                Debug.LogError("El prefab de la burbuja no tiene el componente 'Bubble'");
                continue;
            }

            bubbleComponent.SetSpawner(this);
            
        }

        yield return new WaitForSeconds(time);
        DisappearBubbles();
    }

    private void DisappearBubbles()
    {
        Debug.Log("Desapareciendo burbujas");
        if (!isObjectTouched)
        {
            foreach (GameObject bubble in spawnedBubbles)
            {
                if (bubble != null)
                {
                    Destroy(bubble);
                }
            }
            boxCollider.SetActive(true); // El collider de la caja permanece activo si no se tocaron los objetos
        }
        else
        {
            boxCollider.SetActive(false); // Si los objetos fueron tocados, desactiva el collider de la caja
        }

        spawnedBubbles.Clear(); // Limpia la lista de objetos instanciados
    }

    public void BubbleTouched(GameObject touchedBubble)
    {
        isObjectTouched = true;
        Destroy(touchedBubble);
        spawnedBubbles.Remove(touchedBubble);

        if (spawnedBubbles.Count == 0)
        {
            boxCollider.SetActive(false);
            StopCoroutine(SpawnBubbles());
        }
    }
}