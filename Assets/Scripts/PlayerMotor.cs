using UnityEngine;

namespace DocFxTest
{
    /// <summary>
    /// CharacterController를 사용해 플레이어 이동과 달리기 상태를 관리.
    /// </summary>
    /// <remarks>
    /// CharacterController 컴포넌트 필요. <br></br>
    /// 이동 처리: <see cref="Move(UnityEngine.Vector2, float)"/>를 호출해 수행.
    /// </remarks>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMotor : MonoBehaviour
    {
        private CharacterController controller;

        private bool isSprinting;
        private float walkSpeed = 5f;
        private float sprintSpeed = 8f;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        /// <summary>
        /// 플레이어가 바라보는 방향을 기준으로 입력에 따라 이동.
        /// </summary>
        /// <param name="input">
        /// 이동 입력. X는 좌우, Y는 전후 방향을 나타냄.
        /// 벡터의 크기가 1을 초과하면 크기를 1로 제한함.
        /// </param>
        /// <param name="deltaTime">
        /// 이동에 적용할 시간 간격(초 단위).
        /// Update에서 호출 시 Time.deltaTime을 전달.
        /// </param>
        /// <remarks>
        /// 현재 달리기 상태에 따라 걷기 속도 또는 달리기 속도를 적용.
        /// 달리기 상태는 <see cref="Sprint(bool)"/>로 변경 가능.
        /// </remarks>
        /// <example>
        /// Update에서 전방 이동을 처리하는 예시
        /// <code>
        /// private void Update()
        /// {
        ///     Move(Vector2.up, Time.deltaTime);
        /// }
        /// </code>
        /// </example>
        public void Move(Vector2 input, float deltaTime)
        {
            // # 수평 이동

            // 달리기 여부에 맞는 이동 속도 전달
            float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
            // 이동 방향에 관계없이 동일한 속도를 유지하기 위해 값을 1로 제한
            Vector2 clampedInput = Vector2.ClampMagnitude(input, 1f);
            // 플레이어 transform 기준 입력에 따른 수평 이동 벡터 설정
            Vector3 horizontalMove = (transform.right * clampedInput.x + transform.forward * clampedInput.y) * currentSpeed;

            controller.Move(horizontalMove * deltaTime);
        }

        /// <summary>
        /// 플레이어의 달리기 상태를 설정.
        /// </summary>
        /// <param name="sprinting">
        /// <see langword="true"/>면 달리기 상태로, <see langword="false"/>면 걷기 상태로 설정.
        /// </param>
        /// <remarks>
        /// 변경한 상태는 이후 <see cref="Move(Vector2, float)"/> 호출 시, 이동 속도를 선택할 때 사용.
        /// </remarks>
        public void Sprint(bool sprinting)
        {
            isSprinting = sprinting;
        }
    }
}