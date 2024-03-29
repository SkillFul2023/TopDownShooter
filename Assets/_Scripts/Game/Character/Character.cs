using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Animation;
using TopDownShooter.Enums;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class Character : Unit
    {
        [SerializeField] private CharacterStateEnum characterStateEnum;
        [SerializeField] private CharacterAnimationHelper characterAnimationHelper;

        public CharacterStateMachine CharacterStateMachine;
        public CharacterIdleState CharacterIdleState;
        public CharacterReadyForAttackState CharacterReadyForAttackState;

        public CharacterAnimationHelper GetCharacterAnimationHelper
        {
            get => characterAnimationHelper;
        }
        private void Awake()
        {
            CharacterStateMachine = new CharacterStateMachine();
            CharacterIdleState = new CharacterIdleState(this, CharacterStateMachine);
            CharacterReadyForAttackState = new CharacterReadyForAttackState(this, CharacterStateMachine);
        }
        private void Start()
        {
            CharacterStateMachine.Initialize(CharacterIdleState);
        }
        private void Update()
        {
            currentHealth.fillAmount = (float)HealthValue / GetMaxHealthValue;
        }

    }
}
