﻿// *** SendandReceive ***

// This example expands the previous Receive example. The Arduino will now send back a status.
// It adds a demonstration of how to:
// - Handle received commands that do not have a function attached
// - Receive a command with a parameter from the Arduino

using System;
using System.Threading;
using CommandMessenger;
using CommandMessenger.TransportLayer;

namespace SendAndReceive
{
    // This is the list of recognized commands. These can be commands that can either be sent or received. 
    // In order to receive, attach a callback function to these events
    enum Command
    {
        SetLed, 
        Status, 
    };

    public class SendAndReceive
    {
        public bool RunLoop { get; set; }
        private SerialTransport _serialTransport;
        private CmdMessenger _cmdMessenger;
        private bool _ledState;
        private int _count;

        // Setup function
        public void Setup()
        {
            _ledState = false;

            // Create Serial Port object
            // Note that for some boards (e.g. Sparkfun Pro Micro) DtrEnable may need to be true.
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = "COM3", BaudRate = 115200, DtrEnable = false } // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            _cmdMessenger = new CmdMessenger(_serialTransport) 
                {
                    BoardType = BoardType.Bit16 // Set if it is communicating with a 16- or 32-bit Arduino board
                };

            // Tell CmdMessenger if it is communicating with a 16 or 32 bit Arduino board

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();
            
            // Start listening
            _cmdMessenger.StartListening();                                
        }

        // Loop function
        public void Loop()
        {
            _count++;

            // Create command
            var command = new SendCommand((int)Command.SetLed,_ledState);               

            // Send command
            _cmdMessenger.SendCommand(command);

            // Wait for 1 second and repeat
            Thread.Sleep(1000);
            _ledState = !_ledState;                                        // Toggle led state  

            if (_count > 5) RunLoop = false;                             // Stop loop after 100 rounds
        }

        public void reset()
        {
            _count = 0;
            RunLoop = true;
            Setup();
        }

        // Exit function
        public void Exit()
        {
            // Stop listening
            _cmdMessenger.StopListening();

            // Dispose Command Messenger
            _cmdMessenger.Dispose();

            // Dispose Serial Port object
            _serialTransport.Dispose();

            // Pause before stop
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }

        /// Attach command call backs. 
        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Status, OnStatus);
        }

        /// Executes when an unknown command has been received.
        void OnUnknownCommand(ReceivedCommand arguments)
        {
            Console.WriteLine("Command without attached callback received");
        }

        // Callback function that prints the Arduino status to the console
        void OnStatus(ReceivedCommand arguments)
        {
            Console.Write("Arduino status: ");
            Console.WriteLine(arguments.ReadStringArg());
        }
    }
}
