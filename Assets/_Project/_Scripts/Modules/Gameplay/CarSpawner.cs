namespace CrossingCat
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] private List<TrafficLane> trafficLanes;
        [SerializeField] private CarController[] carPrefabs;

        public void StartSpawnCars() 
        {
            foreach(var lane in trafficLanes)
            {
                StartCoroutine(SpawnCarRoutine(lane)); 
            }
        }

        private IEnumerator SpawnCarRoutine(TrafficLane trafficLane)
        {
            while(true)
            {
                if(trafficLane.currentCarInWave == 0)
                {
                    trafficLane.currentCarInWave = Random.Range(trafficLane.minCarInWave, trafficLane.maxCarInWave + 1);
                }
                else
                {
                    SpawnNewCar(trafficLane);
                    --trafficLane.currentCarInWave;
                }
                yield return new WaitForSeconds(trafficLane.spawnInterval);
            }
        }

        private void SpawnNewCar(TrafficLane trafficLane)
        {
            CarController carPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
            CarController currentCar = GameplayManager.Instance.carPool.Get(carPrefab, trafficLane.transform.position, carPrefab.transform.rotation, trafficLane.transform);
            currentCar.carSpeed = trafficLane.carSpeedInLane;

        }
    }
}

