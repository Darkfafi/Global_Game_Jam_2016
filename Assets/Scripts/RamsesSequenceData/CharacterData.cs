using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : MonoBehaviour {
	private Dictionary<string,Transform> _allControlledParts = new Dictionary<string, Transform> (); // All parts with tag so we can check the values of specific parts / change them
	private List<Transform> _allCharacterParts = new List<Transform>(); // All parts of the body in general

	void Awake(){
		for (int i = 0; i < transform.childCount; i++) {
			_allCharacterParts.Add(transform.GetChild(i));
			if(transform.tag != "Untagged"){
				_allControlledParts.Add(transform.tag,transform); // If a tag is added to body part then add it to allControlledParts, for only controlled parts have a tag in the body
			}
		}
	}

	public List<Transform> GetAllCharacterParts(){
		List<Transform> copiedList = _allCharacterParts;
		return copiedList;
	}

	public Transform GetContolledPart(string name){
		return _allControlledParts [name];
	}
}
