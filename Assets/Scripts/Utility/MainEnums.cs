
namespace Platatformer2D
{
    public enum EnumTag
    {
        GROUND,
        LEVEL_EXIT,
        PIT
    }

    public enum Level
    {
        LOBBY,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5
    }

    public enum LevelStatus
    {
        LOCKED,
        UNLOCKED,
        COMPLETED
    }

    public enum ButtonType
    {
        START,
        EXIT,
        RESTART,
        QUIT,
        NEXT_LEVEL
    }
    public enum AudioType
    {
        BUTTON_CLICK,
        PLAYER_MOVE,
        PLAYER_DEATH,
        ENEMY_DEATH
    }
}