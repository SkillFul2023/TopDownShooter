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
        [SerializeField] private CharacterAction characterAction;

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

            characterAction = GetComponent<CharacterAction>();
        }
        private void OnEnable()
        {
            characterAction.characterReadyForAttackState += OnChangeCharacterStateReadyForAttack;
            characterAction.characterIdleState += OnChangeCharacterStateIdle;
        }
        private void OnDisable()
        {
            characterAction.characterReadyForAttackState -= OnChangeCharacterStateReadyForAttack;
            characterAction.characterIdleState -= OnChangeCharacterStateIdle;
        }
        private void Start()
        {
            CharacterStateMachine.Initialize(CharacterIdleState);
        }
        private void Update()
        {
            currentHealth.fillAmount = (float)HealthValue / GetMaxHealthValue;
        }
        public void SetCurrentState(CharacterStateEnum currentState)
        {
            characterStateEnum = currentState;
        }
        private void OnChangeCharacterStateReadyForAttack()
        {
            CharacterStateMachine.ChangeState(CharacterReadyForAttackState);
        }
        private void OnChangeCharacterStateIdle()
        {
            CharacterStateMachine.ChangeState(CharacterIdleState);
        }

    }
}
