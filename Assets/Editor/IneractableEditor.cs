using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class IneractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if (interactable.useEvents) 
        {
            if (interactable.GetComponent<InteractionEvent>() == null)
            interactable.gameObject.AddComponent<Interactable>();
        }
        else 
        {
            if (interactable.GetComponent<InteractionEvent>() != null)
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
        }
    }
}
