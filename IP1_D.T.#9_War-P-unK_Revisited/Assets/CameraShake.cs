using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Transform camera2DRef;
    public Transform camera3DRef;


    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 original2DPos;
    Vector3 original3DPos;
    void OnEnable()
    {
        original2DPos = camera2DRef.localPosition;
        original3DPos = camera3DRef.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camera2DRef.localPosition = original2DPos + Random.insideUnitSphere * shakeAmount;
            camera3DRef.localPosition = original3DPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camera2DRef.localPosition = original2DPos;
            camera3DRef.localPosition = original3DPos;
        }
    }
}