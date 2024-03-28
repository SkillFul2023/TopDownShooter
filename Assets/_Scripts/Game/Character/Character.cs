using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Animation;
using TopDownShooter.Enums;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterState characterState;
        [SerializeField] private CharacterAnimationHelper characterAnimationHelper;

        public StateMachine StateMachine;
        public IdleState IdleState;
        public ReadyForAttackState ReadyForAttackState;

        public CharacterAnimationHelper GetCharacterAnimationHelper
        {
            get => characterAnimationHelper;
        }
        private void Awake()
        {
            StateMachine = new StateMachine();
            IdleState = new IdleState(this, StateMachine);
            ReadyForAttackState = new ReadyForAttackState(this, StateMachine);
        }
        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

    }
}
