using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public void AutoDestroy(float _time) // Auto destroy objects out of the maximum
    {
        StartCoroutine(AutoDestroyObject(_time));
    }
    public void ReturnToPool(float _time) // Auto disable to return to pool
    {
        StartCoroutine(AutoDisableObject(_time));
    }
    // Coroutine has a better performance then invokes methods
    private IEnumerator AutoDisableObject(float _time)
    {
        yield return new WaitForSeconds(_time);
        this.gameObject.SetActive(false);
    }
    private IEnumerator AutoDestroyObject(float _time)
    {
        yield return new WaitForSeconds(_time);
        Destroy(this.gameObject);
    }
}
