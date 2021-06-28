using UnityEngine;

public class CharacterControllerMovement : Movement
{

	[SerializeField] CharacterController _cc;

	public override void Move(Vector3 vec)
	{
		_cc.Move(vec);
	}
}