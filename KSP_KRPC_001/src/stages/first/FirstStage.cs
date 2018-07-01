using general;
using KRPC.Client.Services.SpaceCenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace stages.first
{
    class FirstStage : Launchable
    {
        private Control control;
        private Flight flightInfo;

        public FirstStage(Control control, Flight flight)
        {
            this.control = control;
            this.flightInfo = flight;
        }

        public void startStage()
        {
            control.Throttle = (float) 0.5;
            control.ActivateNextStage();


            float pitch = 0;
            float yaw = 0;

            while (true)
            {
                if(flightInfo.MeanAltitude >= 50000)
                {
                    pitch = 45;
                    if(flightInfo.Pitch>pitch)
                    {
                        control.Pitch = -1;
                    } else if(flightInfo.Pitch<pitch)
                    {
                        control.Pitch = 1;
                    }
                } else
                {
                    if (flightInfo.Pitch > pitch)
                    {
                        control.Pitch = -1;
                    }
                    else if (flightInfo.Pitch < pitch)
                    {
                        control.Pitch = 1;
                    }
                    
                    //if(flightInfo.)
                }
            }
        }
    }
}
