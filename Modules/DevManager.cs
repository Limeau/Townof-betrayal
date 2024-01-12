using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TOHE;

public class DevUser
{
    public string Code { get; set; }
    public string Color { get; set; }
    public string Tag { get; set; }
    public bool IsUp { get; set; }
    public bool IsDev { get; set; }
    public bool DeBug { get; set; }
    public bool ColorCmd { get; set; }
    public string UpName { get; set; }
    public DevUser(string code = "", string color = "null", string tag = "null", bool isUp = false, bool isDev = false, bool deBug = false, bool colorCmd = false, string upName = "未认证用户")
    {
        Code = code;
        Color = color;
        Tag = tag;
        IsUp = isUp;
        IsDev = isDev;
        DeBug = deBug;
        ColorCmd = colorCmd;
        UpName = upName;
    }

    public bool HasTag() => Tag != "null";
    //public string GetTag() => Color == "null" ? $"<size=1.2>{Tag}</size>\r\n" : $"<color={Color}><size=1.2>{(Tag == "#Dev" ? Translator.GetString("Developer") : Tag)}</size></color>\r\n";
    public string GetTag()
    {
        string tagColorFilePath = @$"./TOHE-DATA/Tags/SPONSOR_TAGS/{Code}.txt";

        if (Color == "null" || Color == string.Empty) return $"<size=1.2>{Tag}</size>\r\n";
        var startColor = Color.TrimStart('#');

        if (File.Exists(tagColorFilePath))
        {
            var ColorCode = File.ReadAllText(tagColorFilePath);
            if (Utils.CheckColorHex(ColorCode)) startColor = ColorCode;
        }
        string t1;
        t1 = Tag == "#Dev" ? Translator.GetString("Developer") : Tag;
        return $"<size=1.2><color=#{startColor}>{t1}</color></size>\r\n";
    }
    //public string GetTag() 
    //{
    //    string tagColorFilePath = @$"./TOHE-DATA/Tags/SPONSOR_TAGS/{Code}.txt";

    //    if (Color == "null" || Color == string.Empty) return $"<size=1.2>{Tag}</size>\r\n";
    //    var startColor = "FFFF00";
    //    var endColor = "FFFF00";
    //    var startColor1 = startColor;
    //    var endColor1 = endColor;
    //    if (Color.Split(",").Length == 1)
    //    {
    //        startColor1 = Color.Split(",")[0].TrimStart('#');
    //        endColor1 = startColor1;
    //    }
    //    else if (Color.Split(",").Length == 2)
    //    {
    //         startColor1 = Color.Split(",")[0].TrimStart('#');
    //         endColor1 = Color.Split(",")[1].TrimStart('#');
    //    }
    //    if (File.Exists(tagColorFilePath))
    //    {
    //        var ColorCode = File.ReadAllText(tagColorFilePath);
    //        if (ColorCode.Split(" ").Length == 2)
    //        {
    //            startColor = ColorCode.Split(" ")[0];
    //            endColor = ColorCode.Split(" ")[1];
    //        }
    //        else
    //        {
    //            startColor = startColor1;
    //            endColor = endColor1;
    //        }
    //    }
    //    else
    //    {
    //        startColor = startColor1;
    //        endColor = endColor1;
    //    }
    //    if (!Utils.CheckGradientCode($"{startColor} {endColor}"))
    //    {
    //        startColor = "FFFF00";
    //        endColor = "FFFF00";
    //    }
    //    var t1 = "";
    //    t1 = Tag == "#Dev" ? Translator.GetString("Developer") : Tag;
    //    return $"<size=1.2>{Utils.GradientColorText(startColor,endColor, t1)}</size>\r\n";
    //}
}

public static class DevManager
{
    private readonly static DevUser DefaultDevUser = new();
    public readonly static List<DevUser> DevUserList = new();
    public static void Init()
    {
        // Dev
        DevUserList.Add(new(code: "actorour#0029", color: "#ffc0cb", tag: "Original Developer", isUp: true, isDev: true, deBug: true, colorCmd: true, upName: "KARPED1EM"));
        DevUserList.Add(new(code: "noshsame#8116", color: "#011efe", tag: "TOB Developer", isUp: true, isDev: true, deBug: true, colorCmd: true, upName: "TheKiller"));
        DevUserList.Add(new(code: "latevoice#4590", color: "#50ef39", tag: "TOB Developer", isUp: true, isDev: true, deBug: true, colorCmd: true, upName: "Lime"));
        DevUserList.Add(new(code: "mopmeaning#9586", color: "#c955e6", tag: "TOB Developer", isUp: true, isDev: true, deBug: true, colorCmd: true, upName: "sleepyfor"));


        // Tester
        DevUserList.Add(new(code: "fluffycord#2605", color: "#ff00ff", tag: "Tester", isUp: true, isDev: false, deBug: true, colorCmd: false, upName: "Sarhadacty"));
        DevUserList.Add(new(code: "firmshame#7569", color: "#783ed3", tag: "Tester", isUp: true, isDev: false, deBug: true, colorCmd: false, upName: "Yankee"));
        DevUserList.Add(new(code: "chillybead#3274", color: "#ffbbbb", tag: "Tester", isUp: true, isDev: false, deBug: true, colorCmd: false, upName: "RiRi"));
        DevUserList.Add(new(code: "awayfluid#4702", color: "#dd91b2", tag: "Tester", isUp: true, isDev: false, deBug: true, colorCmd: false, upName: "tasha"));
    }
}
        
