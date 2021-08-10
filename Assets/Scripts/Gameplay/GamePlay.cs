using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class GamePlay : MonoBehaviour
    {
        public int lives = 3;
        public int bricks = 4;
    
        private int _score;
        private int _lives;

        [Header("Events")] 
        public UnityEvent onGameStart;
        public UnityEvent onGameReset;

        public Action<int> onScoreUpdate;
        public Action<int> onLivesUpdate;

        public void CallGameplay()
        {
            gameObject.SetActive(true);
            ResetGame();
        }

        public void CloseGameplay()
        {
            gameObject.SetActive(false);
        }

        private void ResetGame()
        {
            _score = 0;
            _lives = lives;

            ResetBallPosition();
        }

        private void ResetBallPosition()
        {
            try
            {
                onGameReset.Invoke();

                onScoreUpdate.Invoke(_score);
                onLivesUpdate.Invoke(_lives);

                StartCoroutine(StartGame());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(3f);

            try
            {
                onGameStart.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeathZone()
        {
            _lives--;

            ResetBallPosition();
            onLivesUpdate.Invoke(lives);
            DetectLose();
        }

        public void BrickDestroyed()
        {
            _score++;
            onScoreUpdate.Invoke(_score);
            DetectWin();
        }

        private void DetectWin()
        {
            if (_score != bricks) return;
            GameManager.Instance.GamePlayOver(true, _score);
        }

        private void DetectLose()
        {
            if (_lives > 0) return;
        
            GameManager.Instance.GamePlayOver(false, _score);
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _lives = 0;
                DetectLose();
            }
        
            if (Input.GetKeyDown(KeyCode.W))
            {
                _score = bricks;
                DetectWin();
            }
#endif
        }
    }
}