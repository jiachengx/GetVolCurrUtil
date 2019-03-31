using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

#region Rebuild from Orig GetVolCurrTool
// Add the source from yocto source and then modify export to excel function  
// Add the voltage and current value and calculate its avg current/ voltage and watt
// Author: Stephen Hsu
// Created by 2013.01.08
#endregion

namespace GetVolCurrUtil
{
    public partial class Form1 : Form
    {
        private string errmsg = "";
        private YVoltage voltageSensor;
        private YModule m = null;
        private YVoltage voltageSensorDC = null;
        private YCurrent currentSensor;
        private YCurrent currentSensorDC = null;
        private double cSum = 0.0;
        private double vSum = 0.0;
        private int timeCount = 0;
        
        private List<string> logVolAl;
        private List<string> logCurrAl;

        public Form1()
        {
            InitializeComponent();
            if (YAPI.RegisterHub("usb", ref this.errmsg) != 0)
            {
                MessageBox.Show("RegisterHub error: " + this.errmsg, "Error");
            }
            else
            {
                this.logCurrAl = new List<string>();
                this.logVolAl = new List<string>();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text.Equals("Start"))
            {
                this.remainTime.Text = "";
                this.logVolAl.Clear();
                this.logCurrAl.Clear();
                this.cSum = 0.0;
                this.vSum = 0.0;
                if (this.intervalTB.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Please insert interval time.", "Warning");
                }
                else
                {
                    if (this.testTimeTB.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Please insert test time.", "Warning");
                    }
                    else
                    {
                        try
                        {
                            this.timer1.Interval = Convert.ToInt32(this.intervalTB.Text.Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error(Interval Time)");
                            return;
                        }
                        try
                        {
                            this.timeCount = Convert.ToInt32(this.testTimeTB.Text.Trim());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error(Test Time)");
                            return;
                        }
                        this.voltageSensor = YVoltage.FirstVoltage();
                        if (this.voltageSensor != null && this.voltageSensor.isOnline())
                        {
                            this.m = this.voltageSensor.get_module();
                            this.voltageSensorDC = YVoltage.FindVoltage(this.m.get_serialNumber() + ".voltage1");
                            this.m = null;
                            this.currentSensor = YCurrent.FirstCurrent();
                            if (this.currentSensor != null && this.currentSensor.isOnline())
                            {
                                this.m = this.currentSensor.get_module();
                                this.currentSensorDC = YCurrent.FindCurrent(this.m.get_serialNumber() + ".current1");
                                this.m = null;
                                //this.startBtn.Enabled = false;
                                this.startBtn.Text = "Stop";
                                this.timer1.Enabled = true;
                                this.timer2.Enabled = true;
                                this.remainTime.Visible = true;
                                //this.stopBtn.Enabled = true;
                                this.intervalTB.Enabled = false;
                                this.testTimeTB.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Current module not connected.", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Voltage module not connected.", "Error");
                        }
                    }
                }
            }
            else 
            {
                this.timer1.Enabled = false;
                this.timer2.Enabled = false;
                this.remainTime.Visible = false;
                this.intervalTB.Enabled = true;
                this.testTimeTB.Enabled = true;
                this.startBtn.Text = "Start";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
           
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.timeCount == 0)
            {
                this.timer1.Enabled = false;
                this.timer2.Enabled = false;
                this.remainTime.Visible = false;
                this.writeCSVFile(this.logVolAl, this.logCurrAl);
            }
            else
            {
               
                this.voltageTB.Text = this.voltageSensorDC.get_currentRawValue().ToString("F2");
                this.logVolAl.Add(this.voltageTB.Text);
                this.currentTB.Text = this.currentSensorDC.get_currentRawValue().ToString();
                this.logCurrAl.Add(this.currentTB.Text);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timeCount--;
            this.remainTime.Text = this.timeCount.ToString();
        }
        private void writeCSVFile(List<string> vol, List<string> curr)
        {
            this.Text = "Writing to Log File ....";
            DateTime now = DateTime.Now;
            string text = "";
            text += now.Year.ToString();
            if (now.Month < 10)
            {
                text += "0";
            }
            text += now.Month.ToString();
            if (now.Day < 10)
            {
                text += "0";
            }
            text = text + now.Day.ToString() + "-";
            if (now.Hour < 10)
            {
                text += "0";
            }
            text += now.Hour.ToString();
            if (now.Minute < 10)
            {
                text += "0";
            }
            text += now.Minute.ToString();
            if (now.Second < 10)
            {
                text += "0";
            }
            text += now.Second.ToString();

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Log");
            using (StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\Log\\" + "Benchmark_" + text + ".csv"))
            {
                
                streamWriter.WriteLine("Voltage,Current");
                for (int i = 0; i < vol.Count; i++)
                {
                    streamWriter.WriteLine(vol[i] + "," + curr[i]);
                    cSum += Convert.ToDouble(curr[i]);
                    vSum += Convert.ToDouble(vol[i]);
                }
                
                // add avg. voltage/ current / watt
                streamWriter.WriteLine(string.Format("\nAvg. Voltage, {0:F2}", vSum / vol.Count));
                streamWriter.WriteLine(string.Format("Avg. Current, {0:F2}", cSum / curr.Count));
                streamWriter.WriteLine(string.Format("Avg. Watt, {0:F2}", vSum * cSum / (vol.Count * curr.Count)));
            }
            this.Text = "Get Data";
            this.startBtn.Text = "Start";
            this.intervalTB.Enabled = true;
            this.testTimeTB.Enabled = true;
        }
    }

}
