using Appsulove.Views.UserInput;
using UnityEngine;

public class UIView : IUserInterfaceView
{
    private readonly Screens _screens;

    private UIMessage _pause = new();
    private UIMessage _resume = new();

    public bool Pause => _pause.TryGet();
    public bool Resume => _resume.TryGet();

    public UIView(Screens screens)
    {
        _screens = screens;
        //TODO: apply Demeter Law
        _screens.HUD.ControlPanel.PauseButton.onClick.AddListener(_pause.Set);
        _screens.HUD.ControlPanel.ResumeButton.onClick.AddListener(_resume.Set);
    }

    //TODO: apply Demeter Law
    public Vector2 TouchPosition => _screens.HUD.TouchScreen.TouchPosition;

    void IUserInterfaceView.Update(int score, float distance)
    {
        _screens.HUD.ScorePanel.UpdateView(score, distance);
    }

    void IUserInterfaceView.ShowPause(bool value)
    {
        _screens.HUD.ControlPanel.PauseButton.gameObject.SetActive(!value);
        _screens.HUD.ControlPanel.ResumeButton.gameObject.SetActive(value);
    }
}
