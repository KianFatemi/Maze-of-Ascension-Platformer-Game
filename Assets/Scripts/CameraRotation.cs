using UnityEngine;
using UnityEngine.Animations;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    Vector2 dir;

    float rotX;
    float rotY;

    void OnEnable()
    {
        InputManager.RotateCamera += Rotate;
        Cursor.visible = false;
    }

    void Rotate(Vector2 dir)
    {
        this.dir = dir;
    }

    void Update()
    {
        if (dir != Vector2.zero)
        {
            rotX += dir.y * speed * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, -60f, 30f);
            rotY = dir.x * speed * Time.deltaTime;
            transform.GetChild(0).localRotation = Quaternion.Euler(-rotX, 0f, 0f);
            transform.localRotation = Quaternion.Euler(0f, rotY, 0f);
        }
    }

    void OnDisable()
    {
        InputManager.RotateCamera -= Rotate;
        Cursor.visible = true;
    }
}
