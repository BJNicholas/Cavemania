using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private void Start()
    {
        instance = this;
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            //float x = Random.Range(-1, 1) * magnitude;
            //float y = Random.Range(-1, 1) * magnitude;
            float z = Random.Range(-1, 1) * magnitude;

            transform.localEulerAngles = new Vector3(0, 0, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localEulerAngles = Vector3.zero;
    }
}
