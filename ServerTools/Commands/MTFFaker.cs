using CommandSystem;
using RemoteAdmin;
using System;
using System.Collections.Generic;

namespace ServerTools.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class MTFFaker : ICommand
    {
        public static Dictionary<string, DateTime> cooldowns = new Dictionary<string, DateTime>();
        public string Command => "fakemtf";

        public string[] Aliases => new[] { "fakeMTF", "fm" };

        public string Description => "Fakes an MTF broadcast to all players";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            PlayerCommandSender playerCommandSender = sender as PlayerCommandSender;
            if (playerCommandSender == null)
            {
                response = "You must run this command as a client";
                return false;
            }

            if (ServerTools.Instance.player.Nametocheck.Contains(playerCommandSender.SenderId))
            {
                if (cooldowns.TryGetValue(playerCommandSender.SenderId, out DateTime cooldownEnd) && DateTime.Now < cooldownEnd)
                {
                    response = $"This command is on cooldown. Please wait {Math.Ceiling((cooldownEnd - DateTime.Now).TotalSeconds)} seconds.";
                    return false;
                }

                ServerTools.Instance.player.MTFAnnoucments();
                cooldowns[playerCommandSender.SenderId] = DateTime.Now.AddSeconds(120);
                response = "Faked MTF announcement!";
                return true;
            }

            response = "You cannot use this command yet";
            return false;
        }
    }
}