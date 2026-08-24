using Godot;
using System;

public partial class Base : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;

	private int frameNum=0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animatedSprite=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Area2D hitbox = GetNode<Area2D>("Hitbox");
		hitbox.BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(frameNum==8)
		{
			Global.Instance.lives=Global.Instance.lives-1;
			QueueFree();
		}
	}

	private void OnBodyEntered(Node2D body)
	{
		frameNum++;
		_animatedSprite.Stop();
		_animatedSprite.Frame=frameNum;
		if(body is PlayerLaser laser)
		{
			laser.QueueFree();
		}
		else if(body is EnemyLaser eLaser)
		{
			eLaser.QueueFree();
		}
	}
}
