using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour {
    Vector3 dropem = new Vector3(1.48f, 32.43f, 1.05f);
    float ellapsedTime;
	// Update is called once per frame
	void Update () {
        if (ellapsedTime < Time.deltaTime)
        {
            ellapsedTime += Time.deltaTime + 10;
            transform.position = dropem;
        }
    }
}
