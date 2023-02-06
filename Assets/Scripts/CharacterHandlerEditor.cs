

#if (UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_64)
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(CharacterHandler))]
public class CharacterHandlerEditor : Editor
{

    private int selectedInput = 0;
    private string[] inputOptions = new string[0];
    private List<GameObject> inputTypes = new List<GameObject>();

    private int selectedCharacter = 0;
    private string[] characterOptions = new string[0];
    private List<GameObject> characterTypes = new List<GameObject>();


    public override void OnInspectorGUI()
    {
       

        // Initilizing functions
        string[] guids;
        inputTypes.Clear();
        characterTypes.Clear();

        CharacterHandler controller = (CharacterHandler)serializedObject.targetObject;

        // Get Mode GUIDs From Folder
        guids = AssetDatabase.FindAssets("t:Object", new string[] { "Assets" });

        // Get Objects Through GUID
        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            GameObject go = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

            if (go == null) continue;

            if (go.GetComponent<PubCharacterInput>() != null)
            {
                inputTypes.Add(go);
                if (controller.inputPrefab != null && go.name == controller.inputPrefab.name)
                {
                    selectedInput = inputTypes.Count - 1;
                }
            }
            else if (go.GetComponent<Character>() != null)
            {
                characterTypes.Add(go);
                if (controller.statePrefab != null && go.name == controller.statePrefab.name)
                {
                    selectedCharacter = characterTypes.Count - 1;
                }
            }
        }

        // Create String List For Dropdown
        inputOptions = new string[inputTypes.Count];
        for (int i = 0; i < inputTypes.Count; i++)
        {
            inputOptions[i] = inputTypes[i].name;
        }
        characterOptions = new string[characterTypes.Count];
        for (int i = 0; i < characterTypes.Count; i++)
        {
            characterOptions[i] = characterTypes[i].name;
        }

        //  GUI 

        // Select Mode
        selectedInput = EditorGUILayout.Popup("Input", selectedInput, inputOptions);
        selectedCharacter = EditorGUILayout.Popup("Subscriber", selectedCharacter, characterOptions);

        //  ASSIGN DATA 

        controller.inputPrefab = inputTypes.Count > selectedInput ? inputTypes[selectedInput].GetComponent<PubCharacterInput>() : null;
        controller.statePrefab = characterTypes.Count > selectedCharacter ? characterTypes[selectedCharacter].GetComponent<Character>() : null;
        serializedObject.FindProperty("inputPrefab").objectReferenceValue = controller.inputPrefab;
        serializedObject.FindProperty("statePrefab").objectReferenceValue = controller.statePrefab;
        serializedObject.ApplyModifiedProperties();

        
    }

  
}
#endif