using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.5f;
    public Vector3 offset;
    void LateUpdate ()
    {
        transform.position = target.position + offset;
    }
}
