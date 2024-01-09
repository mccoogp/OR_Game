
using UnityEngine;

public class follow : MonoBehaviour
{
    public bool wakeup = false;
    public Transform player;
    public Vector3 offset;
    public Vector2 turn;
    public float sensitivity = 3f;
    public float wakingrotate = 0f;
    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (wakeup == false)
        {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            transform.position = player.position + offset;
        }
        if (wakeup == true)
        {
            transform.localRotation = Quaternion.Euler(wakingrotate -90, 0, 0);
            wakingrotate += 50 * Time.deltaTime;
            if (wakingrotate > 90)
            {
                wakeup = false;
                wakingrotate = 0f;
            }
        }
    }
}
