
//CONCRETE
public class MoveUpCommand : ICommand
{
    private readonly PlayerMovement playerMovement;

    public MoveUpCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.MoveUp();
    }
}
