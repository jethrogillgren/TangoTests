﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayRoom : MonoBehaviour {

	public string roomName;

	private PhysicalRoom m_physicalRoom; //1 to 1 relationship, or empty.  relationship controlled by parent
	public PhysicalRoom physicalRoom
	{
		get
		{
			return m_physicalRoom;
		}

		set
		{
			this.m_physicalRoom = value;
//			value.gameplayRoom = this;
		}
	}

	public bool roomActive{	 
		get  {
//			return (physicalRoom == null  ||  GetComponentInParent( physicalRoom.GetType() ) == null ) ? false : true;
			return (m_physicalRoom != null);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public void getAnyChildGameplayRoom() {
		physicalRoom  = GetComponentInParent<PhysicalRoom> (); //TODO check depth
	}

//	public void registerAnyParentPhysicalRoom() {
//		PhysicalRoom pr = GetComponentInParent<PhysicalRoom> ();
//		if (pr)
//			physicalRoom = pr;
//	}

}
