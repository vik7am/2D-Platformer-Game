
namespace Platatformer2D
{
    public enum EnumTag
    {
        GROUND,
        LEVEL_EXIT,
        PIT,
        PLATFORM
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
        START_LEVEL,
        LEVEL_COMPLETE,
        LEVEL_FAIL,
        KEY_COLLECTED,
        ENEMY_ATTACK
    }
}