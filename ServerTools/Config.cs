using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace ServerTools
{
    public class Config : IConfig
    {
        [Description("Sets the plugin enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("No need to touch this :3")]
        public bool Debug { get; set; } = false;

        [Description("The message that appears when 079 gets level 5")]
        public string Level5 { get; set; } = "You can now fake MTF broadcasts! Use .fakeMTF to fake one!";

        [Description("The message that appears when 079 gets level 2")]
        public string Level2 { get; set; } = "You can now play a scary noise! Use .079noise to play a weird sound.";

        [Description("The NATO phonetic alphabetic words C.A.S.S.I.E will call when .fakeMTF is used. YOU HAVE TO USE NATO_ FOR IT TO WORK")]
        public List<string> MTFNATO { get; set; } = new List<string>
          { "NATO_A",
            "NATO_B",
            "NATO_D",
            "NATO_C",
            "NATO_D",
            "NATO_E",
            "NATO_F",
            "NATO_G",
            "NATO_H",
            "NATO_I",
            "NATO_J",
            "NATO_K",
            "NATO_L",
            "NATO_M",
            "NATO_N",
            "NATO_O",
            "NATO_P",
            "NATO_Q",
            "NATO_R",
            "NATO_S",
            "NATO_T",
            "NATO_U",
            "NATO_V",
            "NATO_W",
            "NATO_X",
            "NATO_Y",
            "NATO_Z" 
        };

        [Description("The numbers C.A.S.S.I.E will use when .fakeMTF is used")]
        public List<string> MTFNumber { get; set; } = new List<string> {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15" };
    }
}