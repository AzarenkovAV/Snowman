using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
	[SerializeField] private DamageHandler _target;
	[SerializeField] private LayerMask _targetMask;
	[SerializeField] private LayerMask _obstacleMask;

	[Range(0, 360)]	public float viewAngle;

	public float viewRadius;

	public readonly List<Transform> visibleTargets = new List<Transform>();

	void Start()
	{
		var startCoroutine = StartCoroutine(FindTargetsWithDelay(0.05f));
	}

	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (_target != null)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, _targetMask); 

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			Vector3 dirToTarget = (_target.transform.position - transform.position).normalized;

			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, _target.transform.position);

				if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleMask))
				{
					_target.ApplyDamage();
				}
			}
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}

		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}