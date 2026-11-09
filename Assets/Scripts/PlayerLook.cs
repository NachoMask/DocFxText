using UnityEngine;

namespace DocFxTest
{
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
        /// 입력에 따라 플레이어를 좌우로 회전시키고, 카메라를 상하로 회전.
        /// </summary>
        /// <param name="input">
        /// 시점 이동 입력.
        /// X는 좌우 회전, Y는 상하 회전에 사용하며 각 축마다 별도의 감도를 적용.
        /// </param>
        /// <remarks>
        /// 카메라의 상하 회전 각도는 -80도에서 80도 사이로 제한.
        /// 사용을 위해 playerCamera를 Inspector에서 할당해야 함.
        /// </remarks>
        public void Look(Vector2 input)
        {
            pitch -= input.y * ySensitivity;
            pitch = Mathf.Clamp(pitch, -80f, 80f);
            playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

            transform.Rotate(Vector3.up, input.x * xSensitivity);
        }
    }
}