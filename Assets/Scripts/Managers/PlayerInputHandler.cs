using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : IInputHandler
{
	[SerializeField]
	private PlayerCharacter playerCharacter;
	[SerializeField]
	private Rigidbody2D rigidBody;
	[SerializeField]
	private float speed = 10.0f;
	public override void OnKeyPressed(KeyCode key)
	{
		throw new System.NotImplementedException();
	}

	public override void OnKeyReleased(KeyCode key)
	{
		throw new System.NotImplementedException();
	}

	public override void UpdateDirectionalInput(float horizontalAxis, float verticalaxis)
	{
		Vector2 velocity = new Vector2();
		velocity.x = Mathf.Abs(horizontalAxis) > 0.0f ? speed * Mathf.Sign(horizontalAxis) : 0.0f;
		velocity.y = Mathf.Abs(verticalaxis) > 0.0f ? speed * Mathf.Sign(verticalaxis) : 0.0f;
		rigidBody.velocity = velocity;
		playerCharacter.UpdateAnimationFromMovement(horizontalAxis, verticalaxis);
	}
}
