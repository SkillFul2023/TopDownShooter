using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using TopDownShooter.Gameplay;
using UnityEngine;

namespace TopDownShooter.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Character character;
        [SerializeField] private GameObject endGamePanel;

        private Game _game;

        public Canvas GetCanvas
        {
            get => canvas;
        }
        private void Awake()
        {
            canvas = FindObjectOfType<Canvas>();
            _game = new Game();
            DontDestroyOnLoad(this);
        }
        private void Update()
        {
            if(character.HealthValue <= 0)
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

}

