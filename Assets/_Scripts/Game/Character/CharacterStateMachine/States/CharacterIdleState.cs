using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public class CharacterIdleState : CharacterState
    {
        private string animationName = "Idle";
        public CharacterIdleState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            StateName = CharacterStateEnum.Idle;
            character.SetCurrentState(StateName);
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit()
        {
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}

