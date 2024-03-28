using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Animation;
using TopDownShooter.Infrastructure;
using TopDownShooter.Service.Input;
using UnityEngine;

namespace TopDownShooter
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private LegsAnimationHelper legsAnimationHelper;
        [SerializeField] private float movementSpeed;

        private IInputService inputService;
        private Camera camera;

        private void Awake()
        {
            inputService = Game.InputService;
        }
        private void Start()
        {
            camera = Camera.main;
        }
        private void Update()
        {
            Vector2 movementVector = Vector2.zero;
            if (inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = camera.transform.TransformDirection(inputService.Axis);
                legsAnimationHelper.SetAnimationBool(true);
            }
            else
            {
                legsAnimationHelper.SetAnimationBool(false);
            }
            characterController.Move(movementSpeed * movementVector * Time.deltaTime);
        }
    }
}

