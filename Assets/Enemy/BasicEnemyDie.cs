using UnityEngine;

public class BasicEnemyDie : EnemyDie
{

	Vector3 _extents;
	Selector _selector;

	void Awake()
	{
		_extents = GetComponent<Collider>().bounds.extents;
		_selector = GetComponent<Selector>();
	}

	public override void Die()
	{
		transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f)) * Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));
		Ray ray = new Ray(transform.position, Vector3.down);
		_selector.CheckRay(ray);

		if (_selector.GetSelection() != null)
		{
			Vector3 newPos = _selector.GetSelectionPoint() + new Vector3(0f, _extents.x, 0f);
			transform.position = newPos;
		}

		base.Die();

		Destroy(gameObject, 10f);
	}

}