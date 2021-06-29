using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class NavMeshEditor : EditorWindow
{

	[MenuItem("Window/NavMeshEditor")]
	public static void ShowWindow()
	{
		GetWindow<NavMeshEditor>();
	}

	void OnGUI()
	{
		if (GUILayout.Button("Get Navmesh Info"))
		{
			foreach (GameObject obj in Selection.gameObjects)
			{
				NavMeshAgent agent = obj.GetComponent<NavMeshAgent>();
				if (agent != null)
				{
					Debug.Log("pos: " + obj.transform.position + " dest: " + agent.destination);
					EnemyController enemyController = obj.transform.Find("Enemy Mode").GetComponent<EnemyController>();
					Debug.Log("forwardPos: " + enemyController.moveBackAndForthState._forwardPos);
					Debug.Log("backPos: " + enemyController.moveBackAndForthState._backPos);
				}
			}
		}
	}

}
