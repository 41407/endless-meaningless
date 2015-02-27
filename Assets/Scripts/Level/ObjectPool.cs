﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
		//Here is a private reference only this class can access
		private static ObjectPool _instance;
	
		//This is the public reference that other classes will use
		public static ObjectPool pool {
				get {
						//If _instance hasn't been set yet, we grab it from the scene!
						//This will only happen the first time this reference is used.
						if (_instance == null)
								_instance = GameObject.FindObjectOfType<ObjectPool> ();
						return _instance;
				}
		}
	
		Dictionary<GameObject, List<GameObject>> objectPool = new Dictionary<GameObject, List<GameObject>> ();

		public void Initialize (GameObject objectType)
		{
				Initialize (objectType, 10);
		}

		public void Initialize (GameObject objectType, int poolSize)
		{
				if (!objectPool.ContainsKey (objectType)) {
						print ("Pooling: " + objectType.name + " x " + poolSize);
						InitializeByKey (objectType, poolSize);
				}
		}

		public GameObject Pull (GameObject objectType, Vector3 position, Quaternion rotation)
		{
				if (!objectPool.ContainsKey (objectType)) {
						print (objectType.name + " pulled without prior initialization");
						Initialize (objectType);
				}
				GameObject newObject = PullFromList (objectPool [objectType], objectType);	
				newObject.transform.position = position;
				newObject.transform.rotation = rotation;
				return newObject;
		}

		void InitializeByKey (GameObject key, int poolSize)
		{
				objectPool.Add (key, new List<GameObject> ());
				for (int i = 0; i < poolSize; i++) {
						GameObject newObject = (GameObject)Instantiate (key);
						newObject.SetActive (false);
						objectPool [key].Add (newObject);
				}
		}

		GameObject PullFromList (List<GameObject> list, GameObject objectType)
		{		
				for (int i = 0; i < list.Count; i++) {
						if (!list [i].activeInHierarchy) {
								return list [i];
						}
				}
				GameObject newObject = (GameObject)Instantiate (objectType);
				newObject.SetActive (false);
				list.Add (newObject);
				return newObject;			
		}
}