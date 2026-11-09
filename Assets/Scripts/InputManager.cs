using UnityEngine;
using UnityEngine.InputSystem;

namespace DocFxTest
{
    /// <summary>
    /// 플레이어 입력에 대응하는 함수 호출을 관리하는 클래스
    /// </summary>
    [RequireComponent(
        typeof(PlayerMotor),
        typeof(PlayerLook))]
    public class InputManager : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInput.MainInputActions mainInput;

        private PlayerMotor playerMotor;
        private PlayerLook playerLook;

        private void Awake()
        {
            playerInput = new PlayerInput();
            mainInput = playerInput.MainInput;

            playerMotor = GetComponent<PlayerMotor>();
            playerLook = GetComponent<PlayerLook>();
        }

        private void OnEnable()
        {
            mainInput.Sprint.started += OnSprint;
            mainInput.Sprint.canceled += OnSprint;

            mainInput.Enable();
        }

        private void OnDisable()
        {
            mainInput.Sprint.started -= OnSprint;
            mainInput.Sprint.canceled -= OnSprint;

            mainInput.Disable();
        }

        private void Update()
        {
            playerMotor.Move(mainInput.Move.ReadValue<Vector2>(), Time.deltaTime);
        }

        private void LateUpdate()
        {
            playerLook.Look(mainInput.Look.ReadValue<Vector2>());
        }

        private void OnSprint(InputAction.CallbackContext context)
        {
            playerMotor.Sprint(context.started);
        }
    }
}