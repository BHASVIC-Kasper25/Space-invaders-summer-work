using Godot;
using System;

public partial class EnemyLaser : CharacterBody2D
{

	public override void _Process(double delta)
	{
		Vector2 direction = new Vector2(0, 1);
		Velocity = direction.Normalized() * 80;
		MoveAndSlide();
	}

	public void enemyEntered(Node2D body)
	{
		for(int i=1; i<4; i++){
			if(body.Name=="Base"+i){

				QueueFree();
			}
		}
	}
}
