using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NissanUDS
{


    public partial class Form1 : Form
    {
        int POSTDATE = 1;
        String path = "C:/VehicleLogs/";
        public Form1()
        {
            InitializeComponent();
            path = path + POSTDATE;
            String[] CurrentPath = path.Split('/');


            try
            {

                if (Directory.Exists("C:/VehicleLogs") == false)
                {
                    DirectoryInfo makeit = Directory.CreateDirectory("C:/VehicleLogs");
                }


                for (int i = 0; i < 100; i++)
                {
                    // Determine whether the directory exists.
                    if (Directory.Exists(path))
                    {
                        // MessageBox.Show("Exists!");

                        POSTDATE = POSTDATE + Convert.ToInt32(CurrentPath[2]);
                        path = "C:/VehicleLogs/" + POSTDATE;
                    }

                    else if (Directory.Exists(path) == false)
                    {
                        path = "C:/VehicleLogs/" + POSTDATE;
                        DirectoryInfo direct = Directory.CreateDirectory(path);
                        return;
                    }
                }



                // Try to create the directory.
                // DirectoryInfo di = Directory.CreateDirectory(path);
                // MessageBox.Show("The directory was created successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show("The process failed: {0}");
            }
            finally { }

        }

        string ReceivedData;
        private void SP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String[] CurrentPath = path.Split('/');
            System.IO.StreamWriter SaveRX = new System.IO.StreamWriter("C:/VehicleLogs/" + CurrentPath[2] + "/__" + "RXLog" + ".txt", true);
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                ReceivedData = SP.ReadTo(">");
                SaveRX.WriteLine(ReceivedData);
                SaveRX.WriteLine(Environment.NewLine);
                SaveRX.Close();
                //ReceivedData = SP.ReadExisting();
                //  MessageBox.Show(ReceivedData);
                Txt_Data.Text = Txt_Data.Text + Environment.NewLine + ReceivedData;

                if (ReceivedData.Contains("7F 30"))
                {
                    MessageBox.Show("This vehicle does not support this function!");
                }

                //  Get supported outputs 00 to 20
                if (ReceivedData.Contains("70 00"))
                {
                    String[] SupportedOutputsInc = ReceivedData.Split(' ');
                    String SupportedOutputsOut = "";
                    for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
                    {
                        SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];

                    }
                    Txt_Data.Text = SupportedOutputsOut;
                    ConvertandList(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
                }

                // Get supported outputs 20 to 40
                if (ReceivedData.Contains("70 20"))
                {
                    String[] SupportedOutputsInc = ReceivedData.Split(' ');
                    String SupportedOutputsOut = "";
                    for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
                    {
                        SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];

                    }

                    ConvertandList20to40(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
                }

                // Get supported outputs 40 to 60
                if (ReceivedData.Contains("70 60"))
                {
                    String[] SupportedOutputsInc = ReceivedData.Split(' ');
                    String SupportedOutputsOut = "";
                    for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
                    {
                        SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];

                    }

                    ConvertandList40to60(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
                }

                // Get supported outputs 60 to 80
                if (ReceivedData.Contains("70 80"))
                {
                    String[] SupportedOutputsInc = ReceivedData.Split(' ');
                    String SupportedOutputsOut = "";
                    for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
                    {
                        SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];

                    }

                    ConvertandList60to80(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
                }

                // Get supported outputs 80 to 100
                if (ReceivedData.Contains("70 80"))
                {
                    String[] SupportedOutputsInc = ReceivedData.Split(' ');
                    String SupportedOutputsOut = "";
                    for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
                    {
                        SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];

                    }

                    ConvertandList80to100(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }


        private async void Btn_Connect_To_Vehicle_Click(object sender, EventArgs e)
        {
            SP.Open();
            SP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SP_DataReceived);
            SP.Write("ATZ");
            Lbl_Status.Text = "...Resetting VCI...";
            await Task.Delay(2000);
            SP.Write("ATH1");
            Lbl_Status.Text = "...Setting VCI Parameters...";
            await Task.Delay(500);
            SP.Write("ATSP 0");
            // await Task.Delay(500);
            Lbl_Status.Text = "...Connected To Vehicle...";
        }

        private void Btn_Send_Program_Number_Click(object sender, EventArgs e)
        {
            ConvertandList20to40("20081401", Lst_PIDS_Supported, Lbl_Status);
            //String[] SupportedOutputsInc = new string[] { "9D", "A2", "00", "72" };
            //String SupportedOutputsOut = "";
            //for (int i = 0; i < SupportedOutputsInc.Length; i++)
            // {
            //     SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];
            // }

            // ConvertandList(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);

            // MessageBox.Show(SupportedOutputsOut);

            String[] SupportedOutputsInc = new string[] {"30","2070","20","20","08","14","01" };
            String SupportedOutputsOut = "";

            for (int i = SupportedOutputsInc.Length - 4; i < SupportedOutputsInc.Length; i++)
            {
                SupportedOutputsOut = SupportedOutputsOut + SupportedOutputsInc[i];
                
            }
            MessageBox.Show(SupportedOutputsOut);
            ConvertandList20to40(SupportedOutputsOut, Lst_PIDS_Supported, Lbl_Status);
        }

        public void ConvertandList(string Results, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {
            // Converts our hex to binary and calls another function as it goes through the bits to see if each bit is supported

            ulong CurrentBit;
            ulong ResultsasULong = Convert.ToUInt32(Results, 16);
            int iPidNumber;
            Lbl_Status.Text = ResultsasULong.ToString();




            for (int i = 0; i < 32; i++)
            {
                CurrentBit = 1;
                if ((ResultsasULong & (CurrentBit << (31 - i))) != 0)
                {
                    iPidNumber = i + 1;
                    ListThemPIDs(i, CurrentBit.ToString(), Lst_PIDS_Supported, Lbl_Status);

                }
            }
        }

        public void ConvertandList20to40(string Results, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {
            // Converts our hex to binary and calls another function as it goes through the bits to see if each bit is supported

            ulong CurrentBit;
            ulong ResultsasULong = Convert.ToUInt32(Results, 16);
            int iPidNumber;
           // Lbl_Status.Text = ResultsasULong.ToString();




            for (int i = 0; i < 32; i++)
            {
                CurrentBit = 1;
                if ((ResultsasULong & (CurrentBit << (31 - i))) != 0)
                {
                    iPidNumber = i + 1;
                    ListThemPIDs20to40(i, CurrentBit.ToString(), Lst_PIDS_Supported, Lbl_Status);

                }
            }
        }
        

                  public void ConvertandList40to60(string Results, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {
            // Converts our hex to binary and calls another function as it goes through the bits to see if each bit is supported

            ulong CurrentBit;
            ulong ResultsasULong = Convert.ToUInt32(Results, 16);
            int iPidNumber;
            Lbl_Status.Text = ResultsasULong.ToString();




            for (int i = 0; i < 32; i++)
            {
                CurrentBit = 1;
                if ((ResultsasULong & (CurrentBit << (31 - i))) != 0)
                {
                    iPidNumber = i + 1;
                    ListThemPIDs40to60(i, CurrentBit.ToString(), Lst_PIDS_Supported, Lbl_Status);

                }
            }
        }

                  public void ConvertandList60to80(string Results, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {
            // Converts our hex to binary and calls another function as it goes through the bits to see if each bit is supported

            ulong CurrentBit;
            ulong ResultsasULong = Convert.ToUInt32(Results, 16);
            int iPidNumber;
            Lbl_Status.Text = ResultsasULong.ToString();




            for (int i = 0; i < 32; i++)
            {
                CurrentBit = 1;
                if ((ResultsasULong & (CurrentBit << (31 - i))) != 0)
                {
                    iPidNumber = i + 1;
                    ListThemPIDs60to80(i, CurrentBit.ToString(), Lst_PIDS_Supported, Lbl_Status);

                }
            }

        }

                  public void ConvertandList80to100(string Results, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {
            // Converts our hex to binary and calls another function as it goes through the bits to see if each bit is supported

            ulong CurrentBit;
            ulong ResultsasULong = Convert.ToUInt32(Results, 16);
            int iPidNumber;
            Lbl_Status.Text = ResultsasULong.ToString();




            for (int i = 0; i < 32; i++)
            {
                CurrentBit = 1;
                if ((ResultsasULong & (CurrentBit << (31 - i))) != 0)
                {
                    iPidNumber = i + 1;
                    ListThemPIDs80to100(i, CurrentBit.ToString(), Lst_PIDS_Supported, Lbl_Status);

                }
            }

        }
    


        public void ListThemPIDs(int CurrentIndex, string Supported, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {

            switch (CurrentIndex)
            {
                // Here, we are looking at each bit seperately. If the bit is a "1" then the PID is supported. If it is a "0", then it is not supported.

                case 0:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $01");
                    }
                    break;

                case 1:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $02");
                    }
                    break;

                case 2:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $03");
                    }
                    break;


                case 3:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $04");
                    }
                    break;

                case 4:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $05");
                    }
                    break;

                case 5:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $06");
                    }
                    break;


                case 6:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $07");
                    }
                    break;

                case 7:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $08");
                    }
                    break;

                case 8:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $09");
                    }
                    break;


                case 9:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0A");
                    }
                    break;

                case 10:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0B");
                    }
                    break;

                case 11:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0C");
                    }
                    break;


                case 12:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0D");
                    }
                    break;

                case 13:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0E");
                    }
                    break;

                case 14:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $0F");
                    }
                    break;


                case 15:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $10");
                    }
                    break;

                case 16:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $11");
                    }
                    break;

                case 17:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $12");
                    }
                    break;


                case 18:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $13");
                    }
                    break;

                case 19:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $14");
                    }
                    break;

                case 20:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $15");
                    }
                    break;


                case 21:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $16");
                    }
                    break;

                case 22:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $17");
                    }
                    break;

                case 23:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $18");
                    }
                    break;


                case 24:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $19");
                    }
                    break;

                case 25:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1A");
                    }
                    break;

                case 26:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1B");
                    }
                    break;


                case 27:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1C");
                    }
                    break;

                case 28:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1D");
                    }
                    break;

                case 29:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1E");
                    }
                    break;


                case 30:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $1F");
                    }
                    break;

                case 31:
                    if (Supported.Contains("1"))
                    {
                        try
                        {
                              SP.Write("30 20\r");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("port is closed"))
                            {
                                Lbl_Status.Text = "You must connect to the vehicle first!!";
                            }
                            else
                            {
                                Lbl_Status.Text = "Error: " + ex.ToString();
                            }
                        }
                    }
                    break;


            }

        }

        public void ListThemPIDs20to40(int CurrentIndex, string Supported, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {

            switch (CurrentIndex)
            {
                // Here, we are looking at each bit seperately. If the bit is a "1" then the PID is supported. If it is a "0", then it is not supported.

                case 0:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $11");
                    }
                    break;

                case 1:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $12");
                    }
                    break;

                case 2:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $23");
                    }
                    break;


                case 3:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $24");
                    }
                    break;

                case 4:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $25");
                    }
                    break;

                case 5:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $26");
                    }
                    break;


                case 6:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $27");
                    }
                    break;

                case 7:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $28");
                    }
                    break;

                case 8:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $29");
                    }
                    break;


                case 9:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2A");
                    }
                    break;

                case 10:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2B");
                    }
                    break;

                case 11:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2C");
                    }
                    break;


                case 12:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2D");
                    }
                    break;

                case 13:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2E");
                    }
                    break;

                case 14:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $2F");
                    }
                    break;


                case 15:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $30");
                    }
                    break;

                case 16:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $31");
                    }
                    break;

                case 17:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $32");
                    }
                    break;


                case 18:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $33");
                    }
                    break;

                case 19:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $34");
                    }
                    break;

                case 20:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $35");
                    }
                    break;


                case 21:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $36");
                    }
                    break;

                case 22:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $37");
                    }
                    break;

                case 23:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $38");
                    }
                    break;


                case 24:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $39");
                    }
                    break;

                case 25:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3A");
                    }
                    break;

                case 26:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3B");
                    }
                    break;


                case 27:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3C");
                    }
                    break;

                case 28:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3D");
                    }
                    break;

                case 29:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3E");
                    }
                    break;


                case 30:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $3F");
                    }
                    break;

                case 31:
                    if (Supported.Contains("1"))
                    {
                        try
                        {
                            SP.Write("30 40\r");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("port is closed"))
                            {
                                Lbl_Status.Text = "You must connect to the vehicle first!!";
                            }
                            else
                            {
                                Lbl_Status.Text = "Error: " + ex.ToString();
                            }
                        }
                    }
                    break;


            }

        }

        public void ListThemPIDs40to60(int CurrentIndex, string Supported, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {

            switch (CurrentIndex)
            {
                // Here, we are looking at each bit seperately. If the bit is a "1" then the PID is supported. If it is a "0", then it is not supported.

                case 0:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $41");
                    }
                    break;

                case 1:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $42");
                    }
                    break;

                case 2:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $43");
                    }
                    break;


                case 3:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $44");
                    }
                    break;

                case 4:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $45");
                    }
                    break;

                case 5:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $46");
                    }
                    break;


                case 6:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $47");
                    }
                    break;

                case 7:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $48");
                    }
                    break;

                case 8:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $49");
                    }
                    break;


                case 9:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4A");
                    }
                    break;

                case 10:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4B");
                    }
                    break;

                case 11:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4C");
                    }
                    break;


                case 12:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4D");
                    }
                    break;

                case 13:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4E");
                    }
                    break;

                case 14:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $4F");
                    }
                    break;


                case 15:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $50");
                    }
                    break;

                case 16:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $51");
                    }
                    break;

                case 17:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $52");
                    }
                    break;


                case 18:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $53");
                    }
                    break;

                case 19:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $54");
                    }
                    break;

                case 20:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $55");
                    }
                    break;


                case 21:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $56");
                    }
                    break;

                case 22:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $57");
                    }
                    break;

                case 23:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $58");
                    }
                    break;


                case 24:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $59");
                    }
                    break;

                case 25:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5A");
                    }
                    break;

                case 26:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5B");
                    }
                    break;


                case 27:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5C");
                    }
                    break;

                case 28:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5D");
                    }
                    break;

                case 29:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5E");
                    }
                    break;


                case 30:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $5F");
                    }
                    break;

                case 31:
                    if (Supported.Contains("1"))
                    {
                        try
                        {
                            SP.Write("30 60\r");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("port is closed"))
                            {
                                Lbl_Status.Text = "You must connect to the vehicle first!!";
                            }
                            else
                            {
                                Lbl_Status.Text = "Error: " + ex.ToString();
                            }
                        }
                    }
                    break;


            }

        }

        public void ListThemPIDs60to80(int CurrentIndex, string Supported, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {

            switch (CurrentIndex)
            {
                // Here, we are looking at each bit seperately. If the bit is a "1" then the PID is supported. If it is a "0", then it is not supported.

                case 0:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $61");
                    }
                    break;

                case 1:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $62");
                    }
                    break;

                case 2:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $63");
                    }
                    break;


                case 3:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $64");
                    }
                    break;

                case 4:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $65");
                    }
                    break;

                case 5:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $66");
                    }
                    break;


                case 6:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $67");
                    }
                    break;

                case 7:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $68");
                    }
                    break;

                case 8:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $69");
                    }
                    break;


                case 9:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6A");
                    }
                    break;

                case 10:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6B");
                    }
                    break;

                case 11:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6C");
                    }
                    break;


                case 12:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6D");
                    }
                    break;

                case 13:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6E");
                    }
                    break;

                case 14:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $6F");
                    }
                    break;


                case 15:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $70");
                    }
                    break;

                case 16:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $71");
                    }
                    break;

                case 17:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $72");
                    }
                    break;


                case 18:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $73");
                    }
                    break;

                case 19:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $74");
                    }
                    break;

                case 20:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $75");
                    }
                    break;


                case 21:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $76");
                    }
                    break;

                case 22:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $77");
                    }
                    break;

                case 23:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $78");
                    }
                    break;


                case 24:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $79");
                    }
                    break;

                case 25:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7A");
                    }
                    break;

                case 26:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7B");
                    }
                    break;


                case 27:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7C");
                    }
                    break;

                case 28:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7D");
                    }
                    break;

                case 29:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7E");
                    }
                    break;


                case 30:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $7F");
                    }
                    break;

                case 31:
                    if (Supported.Contains("1"))
                    {
                        try
                        {
                            SP.Write("30 80\r");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("port is closed"))
                            {
                                Lbl_Status.Text = "You must connect to the vehicle first!!";
                            }
                            else
                            {
                                Lbl_Status.Text = "Error: " + ex.ToString();
                            }
                        }
                    }
                    break;


            }

        }

        public void ListThemPIDs80to100(int CurrentIndex, string Supported, ListBox Lst_PIDS_Supported, Label Lbl_Status)
        {

            switch (CurrentIndex)
            {
                // Here, we are looking at each bit seperately. If the bit is a "1" then the PID is supported. If it is a "0", then it is not supported.

                case 0:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $81");
                    }
                    break;

                case 1:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $82");
                    }
                    break;

                case 2:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $83");
                    }
                    break;


                case 3:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $84");
                    }
                    break;

                case 4:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $85");
                    }
                    break;

                case 5:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $86");
                    }
                    break;


                case 6:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $87");
                    }
                    break;

                case 7:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $88");
                    }
                    break;

                case 8:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $89");
                    }
                    break;


                case 9:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8A");
                    }
                    break;

                case 10:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8B");
                    }
                    break;

                case 11:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8C");
                    }
                    break;


                case 12:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8D");
                    }
                    break;

                case 13:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8E");
                    }
                    break;

                case 14:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $8F");
                    }
                    break;


                case 15:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $90");
                    }
                    break;

                case 16:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $91");
                    }
                    break;

                case 17:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $92");
                    }
                    break;


                case 18:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $93");
                    }
                    break;

                case 19:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $94");
                    }
                    break;

                case 20:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $95");
                    }
                    break;


                case 21:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $96");
                    }
                    break;

                case 22:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $97");
                    }
                    break;

                case 23:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $98");
                    }
                    break;


                case 24:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $99");
                    }
                    break;

                case 25:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9A");
                    }
                    break;

                case 26:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9B");
                    }
                    break;


                case 27:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9C");
                    }
                    break;

                case 28:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9D");
                    }
                    break;

                case 29:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9E");
                    }
                    break;


                case 30:
                    if (Supported.Contains("1"))
                    {
                        Lst_PIDS_Supported.Items.Add("PID $9F");
                    }
                    break;

                case 31:
                    if (Supported.Contains("1"))
                    {
                        try
                        {
                            MessageBox.Show("More Supported? Change code to find out!");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("port is closed"))
                            {
                                Lbl_Status.Text = "You must connect to the vehicle first!!";
                            }
                            else
                            {
                                Lbl_Status.Text = "Error: " + ex.ToString();
                            }
                        }
                    }
                    break;


            }

        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Lst_PIDS_Supported.Items.Clear();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Vehicle You're Plugged Into and module you're talking to", "Enter Vehicle", "Ex. 1999 Lexus ES300", -1, -1);
            String[] CurrentPath = path.Split('/');
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("C:/VehicleLogs/" + CurrentPath[2] + "/__" + input + ".txt",true);
            foreach (var item in Lst_PIDS_Supported.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Programs saved!");
        }

        private void Btn_SetHeader_Click(object sender, EventArgs e)
        {
            Txt_Data.Text = "";
            SP.Write("ATSH " + Txt_Module_Id.Text + "\r");
        }

        private void Btn_GetOutputControls_Click(object sender, EventArgs e)
        {
            Txt_Data.Text = "";
            SP.Write(" 30 00\r");
        }
    }

   
    
}

