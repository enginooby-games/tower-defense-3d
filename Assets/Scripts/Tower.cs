using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Tooltip("Body parts which keep looking at current target")]
    [SerializeField] Transform rotatePart;
    [SerializeField] float attackRange = 15f;

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
        if (currentTarget)
        {
            rotatePart.LookAt(currentTarget);
            if (!gun.enabled) gun.enabled = true;
        }
        else if (!currentTarget && gun.enabled)
        {
            gun.enabled = false;
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
            if (targets.Count == 0)
            {
                currentTarget = other.transform;
            }

            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Body"))
        {
            targets.Remove(other.transform);

            if (targets.Count == 0)
            {
                currentTarget = null;
            }
            else
            {
                currentTarget = targets[0];
            }
        }
    }
}
