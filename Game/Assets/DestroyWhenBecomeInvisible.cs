using UnityEngine;
using System.Collections;

public class DestroyWhenBecomeInvisible : MonoBehaviour {

	void OnBecameVisible() {
        Destroy(gameObject);
    }
}
