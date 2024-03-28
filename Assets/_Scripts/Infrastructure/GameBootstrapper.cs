using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace TopDownShooter.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game();
            DontDestroyOnLoad(this);
        }

    }

}

