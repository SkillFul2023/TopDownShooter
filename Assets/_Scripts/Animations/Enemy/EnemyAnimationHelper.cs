using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopDownShooter.Animation
{
    public class EnemyAnimationHelper : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetAnimationBool(string animationName, bool flag)
        {
            animator.SetBool(animationName, flag);
        }
    }
}
