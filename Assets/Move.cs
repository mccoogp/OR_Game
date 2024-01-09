
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
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
            Vector3 direction = new Vector3(Mathf.Sin((turn.x+90)/180 * Mathf.PI), 0, Mathf.Cos((turn.x+90)/180 * Mathf.PI));
            if (Physics.BoxCast(transform.position, box / 2, direction, transform.rotation, 10 * Time.deltaTime))
            {
            }
            else
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0f, 0f));
            }
            
        }
        if (Input.GetKey("w"))
        {
            Vector3 direction = new Vector3(Mathf.Sin(turn.x / 180 * Mathf.PI), 0, Mathf.Cos(turn.x / 180 * Mathf.PI));
            if (Physics.BoxCast(transform.position, box / 2, direction, transform.rotation, 10 * Time.deltaTime))
            {
            }
            else
            {
                transform.Translate(new Vector3(0f, 0f, 10 * Time.deltaTime));
            }
        }
        if (Input.GetKey("s"))
        {
            Vector3 direction = new Vector3(-Mathf.Sin(turn.x / 180 * Mathf.PI), 0, -Mathf.Cos(turn.x / 180 * Mathf.PI));
            if (Physics.BoxCast(transform.position, box / 2, direction, transform.rotation, 10 * Time.deltaTime))
            {
            }
            else
            {
                transform.Translate(new Vector3(0f, 0f, -10 * Time.deltaTime));
            }
        }
        if (Input.GetKey("a"))
        {
            Vector3 direction = new Vector3(Mathf.Sin((turn.x - 90) / 180 * Mathf.PI), 0, Mathf.Cos((turn.x - 90) / 180 * Mathf.PI));
            if (!Physics.BoxCast(transform.position, box / 2, direction, transform.rotation, 10 * Time.deltaTime))
            {

                transform.Translate(new Vector3(-10 * Time.deltaTime, 0f, 0f));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumped == 0)
            {
                jumped += 1;
                velocity += 20;
                transform.Translate(new Vector3(0f, velocity * 2 * Time.deltaTime, 0f));
            }
            else if (jumped == 1)
            {
                jumped += 1;
                velocity = 20;
            }
        }
        RaycastHit m_Hit;
        velocity -= 2*gravity*Time.deltaTime;
        Vector3 below = new Vector3(0, -1, 0);
        if (Physics.BoxCast(transform.position, box / 2, below, out m_Hit, transform.rotation, velocity * -1 * Time.deltaTime, layertohit))
        {
            if (m_Hit.distance > -velocity *Time.deltaTime/2)
            {
                transform.Translate(new Vector3(0f, velocity * Time.deltaTime / 2, 0f));
            }
            else
            {
                jumped = 0;
                velocity = velocity/2;
            }
            
        }
        else
        { 
                transform.Translate(new Vector3(0f, velocity * Time.deltaTime, 0f));
         }

    }
}
