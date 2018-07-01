using general;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using System;

namespace stages.first
{
    class FirstStage : Launchable
    {
        private Control control;
        private Flight flightInfo;
        private Connection con;
        private Vessel vessel;

        public FirstStage(Connection con)
        {
            this.con = con;
            var spaceCenter = con.SpaceCenter();
            this.vessel = spaceCenter.ActiveVessel;

            this.control = vessel.Control;
            this.flightInfo = vessel.Flight();

        }

        public void startStage()
        {
            //control.Throttle = (float) 0.5;
            control.ActivateNextStage();


            float pitch = 90;
            float yaw = 0;

            var pitchStream = con.AddStream(() => flightInfo.Pitch);
            float curPitch = 0.0f;

            var altitudeStream = con.AddStream(() => flightInfo.MeanAltitude);
            double curAltitude = 0.0;

            while (true)
            {
                curPitch = pitchStream.Get();
                curAltitude = altitudeStream.Get();
            }
        }
    }
}
