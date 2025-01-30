using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSpawner : MonoBehaviour
{
    public List<GameObject> FloorPrefabs;
    public List<GameObject> gameObjectsToMove;
    public Vector3 movementDirection = Vector3.forward; // Default direction: forward
    public float spawnSpacing = 30f;
    public float rampUpDuration = 5f; // Time in seconds for ramp-up
    public float targetValue = 10f;
    private float currentRampTime = 0f;
    public bool GameIsActive
    {
        get { return gameIsActive; }
        set
        {
            EndOfGame.Invoke();
            StopAllCoroutines();
            gameIsActive = value;
        }
    }
    private bool gameIsActive = true;//when set, invokes the end game event
    public UnityEvent EndOfGame = new UnityEvent();

    private void Start()
    {
        // Ensure the list is initialized.  Important if you're adding via inspector.
        if (gameObjectsToMove == null)
        {
            gameObjectsToMove = new List<GameObject>();
        }
        SpawnFloor();
        StartCoroutine(MoveFloorsCoroutine());
    }

    private void MoveGameObjects()
    {
        float scaledRateOfSpeed = RampedValue();
        if (gameObjectsToMove == null || gameObjectsToMove.Count == 0)
        {
            Debug.LogWarning("No GameObjects assigned to move.");
            return;
        }

        for (int i = 0; i < gameObjectsToMove.Count; i++)
        {
            if (gameObjectsToMove[i] != null) // Check for null objects in the list
            {
                gameObjectsToMove[i].transform.position += movementDirection * scaledRateOfSpeed * Time.deltaTime;
            }
            else
            {
                Debug.LogWarning($"GameObject at index {i} is null.  Consider removing it from the list.");
            }
        }

        //remove out of bounds boxed to free up space
        for (int i = 0; i < gameObjectsToMove.Count; i++)
        {
            if(gameObjectsToMove[i].transform.position.x <= -60) 
            {
                Destroy(gameObjectsToMove[i]);
                gameObjectsToMove.RemoveAt(i);

            }
        }
    }

    private void SpawnFloor()
    {
        if (FloorPrefabs == null || FloorPrefabs.Count == 0)
        {
            Debug.LogWarning("No GameObjects assigned to spawn.");
            return;
        }

        Vector3 spawnPosition = Vector3.right * spawnSpacing; // Start spawning at this GameObject's position offset by the spacing amount
        int randomPrefab = Random.Range(0, 3);

        if (FloorPrefabs[randomPrefab] != null)
        {
            GameObject newFloor = Instantiate(FloorPrefabs[randomPrefab], spawnPosition, Quaternion.identity);
            gameObjectsToMove.Add(newFloor);
        }
        else
        {
            Debug.LogWarning($"GameObject at index {randomPrefab} is null.  Consider removing it from the list.");
        }
        
    }

    private float RampedValue()
    {
        currentRampTime += Time.fixedDeltaTime;

        if (currentRampTime > rampUpDuration)
        {
            currentRampTime = rampUpDuration;
        }

        float t = currentRampTime / rampUpDuration;
        float smoothT = Mathf.SmoothStep(0f, 1f, t);

        return Mathf.Lerp(0f, targetValue, smoothT);
    }

    public void DEBUGTestRamp()
    {
        Debug.Log("Ramped Value: " + RampedValue());
    }

    //ienumaterable, calculate using fixed delta time what the total time to move the diastance is, then delay spawning til that time - some offset to ensure things are smooth
    private IEnumerator MoveFloorsCoroutine()
    {
        while (GameIsActive) // Check continuously
        {
            if (gameObjectsToMove != null)
            {
                for (int i = 0; i < gameObjectsToMove.Count; i++)
                {
                    if (gameObjectsToMove[i] != null) // Check for null references
                    {
                        // Assuming you want to check the Z position (you can change this)
                        if (gameObjectsToMove[0].transform.position.x < -28 && gameObjectsToMove.Count == 1)
                        {
                            SpawnFloor();
                            break; 
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Transform at index {i} is null. Consider removing it from the list.");
                    }
                }
            }
            MoveGameObjects();
            yield return null; // Wait for the next frame
        }
    }
}
