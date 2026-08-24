using Godot;
using System;

public partial class Alien : CharacterBody2D
{
	private PackedScene _eLaserScene=GD.Load<PackedScene>("res://scene/enemy_laser.tscn");
	private RandomNumberGenerator _rng = new RandomNumberGenerator();
	
	private Vector2 currentVelocity;
	private int physDirection = 1;
	private string enemyName = "Alien";
	
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta){


		Vector2 direction = new Vector2(physDirection, 0);
		Velocity = direction.Normalized() * (40+Global.Instance.speed);
		float xCoord = Position.X;
		float yCoord = Position.Y;
		if(xCoord >= 1120.00){
			physDirection=-1;
			for(int i=0; i<100; i++)
			{
				direction = new Vector2(-1, 1);
				Velocity = direction.Normalized() * (1500);
				
			}
		}
		else if(xCoord <= 90)
		{
			physDirection=1;
			for(int i=0; i<100; i++)
			{
				direction = new Vector2(1, 1);
				Velocity = direction.Normalized() * (1500);
				
			}
		}
			
		int ranint = _rng.RandiRange(1,5000);
		if(ranint==9){
			SpawnObject(xCoord, yCoord);
		}
			
		

		MoveAndSlide();




		
	}

	

	public void laserEntered(Node body){
		if(body is PlayerLaser laser)
		{
			Global.Instance.speed+=8;
			Global.Instance.enemyNum-=1;
			GD.Print(Global.Instance.enemyNum);

			laser.QueueFree();

			QueueFree();
		}
		
		
	}

	public void SpawnObject(float xCoord, float yCoord){
		EnemyLaser eLaserTemp = _eLaserScene.Instantiate<EnemyLaser>();
		eLaserTemp.GlobalPosition =this.GlobalPosition;
		GetTree().CurrentScene.AddChild(eLaserTemp);
		eLaserTemp.Position=new Vector2(xCoord-10, yCoord);
		Global.Instance.enemyLaser=Global.Instance.enemyLaser+1;

	}



	
	
}
