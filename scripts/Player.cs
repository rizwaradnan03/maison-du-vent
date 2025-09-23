using Godot;

public partial class Player : CharacterBody2D
{
	float playerSpeed = 100;
	bool isMoving = false;
	string direction = "move_bottom";

	public AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

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
					direction = "move_top";
					posY = Position.Y - (delta * playerSpeed);
				}
				else
				{
					direction = "move_bottom";
					posY = Position.Y + (delta * playerSpeed);
				}
			}
			else if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
			{
				if (Input.IsActionPressed("move_left"))
				{
					direction = "move_left";
					posX = Position.X - (delta * playerSpeed);
				}
				else
				{
					direction = "move_right";
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
			_animatedSprite.Play(direction);
			MoveAndSlide();
		}
		else
		{
			if (direction == "move_bottom")
			{
				_animatedSprite.Play("idle_bottom");
			}
			else if (direction == "move_top")
			{
				_animatedSprite.Play("idle_top");
			}
			else if (direction == "move_right")
			{
				_animatedSprite.Play("idle_right");
			}
			else if (direction == "move_left")
			{
				_animatedSprite.Play("idle_left");
			}
		}
	}

	public override void _Process(double delta)
	{
		Move((float)delta);

		// GD.Print("Sigma", utils.Json.PrintNumb());
	}
}
