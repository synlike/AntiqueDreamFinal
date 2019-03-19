using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTravelingTeaser : MonoBehaviour
{
    public Camera cameraMain;
    public Camera cameraTmp;

    public float travelingDuration;
    public Transform target;
    public Transform target2;

    bool eventPassed;
    bool travelingOn;
    bool travelingOff;

    void start()
    {
    	StartCoroutine(Transition());
    }

	IEnumerator Transition()
    {
        float t = 0.0f;
        Vector3 startingPos = cameraMain.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / travelingDuration);

            cameraTmp.transform.position = Vector3.Lerp(startingPos, target.position, t);
            yield return 0;
        }
        yield return new WaitForSeconds(1f);
    }

}
