using Godot;
using System;

public partial class Global : Node2D
{
	public static Global Instance {get; private set;}
	public int laser {get; set;}=1;
	public int speed {get; set;}=1;
	public int enemyLaser {get; set;}=1;
	public int lives{get; set;}=4;
	public int enemyNum{get; set;}=48;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance=this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	
}
