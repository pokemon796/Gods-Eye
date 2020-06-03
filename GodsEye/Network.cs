using System;
using System.Net.NetworkInformation;

namespace GodsEye
{
    public class Network
    {
        public static Network Main;

        private readonly Action WhenReconnected;
        private readonly Action WhenDisconnected;

        private bool booting;

        public Network(Action WhenReconnected, Action WhenDisconnected)
        {
            this.booting = true;

            this.WhenReconnected = WhenReconnected;
            this.WhenDisconnected = WhenDisconnected;

            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(this.ConnectionAltered);
        }

        public bool IsConnected()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private void ConnectionAltered(object sender, NetworkAvailabilityEventArgs e)
        {
            if (booting)
            {
                if (e.IsAvailable)
                {
                    this.WhenReconnected();
                }
                else
                {
                    this.WhenDisconnected();
                }
            }
            else
            {
                booting = false;
            }
        }
    }
}
