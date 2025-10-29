namespace CrossingCat
{
    using UnityEngine;

    public class GameplayManager : Singleton<GameplayManager>
    {
        [Header("---------------References---------------")]
        public PlayerController playerController;
        public CarSpawner carSpawner;

    }

}
