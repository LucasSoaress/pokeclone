using UnityEngine;
using System.Collections;

public class rotatePokeball : MonoBehaviour
{
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 5f, 0f));
	}
}
