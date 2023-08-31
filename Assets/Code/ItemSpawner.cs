using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private float _playerStartHeight = -3f;
        [SerializeField] private float _objectOffset = 3f;
        [SerializeField] private int _minObstacleCount = 2;
        [SerializeField] private int _maxObstacleCount = 10;

        private ColorCollision _player;
        private FinishLine _finishLine;
        private ColorChanger _colorChanger;
        private List<Obstacle> _obstacles;

        private float _lastObjectHeight;

        private void Awake()
        {
            _player = Resources.Load<ColorCollision>("Prefabs/Player");
            _finishLine = Resources.Load<FinishLine>("Prefabs/Finish Line");
            _colorChanger = Resources.Load<ColorChanger>("Prefabs/ColorChanger");
            _obstacles = Resources.LoadAll<Obstacle>("Prefabs/Obstacles").ToList();
        }

        public Transform Spawn(GameHandler gameHandler)
        {
            int obstacleCount = Random.Range(_minObstacleCount, _maxObstacleCount + 1);

            ColorCollision player = Instantiate(_player, Vector3.up * _playerStartHeight, Quaternion.identity);
            player.Construct(gameHandler);
            _lastObjectHeight = player.transform.position.y;

            for (var i = 0; i < obstacleCount; i++)
            {
                ColorChanger colorChanger = Instantiate(_colorChanger, 
                    Vector3.up * (_lastObjectHeight + _objectOffset), Quaternion.identity);
                _lastObjectHeight = colorChanger.transform.position.y;

                Obstacle randomObstacle = _obstacles[Random.Range(0, _obstacles.Count)];
                Obstacle createdObstacle = Instantiate(randomObstacle,
                    Vector3.up * (_lastObjectHeight + _objectOffset), Quaternion.identity);
                _lastObjectHeight = createdObstacle.transform.position.y;
            }

            FinishLine finishLine = Instantiate(_finishLine, 
                Vector3.up * (_lastObjectHeight + _objectOffset), Quaternion.identity);
            finishLine.Construct(gameHandler);

            return player.transform;
        }
    }
}