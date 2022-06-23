using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    public SpriteRenderer parentRenderer;
    public GameObject parent;
    public GameObject shotController01;
    public GameObject shotController02;

    public Vector3 FlippedPosition01;
    public Vector3 FlippedPosition02;

    public Vector3 UnFlippedPosition01;
    public Vector3 UnFlippedPosition02;
    void Start()
    {
        UnFlippedPosition01 = shotController01.transform.localPosition;
        UnFlippedPosition02 = shotController02.transform.localPosition;

        FlippedPosition01 = shotController01.transform.localPosition + new Vector3(2*(0 - shotController01.transform.localPosition.x),0);
        FlippedPosition02 = shotController02.transform.localPosition + new Vector3(2*(0 - shotController02.transform.localPosition.x),0);
    }

    // Update is called once per frame
    void Update()
    {
        if (parentRenderer.flipX)
        {
            shotController01.transform.localPosition = FlippedPosition01;
            shotController02.transform.localPosition = FlippedPosition02;
        }
        else
        {
            shotController01.transform.localPosition = UnFlippedPosition01;
            shotController02.transform.localPosition = UnFlippedPosition02;
        }
    }
}
