using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterName", menuName = "Name")]
public class NameData : ScriptableObject
{
    public List<string> name;
}
