using UnityEngine;

namespace TopDownShooter.Animation
{
    public class CharacterAnimationHelper : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animationName;

        public void SetAnimationBool(bool flag)
        {
            animator.SetBool(animationName, flag);
        }
    }
}

