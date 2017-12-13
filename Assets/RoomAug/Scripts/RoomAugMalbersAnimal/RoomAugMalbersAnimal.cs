﻿using UnityEngine;
using System.Collections;

using MalbersAnimations;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// This will controll all Animals Motion  
/// Version 1.0.5
/// </summary>
public partial class RoomAugMalbersAnimal : Animal
{
	public SlowMotionController slowMoController;
	public RoomAugMalbersAIAnimalControl ai;
	
	protected override void AdditionalSpeed()
	{
		base.AdditionalSpeed ();
		if ( slowMoController.SlowMoTimeScale != 1 )
		{
			_anim.speed = slowMoController.SlowMoTimeScale;
//			Debug.Log ( "RoomAug Overrided AnialMovementSpeed to " + slowMoController.SlowMoTimeScale );
		} 
	}


}
