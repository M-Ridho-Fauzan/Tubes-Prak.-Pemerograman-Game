using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    int posid = 0;
    public GameObject[] pos;
    // ======

    private bool isMoving = false;
    private float moveTime = 0.5f; // Waktu transisi dalam detik
    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    // ======

    void Start()
    {
        transform.position = pos[posid].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (posid == 0){
                posid = 1;
            } else {
                posid = 0;
            }
            // transform.position = pos[posid].transform.position;
            // ------------
            StartCoroutine(MoveToPosition(pos[posid].transform.position));
        }

                    if (isMoving)
            {
                elapsedTime += Time.deltaTime;
                float percentComplete = elapsedTime / moveTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, percentComplete);

                if (percentComplete >= 1.0f)
                {
                    isMoving = false;
                    elapsedTime = 0f;
                }
            }
    }
    // -------------------

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;
        startPosition = transform.position;
        endPosition = targetPosition;
        elapsedTime = 0f;
        yield return null;
    }

    // ====================

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy")
        {
            GameObject.Find("GM").GetComponent<GM>().gameOver();
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "PowerUp")
        {
            Destroy(col.gameObject); // Hancurkan GameObject powerUp
            col.gameObject.transform.parent.gameObject.GetComponent<PowerUp>().addAttack(col.gameObject.name);
        }
    }
}
