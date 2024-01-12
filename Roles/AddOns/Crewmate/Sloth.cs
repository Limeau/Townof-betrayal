using AmongUs.GameOptions;
using static TOHE.Options;

namespace TOHE.Roles.AddOns.Common;

public static class Sloth
{
    private static readonly int Id = 27893;

    private static OptionItem OptionSpeed;

    public static void SetupCustomOption()
    {
        SetupAdtRoleOptions(Id, CustomRoles.Sloth, canSetNum: true, tab: TabGroup.Addons);
        OptionSpeed = FloatOptionItem.Create(Id + 10, "SlothSpeed", new(0.25f, 5f, 0.25f), 2.5f, TabGroup.Addons, false)
            .SetParent(CustomRoleSpawnChances[CustomRoles.Flash])
            .SetValueFormat(OptionFormat.Multiplier);
    }
    public static void SetSpeed(byte playerId, bool clearAddOn)
    {
        if (!clearAddOn)
            Main.AllPlayerSpeed[playerId] = OptionSpeed.GetFloat();
        else
            Main.AllPlayerSpeed[playerId] = Main.RealOptionsData.GetFloat(FloatOptionNames.PlayerSpeedMod);
    }
}
