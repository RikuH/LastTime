using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCamera : MonoBehaviour
{
    public Transform Player;
    float offset = -250f;

    private Transform sweepTransform;

    [SerializeField]
    private float rotationSpeed;
    private float radarDistance;

    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        rotationSpeed = 180f;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Player.position.x, Player.position.y - offset, Player.position.z);

        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        //Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle)

    }
}
