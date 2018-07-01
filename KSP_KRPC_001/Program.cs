using System;
using System.Net;
using src;

class Program
{
    public static void Main()
    {
        Rocket rocket = new Rocket("127.0.0.1", 50000, 50001);

        rocket.launch();
    }
}