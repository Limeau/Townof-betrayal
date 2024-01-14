using AmongUs.GameOptions;
using System.Collections.Generic;

using static TOHE.Options;

namespace TOHE.Roles.Neutral;

public static class Artist
{
    private static readonly int Id = 17483;
    public static bool IsEnable = false;

    private static OptionItem KillCooldown;
    private static OptionItem CanVent
    private static OptionItem HasImpostorVision;


    public static bool AbilityActivated;
  
    public static void SetupCustomOption()
    {
        Options.SetupRoleOptions(Id, TabGroup.Neutral, CustomRoles.Artist);
        SetupSingleRoleOptions(Id, TabGroup.NeutralRoles, CustomRoles.Artist, 1, zeroOne: false);
        HasImpostorVision = BooleanOptionItem.Create(Id + 12, "ImpostorVision", true, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Artist]);
        CanVent = BooleanOptionItem.Create(Id + 13, "CanVent", true, TabGroup.NeutralRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Artist]);
    }
    var pc = Utils.GetPlayerById(playerId);
        pc.AddDoubleTrigger();
    
    public static void Init()
    {
        playerIdList = new();
        CamoPlayer = new();
        TotalUses = new();
        IsEnable = false;
    }
    public static void Add(byte playerId)
    {
        playerIdList.Add(playerId);
        IsEnable = true;
        TotalSteals.Add(playerId, 0);
        if (playerId == PlayerControl.LocalPlayer.PlayerId && Main.nickName.Length != 0) CamoPlayer[playerId] = Main.nickName;
        else CamoPlayer[playerId] = Utils.GetPlayerById(playerId).Data.PlayerName;

        if (!AmongUsClient.Instance.AmHost) return;
        if (!Main.ResetCamPlayerList.Contains(playerId))
            Main.ResetCamPlayerList.Add(playerId);
    }

    private static void SendRPC(byte playerId, bool isTargetList = false)
    {
        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetArtistUseLimit, SendOption.Reliable, -1);
        writer.Write(playerId);
        writer.Write(TotalUses[playerId]);
        AmongUsClient.Instance.FinishRpcImmediately(writer);
    }

    public static void ReceiveRPC(MessageReader reader)
    {
        byte PlayerId = reader.ReadByte();
        int Limit = reader.ReadInt32();
        if (TotalUses.ContainsKey(PlayerId))
            TotalUses[PlayerId] = Limit;
        else
            TotalUses.Add(PlayerId, 0);
    }

    public static void SetKillCooldown(byte id) => Main.AllPlayerKillCooldown[id] = KillCooldown.GetFloat();


    public static GameData.PlayerOutfit Set(this GameData.PlayerOutfit instance, string playerName, int colorId, string hatId, string skinId, string visorId, string petId, string nameplateId)
    {
        instance.PlayerName = playerName;
        instance.ColorId = colorId;
        instance.HatId = hatId;
        instance.SkinId = skinId;
        instance.VisorId = visorId;
        instance.PetId = petId;
        instance.NamePlateId = nameplateId;
        return instance;
        
     private static void SetSkin(PlayerControl target, GameData.PlayerOutfit outfit)
        {
            var sender = CustomRpcSender.Create(name: $"Camouflage.RpcSetSkin({target.Data.PlayerName})");

            target.SetColor(outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetColor)
                .Write(outfit.ColorId)
                .EndRpc();

            target.SetHat(outfit.HatId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetHatStr)
                .Write(outfit.HatId)
                .EndRpc();

            target.SetSkin(outfit.SkinId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetSkinStr)
                .Write(outfit.SkinId)
                .EndRpc();

            target.SetVisor(outfit.VisorId, outfit.ColorId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetVisorStr)
                .Write(outfit.VisorId)
                .EndRpc();

            target.SetPet(outfit.PetId);
            sender.AutoStartRpc(target.NetId, (byte)RpcCalls.SetPetStr)
                .Write(outfit.PetId)
                .EndRpc();

            sender.SendMessage();
        }
    }
}
{
            public static void ApplyGameOptions(IGameOptions opt) => opt.SetVision(HasImpostorVision.GetBool());
        public static void CanUseVent(PlayerControl player)
        {
            bool canUse = CanVent.GetBool();
            DestroyableSingleton<HudManager>.Instance.ImpostorVentButton.ToggleVisible(canUse && !player.Data.IsDead);
            player.Data.Role.CanVent = canUse;
        }
