using CommandSystem;
using RemoteAdmin;
using System;
using System.Collections.Generic;

namespace ServerTools.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Noise : ICommand
    {
        public static Dictionary<string, DateTime> cooldowns2 = new Dictionary<string, DateTime>();
        public string Command => "079noise";

        public string[] Aliases => new[] { "noise", "spook", "079n" };

        public string Description => "Makes a unnerving sound throughout the facility";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            PlayerCommandSender playerCommandSender = sender as PlayerCommandSender;
            if (playerCommandSender == null)
            {
                response = "You must run this command as a client";
                return false;
            }

            if (ServerTools.Instance.player.Nametocheck2.Contains(playerCommandSender.Nickname))
            {
                if (cooldowns2.TryGetValue(playerCommandSender.Nickname, out DateTime cooldownEnd2) && DateTime.Now < cooldownEnd2)
                {
                    response = $"This command is on cooldown. Please wait {Math.Ceiling((cooldownEnd2 - DateTime.Now).TotalSeconds)} seconds.";
                    return false;
                }

                ServerTools.Instance.player.SpookyScream();
                cooldowns2[playerCommandSender.Nickname] = DateTime.Now.AddSeconds(100);
                response = "079 Noise made";
                return true;
            }

            response = "You cannot use this command yet";
            return false;
        }
    }
}