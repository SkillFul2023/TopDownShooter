using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Animation
{
    public class LegsAnimationHelper : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animationName;

        public void SetAnimationBool(bool flag)
        {
            animator.SetBool(animationName, flag);
        }
    }

}
