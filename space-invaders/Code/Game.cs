using Godot;
using System;

public partial class Game : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Global.Instance.lives==0)
		{
			GetTree().ChangeSceneToFile("res://scene/game_over.tscn");
		}
		else if(Global.Instance.enemyNum==0)
		{
			GetTree().ChangeSceneToFile("res://scene/victory.tscn");
		}

	}
}
