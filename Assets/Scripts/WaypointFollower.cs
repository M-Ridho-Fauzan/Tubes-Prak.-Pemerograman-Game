// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WaypointFollower : MonoBehaviour
// {
//     [SerializeField] private GameObject[] waypoints; 
//     private int currentWaypointIndex = 0;

//     [SerializeField] private float speed = 2f;

//     // Update is called once per frame
//     private void Update()
//     {
//         if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f){
//             currentWaypointIndex++;
//             if (currentWaypointIndex >= waypoints.Length){
//                 currentWaypointIndex = 0;
//             }
//         }
//         transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, 
//         Time.deltaTime * speed);
//     }
// }

// =====================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class WaypointFollower : MonoBehaviour
// {
//     [SerializeField] private GameObject[] waypoints;
//     private int currentWaypointIndex = 0;
//     [SerializeField] private float speed = 2f;

//     // Update is called once per frame
//     private void Update()
//     {
//         // Menggunakan komponen vektor 2D (Vector2) untuk mengabaikan sumbu y
//         Vector2 currentPosition = new Vector2(transform.position.x, transform.position.z);
//         Vector2 targetWaypoint = new Vector2(waypoints[currentWaypointIndex].transform.position.x, waypoints[currentWaypointIndex].transform.position.z);

//         if (Vector2.Distance(targetWaypoint, currentPosition) < .1f)
//         {
//             currentWaypointIndex++;
//             if (currentWaypointIndex >= waypoints.Length)
//             {
//                 currentWaypointIndex = 0;
//             }
//         }

//         // Menggunakan MoveTowards dengan vektor 2D
//         Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetWaypoint, Time.deltaTime * speed);
//         transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.y);
//     }
// }

// =========================


public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        // Memutuskan arah awal secara random
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 0)
        {
            currentWaypointIndex = 0;
        }
        else
        {
            currentWaypointIndex = waypoints.Length - 1;
        }
    }

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetWaypoint = new Vector2(waypoints[currentWaypointIndex].transform.position.x, waypoints[currentWaypointIndex].transform.position.z);

        if (Vector2.Distance(targetWaypoint, currentPosition) < .1f)
        {
            // Memutuskan apakah akan berbalik arah atau tidak
            int randomDirection = Random.Range(0, 2);
            if (randomDirection == 0)
            {
                // Berjalan ke waypoint selanjutnya
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            else
            {
                // Berjalan ke waypoint sebelumnya
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                }
            }
        }

        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetWaypoint, Time.deltaTime * speed);
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.y);
    }
}

// ========== Pemjelasan

/*

        - Pada metode Start(), ditambahkan kode untuk memutuskan arah awal secara 
        random menggunakan Random.Range(0, 2). Jika hasil random adalah 0, maka objek 
        akan berjalan dari waypoint 0 ke waypoint selanjutnya. Jika hasil random adalah 1, 
        maka objek akan berjalan dari waypoint terakhir ke waypoint sebelumnya.

        - Pada metode Update(), setelah objek mencapai waypoint tujuan, ditambahkan kode 
        untuk memutuskan apakah objek akan berbalik arah atau tidak menggunakan Random.Range(0, 2). 
        Jika hasil random adalah 0, maka objek akan berjalan ke waypoint selanjutnya seperti sebelumnya. 
        Jika hasil random adalah 1, maka objek akan berjalan ke waypoint sebelumnya.

*/