using UnityEngine;

/// <summary>
/// 플레이어의 카메라에 관련된 클래스
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    private float pitch = 0f;

    private float xSensitivity = 0.1f;
    private float ySensitivity = 0.1f;

    /// <summary>
    /// 입력된 방향에 따라 카메라 및 플레이어를 회전
    /// </summary>
    /// <param name="input">입력에 따른 벡터</param>
    public void Look(Vector2 input)
    {
        pitch -= input.y * ySensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        transform.Rotate(Vector3.up, input.x * xSensitivity);
    }
}
