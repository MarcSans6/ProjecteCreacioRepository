using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipShotController : MonoBehaviour
{
    public SpriteRenderer parentSpriteRenderer;
    private Transform transform;
    public Transform parentTransform;
    public bool flipX;
    public GameObject shotController01;
    public GameObject shotController02;
    private Vector3 shotController01FlippedPosition;
    private Vector3 shotController02FlippedPosition;


    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        shotController01FlippedPosition = shotController01.transform.position - new Vector3(2 * (shotController01.transform.position.x - parentTransform.position.x), 0);
        shotController02FlippedPosition = shotController02.transform.position + new Vector3(2 * (parentTransform.position.x - shotController02.transform.position.x), 0);

    }

    public void FlipShotMethod(bool _isFlipped)
    {
        if (_isFlipped)
        {
            shotController01.transform.position = shotController01FlippedPosition;

            shotController02.transform.position = shotController02FlippedPosition;
        }
        else
        {

        }
    }
}
