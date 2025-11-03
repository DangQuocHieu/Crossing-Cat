namespace CrossingCat
{
    using Unity.Cinemachine;
    using UnityEngine;

    public class GameplayManager : Singleton<GameplayManager>
    {
        public Enum.GameplayState currentState;

        [Header("---------------References---------------")]
        public CinemachineCamera mainCam;
        public PlayerController playerController;
        public CarSpawner carSpawner;
        public CarPool carPool;

        private void Start()
        {
            carPool.InitializePool();
            carSpawner.StartSpawnCars();
        }

        private void Update()
        {
            UpdateState(currentState);
        }

        public void ChangeState(Enum.GameplayState newState)
        {
            if(currentState == newState) return;
            ExitState(currentState);
            currentState = newState;
            EnterState(currentState);
        }

        private void EnterState(Enum.GameplayState state)
        {
            Debug.Log("Enter State: " + state.ToString());
            switch(state)
            {
                case Enum.GameplayState.Victory:
                    mainCam.Follow = null;
                    break;
                case Enum.GameplayState.Lose:
                    mainCam.Follow = null;
                    break;
            }

        }

        private void ExitState(Enum.GameplayState state)
        {
            switch(state)
            {
                case Enum.GameplayState.Victory:
                    break;
                case Enum.GameplayState.Lose:
                    break;
            }
        }

        private void UpdateState(Enum.GameplayState state)
        {
            switch(state)
            {
                case Enum.GameplayState.Victory:
                    break;
                case Enum.GameplayState.Lose:
                    break;
            }
        }

    }

}
