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


            while(true)
            {

            }
        }
    }
}
