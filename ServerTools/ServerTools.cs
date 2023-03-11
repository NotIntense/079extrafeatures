using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.Handlers;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace ServerTools
{
    public class ServerTools : Plugin<Config>
    {
        public static ServerTools Instance { get; private set; }
        public override string Name => "079extra";
        public override string Prefix => "079ex";
        public override string Author => "NotIntense#1613";
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version Version => new Version(4, 0, 0);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            Instance = null;
            base.OnDisabled();
        }

        public Handlers.SPlayer player;
        public Handlers.Server server;

        public void RegisterEvents()
        {
            player = new Handlers.SPlayer();
            server = new Handlers.Server();

            Server.WaitingForPlayers += server.OnWaitingForPlayers;
            Scp079.GainingLevel += player.SCPLevel;
        }

        public void UnRegisterEvents()
        {
            server = null;
            player = null;

            Server.WaitingForPlayers -= server.OnWaitingForPlayers;
            Scp079.GainingLevel -= player.SCPLevel;
        }
    }
}