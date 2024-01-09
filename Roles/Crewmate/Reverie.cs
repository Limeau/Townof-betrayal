using System;
using System.Collections.Generic;
using static TOHE.Options;
using System.Linq;

namespace TOHE;

public static class Reverie
{
    private static readonly int Id = 11100;
    public static List<byte> playerIdList = new();
    public static bool IsEnable = false;

    public static OptionItem DefaultKillCooldown;
    public static OptionItem ReduceKillCooldown;
    
    public static OptionItem MinKillCooldown;
    
    
    
    

    public static Dictionary<byte, float> NowCooldown;

    public static void SetupCustomOption()
    {
        SetupRoleOptions(Id, TabGroup.CrewmateRoles, CustomRoles.Reverie);
        DefaultKillCooldown = FloatOptionItem.Create(Id + 10, "SansDefaultKillCooldown", new(0f, 180f, 2.5f), 30f, TabGroup.CrewmateRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reverie])
            .SetValueFormat(OptionFormat.Seconds);
        ReduceKillCooldown = FloatOptionItem.Create(Id + 11, "SansReduceKillCooldown", new(0f, 180f, 2.5f), 7.5f, TabGroup.CrewmateRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reverie])
            .SetValueFormat(OptionFormat.Seconds);
        MinKillCooldown = FloatOptionItem.Create(Id + 12, "SansMinKillCooldown", new(0f, 180f, 2.5f), 2.5f, TabGroup.CrewmateRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reverie])
            .SetValueFormat(OptionFormat.Seconds);
        
      
      
      
       
    }
    public static void Init()
    {
        playerIdList = new();
        NowCooldown = new();
        IsEnable = false;
    }
    public static void Add(byte playerId)
    {
        playerIdList.Add(playerId);
        NowCooldown.TryAdd(playerId, DefaultKillCooldown.GetFloat());
        IsEnable = true;

        if (!AmongUsClient.Instance.AmHost) return;
        if (!Main.ResetCamPlayerList.Contains(playerId))
            Main.ResetCamPlayerList.Add(playerId);
    }
    public static void OnReportDeadBody()
    {
        foreach(var playerId in NowCooldown.Keys)
        {
            if (ResetCooldownMeeting.GetBool())
            {
                NowCooldown[playerId] = DefaultKillCooldown.GetFloat();
            }
        }
    }
    public static void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = NowCooldown[id];
    public static void OnCheckMurder(PlayerControl killer,PlayerControl target)
    {
        if (killer == null || target == null) return;
        if (!IsEnable || !killer.Is(CustomRoles.Reverie)) return;
        float kcd;
      
        NowCooldown[killer.PlayerId] = Math.Clamp(kcd, MaxKillCooldown.GetFloat();
       
        }
    }
}
