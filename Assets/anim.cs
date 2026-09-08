using UnityEngine;

public class ShowAndPlayAnimation : MonoBehaviour
{
    [System.Serializable]
    public class AnimTarget
    {
        public GameObject modelRoot;        // animation model object (enable/disable)
        public Animator animator;           // animator on that model
        public string stateName = "Swim";   // state to play (exact)
    }

    [Header("Play ALL these animations when Workout button is clicked")]
    public AnimTarget[] targets;

    [Header("Options")]
    public bool hideOnStart = true;
    public bool toggleOnButton = true;   // clicking same workout button hides it

    private bool isVisible;

    // ✅ Global: only one muscle workout active at a time
    private static ShowAndPlayAnimation currentActive;

    void Awake()
    {
        // Auto-fill animators if missing
        if (targets != null)
        {
            foreach (var t in targets)
            {
                if (t == null) continue;
                if (t.modelRoot != null && t.animator == null)
                    t.animator = t.modelRoot.GetComponentInChildren<Animator>(true);
            }
        }

        if (hideOnStart)
            ForceHideAll();   // IMPORTANT: prevents auto-play
    }

    void Start()
    {
        if (hideOnStart)
        {
            isVisible = false;
        }
        else
        {
            isVisible = AnyTargetActive();
            if (isVisible) currentActive = this;
        }
    }

    // ✅ CALL THIS FROM YOUR WORKOUT BUTTON (OnClick)
    public void OnButtonClick()
    {
        // Close any other active muscle workout first
        if (currentActive != null && currentActive != this)
            currentActive.HideAndStop();

        // Toggle if same workout is already open
        if (toggleOnButton && isVisible)
        {
            HideAndStop();
            return;
        }

        ShowAndPlayAll();
    }

    private void ShowAndPlayAll()
    {
        currentActive = this;
        isVisible = true;

        if (targets == null) return;

        foreach (var t in targets)
        {
            if (t == null || t.modelRoot == null) continue;

            // ✅ turn on model
            t.modelRoot.SetActive(true);

            // ✅ then enable animator + play
            if (t.animator != null)
            {
                t.animator.enabled = true;
                t.animator.speed = 1f;
                t.animator.Play(t.stateName, 0, 0f);
            }
        }
    }

    public void HideAndStop()
    {
        if (targets != null)
        {
            foreach (var t in targets)
            {
                if (t == null || t.modelRoot == null) continue;

                if (t.animator != null)
                {
                    t.animator.speed = 0f;
                    t.animator.enabled = false;   // ✅ prevents auto replay
                }

                t.modelRoot.SetActive(false);
            }
        }

        isVisible = false;

        if (currentActive == this)
            currentActive = null;
    }

    // ✅ use this when selecting a NEW muscle (hide previous workout)
    public static void HideCurrentWorkout()
    {
        if (currentActive != null)
            currentActive.HideAndStop();
    }

    // -------- helpers --------

    private void ForceHideAll()
    {
        if (targets == null) return;

        foreach (var t in targets)
        {
            if (t == null || t.modelRoot == null) continue;

            if (t.animator != null)
            {
                t.animator.speed = 0f;
                t.animator.enabled = false;   // ✅ key line
            }

            t.modelRoot.SetActive(false);
        }
    }

    private bool AnyTargetActive()
    {
        if (targets == null) return false;
        foreach (var t in targets)
            if (t != null && t.modelRoot != null && t.modelRoot.activeSelf)
                return true;
        return false;
    }
}
