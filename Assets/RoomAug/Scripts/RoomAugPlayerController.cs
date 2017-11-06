﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//This class controlls the UNET conecpt of a player - one on the server for each Client Tango connected.
public class RoomAugPlayerController : NetworkBehaviour
{
	[SyncVar]
	public new string name = "Player #"; //Should be set during construction
	public void setName(string name) {
		this.name = name;
		updatePlayerText ();
	}

//	public override void update() {
//
//		if( GetComponent<TangoPlayerApplicationController>().state.CurrentState == ProcessState.Terminated )
//			Destroy (this);//TODO Check
//	}

	public void updatePlayerText() {
		GetComponentInChildren<TextMesh>().text = name;
	}

	//This is invoked for NetworkBehaviour objects when they become active on the server.
	public override void OnStartServer() {

		if (gameObject.GetComponent<Camera> () != null) {
			Debug.Log ("J# Disabling Camera " + name + " on Server");
			gameObject.GetComponent<Camera> ().enabled = false;
		}
		if (gameObject.GetComponent<Tango.TangoApplication> () != null) {
			Debug.Log ("J# Disabling TangoApplication " + name + " on Server");
			gameObject.GetComponent<Tango.TangoUx>().enabled = false;
		}
		if (gameObject.GetComponent<Tango.TangoUx> () != null) {
			Debug.Log ("J# Disabling TangoUx " + name + " on Server");
			gameObject.GetComponent<Tango.TangoUx>().enabled = false;
		}
		if (gameObject.GetComponent<TangoPoseController> () != null) {
			Debug.Log ("J# Disabling TangoPoseController " + name + " on Server");
			gameObject.GetComponent<TangoPoseController>().enabled = false;
		}
		if (gameObject.GetComponent<TangoPlayerApplicationController> () != null) {
			Debug.Log ("J# Disabling Tango Player ApplicationController " + name + " on Server");
			gameObject.GetComponent<TangoPlayerApplicationController>().enabled = false;
		}

	}
		
//	DisableComponent( typeof(Camera) );  TODO didn't work
//	private void DisableComponent( System.Type t ) {
//		if (gameObject.GetComponent(t) != null) {
//			Debug.Log ("J# Disabling " + t.Name + " on Server");
//			gameObject.GetComponent(t).enabled = false;
//
//		}
//	}

	//Called when the local player object has been set up.
	//This happens after OnStartClient(), as it is triggered by an ownership message from the server.
	//This is an appropriate place to activate components or functionality that should only be active
	//for the local player, such as cameras and input.
	public void OnStartLocalPlayer() {
		
	}

	[Command]
	public void CmdWatchEarth() {
		FindObjectOfType<WatcherGameplayObject>().m_LookTarget = GameObject.Find ("Earth");
	}

}
