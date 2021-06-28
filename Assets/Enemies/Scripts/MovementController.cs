using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
	public float speed { get; protected set; }
	public float MaxSpeed { get; protected set; }
	public virtual void Move() { }

}