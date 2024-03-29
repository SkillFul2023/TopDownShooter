using System.Collections;
using System.Collections.Generic;
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
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit()
        {
            character.GetCharacterAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}


