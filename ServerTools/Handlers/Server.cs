using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;

namespace ServerTools.Handlers
{
    public class Server
    {
        public void OnRoundRestart(RoundEndedEventArgs ev)
        {          
            ServerTools.Instance.player.Nametocheck.Clear();
            ServerTools.Instance.player.Nametocheck2.Clear();
        }
    }
}