using Godot;
using System;

public partial class Player : CharacterBody2D
{
	
	private float CooldownTime = 1.5f;
	
	private PackedScene _pLaserScene=GD.Load<PackedScene>("res://scene/player_laser.tscn");
	private float _cooldownTimer=0f;


	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_cooldownTimer>0)
		{
			_cooldownTimer -=(float)delta;
		}
		
		
		float xCoord = Position.X;
		float yCoord = Position.Y;
		
		if (Input.IsActionJustPressed("ui_left"))
		{
			Vector2 direction = new Vector2(-1, 0);
			Velocity = direction.Normalized() * 120;
		}
		else if(Input.IsActionJustReleased("ui_left"))
		{
			Vector2 direction = new Vector2(0, 0);
			Velocity = direction.Normalized() * 1;
		}
		else if(Input.IsActionJustPressed("ui_right")){
			Vector2 direction = new Vector2(1, 0);
			Velocity = direction.Normalized() * 120;
		}
		else if(Input.IsActionJustReleased("ui_right"))
		{
			Vector2 direction = new Vector2(0, 0);
			Velocity = direction.Normalized() * 1;
		}


		if (Input.IsActionJustPressed("Shoot") && _cooldownTimer <=0)
		{
			SpawnObject(xCoord, yCoord);
		}

		MoveAndSlide();
	}

	public void SpawnObject(float xCoord, float yCoord)
	{
		PlayerLaser pLaserTemp = _pLaserScene.Instantiate<PlayerLaser>();
		pLaserTemp.GlobalPosition =this.GlobalPosition;
		pLaserTemp.Name = "Enemy_Hero"+Global.Instance.laser;
		GetTree().CurrentScene.AddChild(pLaserTemp);
		pLaserTemp.Position=new Vector2(xCoord, yCoord);
		Global.Instance.laser=Global.Instance.laser+1;
		_cooldownTimer=CooldownTime;

	}
}
