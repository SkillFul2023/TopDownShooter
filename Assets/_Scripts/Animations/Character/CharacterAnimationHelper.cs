using UnityEngine;
using TopDownShooter.Enums;

namespace TopDownShooter.Animation
{
    public class CharacterAnimationHelper : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetAnimationBool(string animationName, bool flag)
        {
            animator.SetBool(animationName, flag);
        }
    }
}

