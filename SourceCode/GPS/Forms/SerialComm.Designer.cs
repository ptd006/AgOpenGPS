//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Windows.Forms;
using System.Globalization;
using AgOpenGPS.Properties;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public static string portNameGPS = "COM GPS";
        public static int baudRateGPS = 4800;

        public static string portNameGPS2 = "COM GPS";
        public static int baudRateGPS2 = 4800;

        public static string portNameRelaySection = "COM Sect";
        public static int baudRateRelaySection = 38400;

        public static string portNameAutoSteer = "COM AS";
        public static int baudRateAutoSteer = 38400;

        //private string[] words;

        public string NMEASentence = "No Data";

        //used to decide to autoconnect section arduino this run
        public bool wasRateRelayConnectedLastRun = false;
        public string recvSentenceSettings = "InitalSetting";

        //used to decide to autoconnect autosteer arduino this run
        public bool wasAutoSteerConnectedLastRun = false;

        //serial port gps is connected to
        public SerialPort spGPS = new SerialPort(portNameGPS, baudRateGPS, Parity.None, 8, StopBits.One);


        public SerialPort spGPS2 = new SerialPort(portNameGPS2, baudRateGPS2, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spRelay = new SerialPort(portNameRelaySection, baudRateRelaySection, Parity.None, 8, StopBits.One);

        //serial port AutoSteer is connected to
        public SerialPort spAutoSteer = new SerialPort(portNameAutoSteer, baudRateAutoSteer, Parity.None, 8, StopBits.One);

        #region AutoSteerPort // --------------------------------------------------------------------

        public void AutoSteerDataOutToPort()
        {
            //default to a stop initially
            //mc.machineControlData[mc.cnPedalControl] &= 0b00111111;

            //if (isInAutoDrive) //Is in Auto Drive Mode enabled
            //{
            //    if (!ast.isInFreeDriveMode)
            //    {
            //        //make it go - or with 1
            //        if (recPath.isDrivingRecordedPath)
            //        {
            //            mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //        }

            //        if (self.isSelfDriving)
            //        {
            //            mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //        }
            //    }
            //    else //in AutoDrive and FreeDrive
            //    {
            //        mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //    }

            //    ////Is there something in the way?
            //    //if (isLidarBtnOn && (mc.lidarDistance > 200 && mc.lidarDistance < 1000))
            //    //{
            //    //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //    //}
            //}
            //else // Auto/Manual is in Manual so release the clutch only
            //{
            //    //release the clutch for manual driving
            //    mc.machineControlData[mc.cnPedalControl] |= 0b01000000;
            //    mc.machineControlData[mc.cnPedalControl] &= 0b01111111;
            //}

            ////pause the thing if paused. Duh.
            //if (recPath.isPausedDrivingRecordedPath)
            //{
            //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //}

            ////gone out of bounds so full stop.
            //if (mc.isOutOfBounds)
            //{
            //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //}

            //add the out of bounds bit to uturn byte bit 7
            if (mc.isOutOfBounds) 
                mc.autoSteerData[mc.sdYouTurnByte] |= 0b10000000;            
            else 
                mc.autoSteerData[mc.sdYouTurnByte] &= 0b01111111;

            //send out to network
            if (Properties.Settings.Default.setUDP_isOn)
            {
                //machine control
                //SendUDPMessage(mc.machineControlData);

                //send autosteer since it never is logic controlled
                SendUDPMessage(mc.autoSteerData);

                //rate control
                SendUDPMessage(mc.relayData);
            }

            //Tell Arduino the steering parameter values
            if (spAutoSteer.IsOpen)
            {
                if (Properties.Settings.Default.isJRK)
                {
                    byte[] command = new byte[2];
                    int target;
                    target = guidanceLineSteerAngle * Properties.Settings.Default.setAS_countsPerDegree;
                    target /= 100;
                    target += ((Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5); //steeroffstet                   
                    target += 2047; //steerangle center
                    
                    if (target > 4075) target = 4075;
                    if (target < 0) target = 0;
                    command[0] = unchecked((byte)(0xC0 + (target & 0x1F)));
                    command[1] = unchecked((byte)((target >> 5) & 0x7F));
                    spAutoSteer.Write(command, 0, 2);

                    ////send get scaledfeedback command
                    byte[] command2 = new byte[1];
                    command2[0] = 0xA7;

                    spAutoSteer.Write(command2, 0, 1);

                }
                else
                {
                    try { spAutoSteer.Write(mc.autoSteerData, 0, CModuleComm.numSteerDataItems); }
                    catch (Exception e)
                    {
                        WriteErrorLog("Out Data to Steering Port " + e.ToString());
                        SerialPortAutoSteerClose();
                    }
                }


                
            } 
        }

        public void AutoSteerSettingsOutToPort()
        {
            //send out the settings
            //send out to network
            if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.autoSteerSettings);
            }

            //Tell Arduino autoSteer settings
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(mc.autoSteerSettings, 0, CModuleComm.numSteerSettingItems ); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Settings to Steer Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }
        }

        //called by the AutoSteer module delegate every time a chunk is rec'd

        public double actualSteerAngleDisp = 0;

        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            mc.serialRecvAutoSteerStr = sentence;

            //0 - actual steer angle*100, 1 - setpoint steer angle*100, 2 - heading in degrees * 16, 3 - roll in degrees * 16, 4 - steerSwitch position

            string[] words = mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
            {
                //update the progress bar for autosteer.
                if (pbarSteer++ > 99) pbarSteer=0;

                double.TryParse(words[0], NumberStyles.Float, CultureInfo.InvariantCulture, out actualSteerAngleDisp);
               

                //first 2 used for display mainly in autosteer window chart as strings
                //parse the values
                if (ahrs.isHeadingFromAutoSteer)
                {
                    int.TryParse(words[2], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.correctionHeadingX16);
                }

                if (ahrs.isRollFromAutoSteer) int.TryParse(words[3], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.rollX16);

                int.TryParse(words[4], out mc.steerSwitchValue);
                mc.workSwitchValue = mc.steerSwitchValue & 1;
                mc.steerSwitchValue = mc.steerSwitchValue & 2;
            }
        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerAutoSteer(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedAutoSteer(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spAutoSteer.IsOpen)
            {
                


                if (!Properties.Settings.Default.isJRK)
                {
                    try
                    {
                        //System.Threading.Thread.Sleep(25);
                        string sentence = spAutoSteer.ReadLine();
                        this.BeginInvoke(new LineReceivedEventHandlerAutoSteer(SerialLineReceivedAutoSteer), sentence);
                    }
                    //this is bad programming, it just ignores errors until its hooked up again.
                    catch (Exception ex)
                    {
                        WriteErrorLog("AutoSteer Recv" + ex.ToString());
                    }

                }
                else   //get 2 byte feedback from pololu

                {


                    byte[] buffer = new byte[2];
                    spAutoSteer.Read(buffer, 0, 2);
                    int feedback = buffer[0] + 256 * buffer[1];

                    actualSteerAngleDisp = feedback - 2047;
                    //andreas ortner changed this one
                    //actualSteerAngleDisp -= (Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5;
                    actualSteerAngleDisp += (Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5;
                    actualSteerAngleDisp /= Properties.Settings.Default.setAS_countsPerDegree;
                    actualSteerAngleDisp *= 100;                               
                }
            }
        }

        //open the Arduino serial port
        public void SerialPortAutoSteerOpen()
        {
            if (!spAutoSteer.IsOpen)
            {
                spAutoSteer.PortName = portNameAutoSteer;
                spAutoSteer.BaudRate = baudRateAutoSteer;
                spAutoSteer.DataReceived += sp_DataReceivedAutoSteer;
            }

            try { spAutoSteer.Open(); }
            catch (Exception e)
            {
                WriteErrorLog("Opening Steer Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No AutoSteer Port Active");

                Properties.Settings.Default.setPort_wasAutoSteerConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spAutoSteer.IsOpen)
            {
                spAutoSteer.DiscardOutBuffer();
                spAutoSteer.DiscardInBuffer();

                //update port status label

                Properties.Settings.Default.setPort_portNameAutoSteer = portNameAutoSteer;
                Properties.Settings.Default.setPort_wasAutoSteerConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortAutoSteerClose()
        {
            if (spAutoSteer.IsOpen)
            {
                spAutoSteer.DataReceived -= sp_DataReceivedAutoSteer;
                try { spAutoSteer.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing steer Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Properties.Settings.Default.setPort_wasAutoSteerConnected = false;
                Properties.Settings.Default.Save();

                spAutoSteer.Dispose();
            }
        }

        #endregion

        #region RelaySerialPort //--------------------------------------------------------------------

        //build the byte for individual realy control
        private void BuildRelayByte()
        {
            int set = 1;
            int reset = 2046;
            mc.relayData[mc.rdSectionControlByteHi] = (byte)0;
            mc.relayData[mc.rdSectionControlByteLo] = (byte)0;

            int relay = 0;

            //check if super section is on
            if (section[vehicle.numOfSections].isSectionOn)
            {
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    relay = relay | set;
                    set = (set << 1);
                }
            }

            else
            {
                for (int j = 0; j < MAXSECTIONS; j++)
                {
                    //set if on, reset bit if off
                    if (section[j].isSectionOn) relay = relay | set;
                    else relay = relay & reset;

                    //move set and reset over 1 bit left
                    set = (set << 1);
                    reset = (reset << 1);
                    reset = (reset + 1);
                }
            }

            //rate port gets high and low byte
            mc.relayData[mc.rdSectionControlByteHi] = unchecked((byte)(relay >> 8));
            mc.relayData[mc.rdSectionControlByteLo] = unchecked((byte)relay);


            //autosteer gets only the first 8 sections
            mc.autoSteerData[mc.sdRelayLo] = unchecked((byte)(mc.relayData[mc.rdSectionControlByteLo]));
        }

        //Send relay info out to relay board
        public void RelayOutToPort(byte[] items, int numItems)
        {
            //load the uturn byte with the accumulated spacing
            if (vehicle.treeSpacing != 0) mc.relayData[mc.rdTree] = unchecked((byte)treeTrigger);

            //grab the youturn byte
            mc.relayData[mc.rdUTurn] = mc.machineControlData[mc.cnYouTurn];

            //speed
            mc.relayData[mc.rdSpeedXFour] = unchecked((byte)(pn.speed * 4));

            if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.relayData);
            }
            
            //Tell Arduino to turn section on or off accordingly
            if (spRelay.IsOpen)
            {
                try { spRelay.Write(items, 0, numItems); }
                catch (Exception e)
                {
                    WriteErrorLog("Out to Section relays" + e.ToString());
                    SerialPortRelayClose();
                }
            }
        }

        private void SerialLineReceivedRelay(string sentence)
        {
            mc.serialRecvRelayStr = sentence;
            int end;

            // Find end of sentence, if not a CR, return
            end = sentence.IndexOf("\r");
            if (end == -1) return;

            if (pbarRelay++ > 99) pbarRelay = 0;

            //the ArdRelay sentence to be parsed
            sentence = sentence.Substring(0, end);
            string[] words = sentence.Split(',');
        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerRelay(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedRelay(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spRelay.IsOpen)
            {
                try
                {
                    //System.Threading.Thread.Sleep(25);
                    string sentence = spRelay.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerRelay(SerialLineReceivedRelay), sentence);                    
                    if (spRelay.BytesToRead > 32) spRelay.DiscardInBuffer();
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception ex)
                {
                    WriteErrorLog("Relay Data Recvd " + ex.ToString());
                }

            }
        }

        //open the Arduino serial port
        public void SerialPortRelayOpen()
        {
            if (!spRelay.IsOpen)
            {
                spRelay.PortName = portNameRelaySection;
                spRelay.BaudRate = baudRateRelaySection;
                spRelay.DataReceived += sp_DataReceivedRelay;
            }

            try { spRelay.Open(); }
            catch (Exception e)
            {
                WriteErrorLog("Opening Relay Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");


                Properties.Settings.Default.setPort_wasRelayConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spRelay.IsOpen)
            {
                spRelay.DiscardOutBuffer();
                spRelay.DiscardInBuffer();

                Properties.Settings.Default.setPort_portNameRelay = portNameRelaySection;
                Properties.Settings.Default.setPort_wasRelayConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        //close the relay port
        public void SerialPortRelayClose()
        {
            if (spRelay.IsOpen)
            {
                spRelay.DataReceived -= sp_DataReceivedRelay;
                try { spRelay.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing Relay Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Properties.Settings.Default.setPort_wasRelayConnected = false;
                Properties.Settings.Default.Save();

                spRelay.Dispose();
            }
        }
        #endregion

        #region GPS SerialPort //--------------------------------------------------------------------------

        //called by the GPS delegate every time a chunk is rec'd
        private void SerialLineReceived(string sentence)
        {

            //spit it out no matter what it says
            pn.rawBuffer += sentence;
            //recvSentenceSettings = sbNMEAFromGPS.ToString();
        }

        private delegate void LineReceivedEventHandler(string sentence);

        public byte[] rawBuffer = new byte[500];
        public byte[] Header = { 0xB5, 0x62 };
        public int BytesRead = 0;
        public int MessageLength = 0;
        int CK_A = 0, CK_B = 0;





    //serial port receive in its own thread
    private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS.IsOpen)
            {
                try
                {
                    if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "UBX")
                    {
                        while (spGPS.BytesToRead > 0)
                        {


                            spGPS.Read(rawBuffer, BytesRead, 1);

                            if (BytesRead < 2)
                            {
                                if (Header[BytesRead] == rawBuffer[BytesRead])
                                {
                                    CK_A = 0;
                                    CK_B = 0;
                                    BytesRead++;
                                }
                                else
                                {
                                    BytesRead = 0;
                                }
                            }
                            else
                            {
                                if (BytesRead == 5)
                                {
                                    MessageLength = BitConverter.ToInt16(rawBuffer, 4);
                                }
                                
                                if (BytesRead < MessageLength + 6)
                                {
                                    CK_A = CK_A + rawBuffer[BytesRead];
                                    CK_A &= 0xFf;
                                    CK_B = CK_B + CK_A;
                                    CK_B &= 0xFf;
                                }
                                BytesRead++;
                                if (BytesRead > (MessageLength + 7))//here ck_B is set
                                {

                                    if (CK_A == rawBuffer[MessageLength + 6] && CK_B == rawBuffer[MessageLength + 7])
                                    {
                                        string sentence = "";



                                        /*
                                        • UBX - NAV - PVT: The carrSoln flag will be set to 1 for RTK float and 2 for RTK fixed.
                                        • UBX - NAV - RELPOSNED: The diffSoln and refPosValid flags will be set.The carrSoln flag will be
                                            set to 1 for RTK float and 2 for RTK fixed.
                                        */



                                        if (0x01 == rawBuffer[2] && 0x3C == rawBuffer[3])
                                        {
                                            byte rr = rawBuffer[66];

                                            sentence = "$UBX-RELPOSNED,0,0,0*";

                                            if ((rr & (1 << 0)) != 0 && (rr & (1 << 2)) != 0)//gnssFixOK && relPosValid
                                            {
                                                double heading = BitConverter.ToInt32(rawBuffer, 30) * 0.00001;
                                                int roll = (int)(Math.Atan2(BitConverter.ToInt32(rawBuffer, 22) + BitConverter.ToInt32(rawBuffer, 40) / 100, 100) * Math.PI / (double)180 * 16);

                                                if ((rr & (1 << 3)) != 0)
                                                {
                                                    sentence = "$UBX-RELPOSNED,4," + heading.ToString("N4") + "," + roll.ToString("N4") + "*";
                                                }
                                                else if ((rr & (1 << 4)) != 0)
                                                {
                                                    sentence = "$UBX-RELPOSNED,3," + heading.ToString("N4") + "," + roll.ToString("N4") + "*";
                                                }
                                                else
                                                {
                                                    sentence = "$UBX-RELPOSNED,2," + heading.ToString("N4") + "," + roll.ToString("N4") + "*";
                                                }
                                            }
                                        }
                                        else if (0x01 == rawBuffer[2] && 0x14 == rawBuffer[3])
                                        {
                                            sentence = "$UBX-HPPOSLLH,0,0,0,0*";
                                            if ((rawBuffer[9] & (1 << 0)) == 0)
                                            {
                                                double longitude = (rawBuffer[30] * 0.01 + BitConverter.ToInt32(rawBuffer, 14)) * 0.0000001;
                                                double latitude = (rawBuffer[31] * 0.01 + BitConverter.ToInt32(rawBuffer, 18)) * 0.0000001;
                                                double altitude = (rawBuffer[32] * 0.01 + BitConverter.ToInt32(rawBuffer, 22)) / 1000.0;
                                                sentence = "$UBX-HPPOSLLH,1," + longitude.ToString("N7") + "," + latitude.ToString("N7") + "," + altitude.ToString("N7") + "*";
                                            }
                                        }
                                        else if (0x01 == rawBuffer[2] && 0x07 == rawBuffer[3])
                                        {
                                            int satellitesTracked = rawBuffer[29];

                                            double longitude = BitConverter.ToInt32(rawBuffer, 30) * 0.0000001;
                                            double latitude = BitConverter.ToInt32(rawBuffer, 34) * 0.0000001;
                                            double altitude = BitConverter.ToInt32(rawBuffer, 38) * 0.001;
                                            double pdop = BitConverter.ToInt16(rawBuffer, 82) / 100.0;


                                            if ((rawBuffer[27] & (1 << 6)) != 0)
                                            {
                                                sentence = "$UBX-PVT,3," + satellitesTracked.ToString() + "," + pdop.ToString("N5") + "," + latitude.ToString("N9") + "*";
                                            }
                                            else if ((rawBuffer[27] & (1 << 7)) != 0)
                                            {
                                                sentence = "$UBX-PVT,4," + satellitesTracked.ToString() + "," + pdop.ToString("N2") + "," + latitude.ToString("N9") + "*";
                                            }
                                            else
                                            {
                                                sentence = "$UBX-PVT,2," + satellitesTracked.ToString() + "," + pdop.ToString("N5") + "," + latitude.ToString("N9") + "*";
                                            }
                                        }



                                        if (sentence != "")
                                        {
                                            int sum = 0, inx;
                                            char[] sentence_chars = sentence.ToCharArray();
                                            char tmp;

                                            for (inx = 1; ; inx++)
                                            {
                                                tmp = sentence_chars[inx];
                                                if (tmp == '*') break;
                                                sum ^= tmp;
                                            }
                                            this.BeginInvoke(new LineReceivedEventHandler(SerialLineReceived), sentence + String.Format("{0:X2}", sum) + "\r\n");
                                        }
                                    }
                                    MessageLength = 0;
                                    BytesRead = 0;

                                }
                            }
                        }
                    }
                    else
                    {
                        //read whatever is in port
                        string sentence = spGPS.ReadExisting();
                        this.BeginInvoke(new LineReceivedEventHandler(SerialLineReceived), sentence);
                    }
                }
                catch (Exception ex)
                {
                    WriteErrorLog("GPS Data Recv" + ex.ToString());

                    //MessageBox.Show(ex.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "ComPort Failure!");
                }
            }
        }
        //serial port receive in its own thread
        private void sp_DataReceived2(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS2.IsOpen)
            {
                try
                {
                    if (spGPS2.BytesToRead > 0)
                    {
                        int intBuffer = spGPS2.BytesToRead;
                        byte[] rawBuffer2 = new byte[intBuffer];
                        spGPS2.Read(rawBuffer2, 0, intBuffer);
                        if (spGPS.IsOpen)
                        {
                            //System.Windows.Forms.MessageBox.Show("fail".ToString());
                            spGPS.Write(rawBuffer2, 0, intBuffer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteErrorLog("GPS Data Recv" + ex.ToString());
                }
            }
        }

        public void SerialPortOpenGPS()
        {
            //close it first
            SerialPortCloseGPS();

            if (spGPS.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();
            }


            if (!spGPS.IsOpen)
            {
                spGPS.PortName = portNameGPS;
                spGPS.BaudRate = baudRateGPS;
                spGPS.DataReceived += sp_DataReceived;
                spGPS.WriteTimeout = 1000;
            }

            try { spGPS.Open(); }
            catch (Exception)
            {
                //MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");
                //WriteErrorLog("Open GPS Port " + e.ToString());

                //update port status labels
                //stripPortGPS.Text = " * * ";
                //stripPortGPS.ForeColor = Color.Red;
                //stripOnlineGPS.Value = 1;

                //SettingsPageOpen(0);
            }

            if (spGPS.IsOpen)
            {
                //btnOpenSerial.Enabled = false;

                //discard any stuff in the buffers
                spGPS.DiscardOutBuffer();
                spGPS.DiscardInBuffer();

                //update port status label
                //stripPortGPS.Text = portNameGPS + " " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;

                Properties.Settings.Default.setPort_portNameGPS = portNameGPS;
                Properties.Settings.Default.setPort_baudRate = baudRateGPS;
                Properties.Settings.Default.Save();
            }
        }
        public void SerialPortOpenGPS2()
        {
            //close it first
            SerialPortCloseGPS2();



            if (!spGPS2.IsOpen)
            {
                spGPS2.PortName = portNameGPS2;
                spGPS2.BaudRate = baudRateGPS2;
                spGPS2.DataReceived += sp_DataReceived2;
                spGPS2.WriteTimeout = 1000;
            }

            try { spGPS2.Open(); }
            catch (Exception)
            {
            }

            if (spGPS2.IsOpen)
            {
                spGPS2.DiscardOutBuffer();
                spGPS2.DiscardInBuffer();

                Properties.Settings.Default.setPort_portNameGPS2 = portNameGPS2;
                Properties.Settings.Default.setPort_baudRate2 = baudRateGPS2;
                Properties.Settings.Default.Save();

            }
        }

        public void SerialPortCloseGPS()
        {
            //if (sp.IsOpen)
            {
                spGPS.DataReceived -= sp_DataReceived;
                try { spGPS.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                //update port status labels
                //stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;
                //stripOnlineGPS.Value = 1;
                spGPS.Dispose();
            }
        }
        public void SerialPortCloseGPS2()
        {
            //if (sp.IsOpen)
            {
                spGPS2.DataReceived -= sp_DataReceived2;
                try { spGPS2.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                //update port status labels
                //stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;
                //stripOnlineGPS.Value = 1;
                spGPS2.Dispose();
            }
        }

        #endregion SerialPortGPS

    }//end class
}//end namespace