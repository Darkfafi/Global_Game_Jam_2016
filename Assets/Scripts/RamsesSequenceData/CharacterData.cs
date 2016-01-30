using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : MonoBehaviour {
	//private Dictionary<string,Transform> _allControlledParts = new Dictionary<string, Transform> (); // All parts with tag so we can check the values of specific parts / change them
	[SerializeField]
	private Transform _movingPartA;
	[SerializeField]
	private Transform _movingPartB;
	[SerializeField]
	private Transform _movingPartC;
	[SerializeField]
	private Transform _movingPartD;
	[SerializeField]
	private Transform[] _mouths;

	public List<Transform> GetAllContolledParts(){
		List<Transform> copiedList = new List<Transform>();
		copiedList.Add (_movingPartA);
		copiedList.Add (_movingPartB);
		copiedList.Add (_movingPartC);
		copiedList.Add (_movingPartD);
		return copiedList;
	}

	public Transform GetContolledPart(string name){
		Transform tr = null;
		switch (name) {
		case Tags.MOVE_PART_A:
			tr = _movingPartA;
			break;
		case Tags.MOVE_PART_B:
			tr = _movingPartB;
			break;
		case Tags.MOVE_PART_C:
			tr = _movingPartC;
			break;
		case Tags.MOVE_PART_D:
			tr = _movingPartD;
			break;
		}

		return tr;
	}
	public Transform[] GetAllMouths(){
		return _mouths;
	}
}
