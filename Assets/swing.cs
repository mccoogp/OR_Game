using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public Transform door;
    public Transform player;
    public int goal;
    private bool up = true;
    void Start()
    {
        door.transform.eulerAngles = new Vector3(
            0,
            door.transform.eulerAngles.y,
            door.transform.eulerAngles.z
        );
            }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position[0] > 22)
        {
            if (up)
            {
                goal = 90;
                up = false;
            }
        }
        
        if (player.transform.position[0] > 26 && player.transform.position[0] < 34 && player.transform.position[2] > 13 && player.transform.position[2] < 19 && player.transform.position[1] < -6)
        {
            goal = 0;

        }
        if (door.transform.eulerAngles[0] < goal)
        {
            door.transform.rotation = Quaternion.Euler(new Vector3(
                door.transform.eulerAngles[0] + 1,
                door.transform.eulerAngles.y,
                door.transform.eulerAngles.z
        ));
        }
        if (door.transform.eulerAngles[0] > goal && door.transform.eulerAngles[0] < 359)
            {
                door.transform.rotation = Quaternion.Euler(new Vector3(
                0,
                door.transform.eulerAngles.y,
                door.transform.eulerAngles.z
            ));
            }
        
    }
}
