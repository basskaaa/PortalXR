using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Acid : MonoBehaviour
{
    [SerializeField] private GameEvent playerDied;
    [SerializeField] private float floatGrav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDied.Raise();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.AddComponent<ConstantForce>();

            StartCoroutine(FloatBob(other.gameObject.GetComponent<ConstantForce>()));
        }
    }

    private IEnumerator FloatBob(ConstantForce force)
    {
        force.force = new Vector3(0, floatGrav, 0);
        yield return new WaitForSeconds(0.5f);
        force.force = new Vector3(0, -floatGrav*2, 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FloatBob(force));
    }
}
