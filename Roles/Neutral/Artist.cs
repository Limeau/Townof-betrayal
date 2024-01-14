using AmongUs.GameOptions;
using System.Collections.Generic;

using static TOHE.Options;

namespace TOHE.Roles.Neutral;

public static class Artist
{
    private static readonly int Id = 17483;
    public static bool IsEnable = false;

    private static OptionItem KillCooldown;
    private static OptionItem CamoCooldown;
    private static OptionItem CamoDuration;
    private static OptionItem HasImpostorVision;
    public static OptionItem DisableReportWhenCamouflageIsActive;

    public static bool AbilityActivated;
  
    public static void SetupCustomOption()
    {
        Options.SetupRoleOptions(Id, TabGroup.Neutral, CustomRoles.Artist);
        SetupSingleRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Artist, 1, zeroOne: false);
        CamoCooldown = FloatOptionItem.Create(Id + 2, "CamouflageCooldown", new(1f, 180f, 1f), 25f, TabGroup.NeutralRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Artist])
                .SetValueFormat(OptionFormat.Seconds);
        CamoDuration = FloatOptionItem.Create(Id + 4, "CamouflageDuration", new(1f, 180f, 1f), 10f, TabGroup.NeutralRoles, false).SetParent(Options.CustomRoleSpawnChances[CustomRoles.Artist])
                .SetValueFormat(OptionFormat.Seconds);
        HasImpostorVision = BooleanOptionItem.Create(Id + 14, "ImpostorVision", true, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Artist]);
    }
