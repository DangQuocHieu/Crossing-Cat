using CrossingCat;
using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("----------------Car Spawner Configuration---------------")]
    [SerializeField] private CarController[] carPrefabs;
    [SerializeField] private int laneCount;
    [SerializeField] private float carSpawnOffset = 1.5f;
    [SerializeField] private float zCarSpawnPosition;
    [SerializeField] private float minSpawnInterval;
    [SerializeField] private float maxSpawnInterval;
   
    private void Start()
    {
        StartCoroutine(SpawnCarRoutine());
    }
    private IEnumerator SpawnCarRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
            SpawnNewCar();
        }
    }

    private void SpawnNewCar()
    {
        CarController currentCar = carPrefabs[Random.Range(0, carPrefabs.Length)];
        int randomLane = Random.Range(0, laneCount);
        Vector3 spawnPosition = new Vector3(randomLane * carSpawnOffset, currentCar.transform.position.y, zCarSpawnPosition);
        Instantiate(currentCar, spawnPosition, currentCar.transform.rotation);
    }
}
