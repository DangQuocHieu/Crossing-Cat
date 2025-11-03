namespace CrossingCat
{
    using System.Collections;
    using UnityEngine;

    public class TrafficLane : MonoBehaviour
    {
        [Range(0f, 20f)]
        public float carSpeedInLane;

        [Range(0f, 10f)]
        public float spawnInterval;

        [Range(0, 100)]
        public int minCarInWave;

        [Range(0, 100)]
        public int maxCarInWave;

        public int currentCarInWave;
    }
}

