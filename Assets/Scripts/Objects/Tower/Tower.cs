using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Tooltip("Body parts which keep looking at current target")]
    [SerializeField] Transform pivot;
    [SerializeField] float attackRange = 15f;
    public int buildCost = 50;

    private List<Transform> targets = new List<Transform>();
    private Transform currentTarget;
    private Gun gun;
    private SphereCollider sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<Gun>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count == 0)
        {
            if (gun.enabled) gun.enabled = false;
        }
        else
        {
            // current target is destroyed or out of range
            if (!currentTarget)
            {
                // remove from the list
                targets.Remove(currentTarget);
                // change current target
                if (targets.Count > 0) currentTarget = targets[0];
            }

            pivot.LookAt(currentTarget);
            if (!gun.enabled) gun.enabled = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Body"))
        {
            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Body"))
        {
            targets.Remove(other.transform);
            if (currentTarget == other.transform) currentTarget = null;
        }
    }
}
