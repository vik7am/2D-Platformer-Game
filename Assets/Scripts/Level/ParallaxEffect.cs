using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Transform cameraTransform;
    Vector3 lastCameraPosition;
    [SerializeField] float parallexEffectSpeed;
    [SerializeField] float width;

    void Awake()
    {
        //Vector3 s = GetComponent<Renderer>().bounds.size;
        //BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        //textureUnitSizeX = collider2D.size.x;
        //print(s.x);
        //Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
        //textureUnitSizeX = 15;
        //print(sprite.pixelsPerUnit);
    }

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallexEffectSpeed, 0, 0);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= width)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % width;
            transform.position = new Vector3(cameraTransform.position.x - offsetPositionX, transform.position.y);
        }
    }
}