using Godot;
using System;

public partial class PlayerLaser : CharacterBody2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 direction = new Vector2(0, -1);
		Velocity = direction.Normalized() * 80;
		MoveAndSlide();
	}



}
