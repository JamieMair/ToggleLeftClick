using Terraria.GameInput;
using Terraria.ModLoader;
using PlayerInput = On.Terraria.GameInput.PlayerInput;

namespace ToggleLeftClick;

public class AltInputPlayer: ModPlayer
{
    private bool lastLeftMouse = false;
    public bool leftMouseDown { get; private set; } = false;
    private bool last_mouse_state = false;
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (triggersSet.MouseXButton2)
        {
            last_mouse_state = true;
            
        } else if (last_mouse_state) // Click
        {
            leftMouseDown = !leftMouseDown;
            last_mouse_state = false;
        }
        
        // Disable the toggle down if left mouse is clicked
        if (triggersSet.MouseLeft)
        {
            lastLeftMouse = true;
        } else if (lastLeftMouse)
        {
            leftMouseDown = false;
            lastLeftMouse = false;
        }

        if (leftMouseDown)
        {
            triggersSet.Left = true; // Reset to true
            this.Player.controlUseItem = true;
        }
        base.ProcessTriggers(triggersSet);
    }
    
    
}