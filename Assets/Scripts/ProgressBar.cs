using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : FillBar {

    // Event to invoke when the progress bar fills up
    private UnityEvent onProgressComplete;

    // Create a property to handle the slider's value
    public new float CurrentValue {
        get {
            return base.CurrentValue;
        }
        set {
            // If the value exceeds the max fill, invoke the completion function
            if (value >= mySlider.maxValue)
                onProgressComplete.Invoke();

   
            base.CurrentValue = value;
        }
    }
    
    void Start () {
        // Initialize onProgressComplete and set a basic callback
        if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
    }
	
    void Update () {
        CurrentValue = (myPlayer.jumpCharge -  myPlayer.minJumpVelocity)/(myPlayer.maxJumpVelocity - myPlayer.minJumpVelocity);
    }

    // The method to call when the progress bar fills up
    void OnProgressComplete() {
        Debug.Log("Progress Complete");
    }
}