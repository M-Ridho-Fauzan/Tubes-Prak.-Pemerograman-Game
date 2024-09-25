using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(0,scrollSpeed) * Time.deltaTime, _img.uvRect.size);
    }

}
