using System;
using UnityEngine;

namespace Code
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private FollowCamera _camera;

        private void Awake()
        {
            Transform playerTransform = _itemSpawner.Spawn(this);

            _camera.Follow(playerTransform);
        }

        public void Win()
        {
            throw new NotImplementedException();
        }

        public void Lose()
        {
            throw new NotImplementedException();
        }
    }
}