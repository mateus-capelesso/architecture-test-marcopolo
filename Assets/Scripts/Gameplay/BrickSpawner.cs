using System;
using UnityEngine;

namespace Gameplay
{
    public class BrickSpawner : MonoBehaviour
    {
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        public GameObject brickPrefab;

        private float _brickWidth = 1f;

        public void SpawnBricks(GamePlay gameplay, int bricks)
        {
            var distance = 0.35f;
            var offset = 0f;
            for (var i = 0; i < bricks; i++)
            {
                var brick = Instantiate(brickPrefab, transform);
                brick.transform.position = new Vector3(xMin + offset, 3.5f, 0f);
                brick.GetComponent<BrickController>().onBrickDestroyed.AddListener(gameplay.BrickDestroyed);

                offset += (_brickWidth + distance);
            }
        }
    }
}