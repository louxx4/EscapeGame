namespace EscapeGame.Enums
{
    public enum RoomID
    {
        PopUp = -1,
        Start = 0,
        Story = 1,
        Kitchen = 2
    }

    public enum ObjectID
    {
        Fridge = 0,
        Oven = 1,
        CutleryDrawer = 2,
        Drawer = 3,
        Dishwasher = 4
    }

    public enum Character
    {
        None = 0,
        Robs = 1,
        Mutti = 2,
        Tabs = 3,
        Vati = 4,
        Lule = 5
    }

    public enum CharacterAction
    {
        Talking = 0
    }

    public enum BakingProgress
    {
        Raw = -10,
        Ready = 1,
        Burnt = 10
    }
}
