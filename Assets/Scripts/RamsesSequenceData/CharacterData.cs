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

	private List<Transform> _allCharacterParts = new List<Transform>(); // All parts of the body in general

	void Awake(){
		/*
		for (int i = 0; i < transform.childCount; i++) {
			_allCharacterParts.Add(transform.GetChild(i));
			if(transform.tag != "Untagged"){
				_allControlledParts.Add(transform.tag,transform); // If a tag is added to body part then add it to allControlledParts, for only controlled parts have a tag in the body
			}
		}*/
		//_allControlledParts.Add(Tags.MOVE_PART_A,)
	}

	private void CheckUltChilderenForParts(){
		Transform master = gameObject.transform;
		Transform currentChild = gameObject.transform;
		while (currentChild != null) {
			while(master != null){

			}
		}
	}

	public List<Transform> GetAllCharacterParts(){
		List<Transform> copiedList = _allCharacterParts;
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
}
