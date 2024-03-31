using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Enums;
using UnityEngine;
namespace TopDownShooter.Gameplay
{
    public class CharacterReadyForAttackState : CharacterState
    {
        private string animationName = "ReadyForAttack";
        public CharacterReadyForAttackState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            StateName = CharacterStateEnum.ReadyForAttack;
            character.SetCurrentState(StateName);
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit()
        {
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}


