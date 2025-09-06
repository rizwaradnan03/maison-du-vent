using Godot;
using System;

public partial class Player : CharacterBody2D
{
	float playerSpeed = 100;
	bool isMoving = false;

	public void Move(float delta)
	{
		if (Input.IsActionPressed("move_top") || Input.IsActionPressed("move_bottom") || Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left"))
		{
			isMoving = true;
			float posX = Position.X;
			float posY = Position.Y;

			if (Input.IsActionPressed("move_top") || Input.IsActionPressed("move_bottom"))
			{
				if (Input.IsActionPressed("move_top"))
				{
					posY = Position.Y - (delta * playerSpeed);
				}
				else
				{
					posY = Position.Y + (delta * playerSpeed);
				}
			}
			else if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
			{
				if (Input.IsActionPressed("move_left"))
				{
					posX = Position.X - (delta * playerSpeed);
				}
				else
				{
					posX = Position.X + (delta * playerSpeed);
				}
			}

			Position = new Vector2(posX, posY);
		}
		else
		{
			isMoving = false;
		}

		if (isMoving == true)
		{
			MoveAndSlide();
		}
	}

	public override void _Process(double delta)
	{
		Move((float)delta);
	}
}
