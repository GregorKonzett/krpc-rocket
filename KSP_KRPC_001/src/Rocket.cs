using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using stages.first;

namespace src
{
    class Rocket
    {
        string ip;
        int rpc;
        int stream;

        public Rocket(string ip,int rpc,int stream)
        {
            this.ip = ip;
            this.rpc = rpc;
            this.stream = stream;
        }

        public void launch()
        {
            using (var connection = new Connection(
                   address: IPAddress.Parse(ip),
                   rpcPort: rpc,
                   streamPort: stream))
            {
                var spaceCenter = connection.SpaceCenter();
                var vessel = spaceCenter.ActiveVessel;

                var control = vessel.Control;
                var flightInfo = vessel.Flight();


                FirstStage firstStage = new FirstStage(control, flightInfo);

                firstStage.startStage();
            }
        }
    }
}
