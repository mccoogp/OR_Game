
using UnityEngine;

public class CharcMove : MonoBehaviour
{
    public CharacterController control;
    public Vector3 box;
    public LayerMask layertohit;
    public float gravity;
    int jumped = 0;
    float velocity = 0;
    public Vector2 turn;
    public float sensitivity = 3f;
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        if (Input.GetKey("d"))
        {
            Vector3 direction = new Vector3(Mathf.Sin((turn.x + 90) / 180 * Mathf.PI), 0, Mathf.Cos((turn.x + 90) / 180 * Mathf.PI));
            control.Move(direction*Time.deltaTime*10);

        }
        if (Input.GetKey("w"))
        {
            Vector3 direction = new Vector3(Mathf.Sin(turn.x / 180 * Mathf.PI), 0, Mathf.Cos(turn.x / 180 * Mathf.PI));
            control.Move(direction * Time.deltaTime*10);
        }
        if (Input.GetKey("s"))
        {
            Vector3 direction = new Vector3(-Mathf.Sin(turn.x / 180 * Mathf.PI), 0, -Mathf.Cos(turn.x / 180 * Mathf.PI));
            control.Move(direction * Time.deltaTime * 10);
            
        }
        if (Input.GetKey("a"))
        {
            Vector3 direction = new Vector3(Mathf.Sin((turn.x - 90) / 180 * Mathf.PI), 0, Mathf.Cos((turn.x - 90) / 180 * Mathf.PI));
            control.Move(direction * Time.deltaTime * 10);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumped == 0)
            {
                jumped += 1;
                velocity = 20;

            }
            else if (jumped == 1)
            {
                jumped += 1;
        
            }
        }
        RaycastHit m_Hit;
        velocity -= 2 * gravity * Time.deltaTime;
        control.Move(new Vector3(0f, velocity * Time.deltaTime, 0f));
        Vector3 below = new Vector3(0, -1, 0);
        if (Physics.BoxCast(transform.position, box / 2, below, out m_Hit, transform.rotation, velocity * -1 * Time.deltaTime, layertohit))
        {
            if (m_Hit.distance < -velocity * Time.deltaTime / 2)
            {

                jumped = 0;
                velocity = velocity / 2;
            }
        }
    }
}
