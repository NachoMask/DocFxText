using UnityEngine;

/// <summary>
/// 플레이어의 움직임에 관련된 클래스
/// </summary>
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
    /// 입력된 방향에 따라 플레이어를 이동
    /// </summary>
    /// <param name="input">입력에 따른 벡터</param>
    /// <param name="deltaTime">이동을 처리할 시간</param>
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
    /// 이동의 달리기 상태를 매개변수에 맞게 설정
    /// </summary>
    /// <param name="sprinting">달리기 상태</param>
    public void Sprint(bool sprinting)
    {
        isSprinting = sprinting;
    }
}
