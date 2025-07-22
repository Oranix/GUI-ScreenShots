using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using System.IO;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.MenuItems;
using System.IO.Ports;
using System.Drawing;
using System.Linq.Expressions;
using Xceed.Wpf.Toolkit;
using System.Linq;

namespace ScreenShots
{
    [TestClass]
    public class GUIScreenShots : TestBase
    {      
        [TestMethod]
        public void TestMethod1() 
        {       
            var windowBounds = window.Bounds;   ////Catche toggles button position with X and Y
            var mouse = window.Mouse;
            System.Windows.Point newLocation = new System.Windows.Point(windowBounds.X + 500, windowBounds.Y + 500);  //// Cursor set points
            bool communicationConfiguration = true;

            if (communicationConfiguration == true)
            {
                screenshot("Please_wait_while_initializing…_112");
                Thread.Sleep(15000);

                Button WrongloginPasswordDigits = window.Get<Button>(SearchCriteria.ByAutomationId("").AndIndex(1));  //// Index 0 gives the password 111111 
                for (int a = 0; a < 6; a++)
                {
                    WrongloginPasswordDigits.Click();
                    Thread.Sleep(750);
                }
                Button LoginOKButton = window.Get<Button>(SearchCriteria.ByAutomationId("LoginOKButton"));
                LoginOKButton.Click();
                Thread.Sleep(1000);
                screenshot("LoginFail_101");
                Button OKButton = window.Get<Button>(SearchCriteria.ByAutomationId("OKButton"));
                OKButton.Click();

                Login();
                screenshot("MainMenu_Face_2_Body_3");
                ClickOnScreen(500, 300);   ////FACE TREATMENT SELECT

                ////SMALL MAX HP
                Button faceSmallHPBtn = window.Get<Button>(SearchCriteria.ByText("SmallMax"));
                faceSmallHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("SmallMaxFace_4_5_6_7_23_30_36_31_117_129");

                ////THERMAL CAMERA ON/OFF
                ClickOnScreen(250, 1480); ////ThermalCamera on/off
                Thread.Sleep(500);
                try
                {
                    Label thermalCameraSmallCalibrationWarningMsg = window.Get<Label>(SearchCriteria.ByText("Warning"));
                    Thread.Sleep(5000);
                    //screenshot("Camera_identification_process_failed");
                    thermalCameraSmallCalibrationWarningMsg.Click();
                }
                catch
                {
                    Thread.Sleep(5000);
                    //screenshot("ThermalCameraOptions");
                    ClickOnScreen(250, 1480); ////ThermalCamera on/off
                }
                returnFromHPTreatments();

                ////IFINE MAX  HP
                ClickOnScreen(500, 300);   ////FACE TREATMENT SELECT

                Button faceIFineHPBtn = window.Get<Button>(SearchCriteria.ByText("iFineMax"));
                faceIFineHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("iFineMaxFace_8_9_30_117_31_36_23_129");
                returnFromHPTreatments();

                ////MINISHAPER MAX
                ClickOnScreen(500, 300);   ////FACE TREATMENT SELECT

                Button faceMiniShaperHPBtn = window.Get<Button>(SearchCriteria.ByText("MiniShaperMax"));
                faceMiniShaperHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("MiniShaperMaxFace_4_10_6_30_129_31_36_23_117");
                returnFromHPTreatments();

                ////FSR MAX
                ClickOnScreen(500, 300);   ////FACE TREATMENT SELECT

                Button faceFsrBtn = window.Get<Button>(SearchCriteria.ByText("FSRMax"));
                faceFsrBtn.Click();
                Thread.Sleep(2000);
                screenshot("FSRMaxFace_11_8_4_5_25_23_22_128");
                returnFromHPTreatments();

                //INTENSIF MAX
                ClickOnScreen(500, 300);   ////FACE TREATMENT SELECT

                Button faceIntensifBtn = window.Get<Button>(SearchCriteria.ByText("IntensifMax"));
                faceIntensifBtn.Click();
                Thread.Sleep(2000);
                screenshot("IntensifMaxFace_11_8_4_5_25_24_23_22_26_21_129_125");

                ClickOnScreen(50, 200);   ////Forhead


                ClickOnScreen(300, 1250);
                screenshot("ContinousMode_Slow_Moderate_Fast_27_28_29_20");
                returnFromHPTreatments();

                ////////Settings tab
                Button settingsMode = window.Get<Button>(SearchCriteria.ByAutomationId(""));
                settingsMode.Click();
                Thread.Sleep(2000);
                screenshot("SettingsMode_37_38_39_40_41_152");

                ////Adjust_Volume_tab
                ClickOnScreen(300, 500);
                screenshot("Adjust_Volume_38");

                ////////Password_tab
                ClickOnScreen(300, 700);
                screenshot("CurrentNewConfirm_39_46_47_48_49_50");

                ////Password 6 digits must contain 
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 1000, windowBounds.Y + 900);  ////Confirm password button
                Mouse.Instance.Click();
                screenshot("6digitsMustContainMsg_149");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                ////differ_password
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 700);  //// 1 number
                for (int a = 0; a < 6; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 450);  //// new password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 680, windowBounds.Y + 700);  //// 2 number
                for (int a = 0; a < 6; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 570);  //// Confirm password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 770, windowBounds.Y + 700);  //// 3 number
                for (int a = 0; a < 6; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 1000, windowBounds.Y + 900);  ////Confirm password button
                Mouse.Instance.Click();
                screenshot("NewAndConfirmedPasswordDiffrent_145");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                ////Change_password 
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 700);  //// 1 number
                for (int a = 0; a < 6; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 450);  //// New password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 680, windowBounds.Y + 700);  //// 2 number
                for (int a = 0; a < 6; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 570);  //// Confirm password tab
                Mouse.Instance.Click();
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 680, windowBounds.Y + 700);  //// 2 number
                for (int a = 0; a < 7; a++)
                {
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 1000, windowBounds.Y + 900);  ////Confirm password button
                Mouse.Instance.Click();
                screenshot("NewPasswordConfirmation_144");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();
                Thread.Sleep(500);
                screenshot("PasswordChangedSucc_121");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                ////Reset_To_default
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 1000, windowBounds.Y + 800);  ////Reset password button
                Mouse.Instance.Click();
                screenshot("ResetPassword_143");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();
                screenshot("PasswordChangedSucc_121_afterRestore");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                ////serial&calibration_numbers
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                for (int i = 0; i < 3; i++)
                {
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 900);  //// 7 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 900);  //// 8 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }
                screenshot("Calibration_SN_Msg_51_52");

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 1000, windowBounds.Y + 1070);  ////Save SN 
                Mouse.Instance.Click();
                screenshot("InvalidSN_Msg_148");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                for (int i = 0; i < 3; i++)
                {
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 900);  //// 7 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 900);  //// 8 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }

                TextBox serialNumberSet = window.Get<TextBox>(SearchCriteria.ByAutomationId("").AndByClassName("TextBox").AndIndex(3));
                serialNumberSet.SetValue("SM-1234567899");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 980, windowBounds.Y + 1070);  ////Save SN 
                Mouse.Instance.Click();
                screenshot("SerialNumberUpdated_Msg_138");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                for (int i = 0; i < 3; i++)
                {
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 900);  //// 7 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 900);  //// 8 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }
                TextBox caliNumberSet = window.Get<TextBox>(SearchCriteria.ByAutomationId("").AndByClassName("TextBox").AndIndex(4));
                caliNumberSet.SetValue("-3.58");
                Thread.Sleep(500);
                ClickOnScreen(980, 1200);   ////Save Cali. number 
                screenshot("Calibration_value_saved_Msg_122");
                Thread.Sleep(500);
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                System.Windows.MessageBoxResult messageBoxResultFlir = MessageBox.Show("Please Dissconnect FLIR camera");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 800, windowBounds.Y + 350);  //// Current password tab
                Mouse.Instance.Click();
                for (int i = 0; i < 3; i++)
                {
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 600, windowBounds.Y + 900);  //// 7 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                    Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 900);  //// 8 number
                    Mouse.Instance.Click();
                    Thread.Sleep(500);
                }
                ClickOnScreen(1000, 1200);   ////Save SN 
                screenshot("PleaseConnectFLIR_Msg_140");
                Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 700, windowBounds.Y + 500);  //// Ok Button
                Mouse.Instance.Click();

                ////Upload_Logs
                ClickOnScreen(300, 890);   ////Upload Logs
                Thread.Sleep(500);
                screenshot("Upload_Logs_No_USB_111");
                System.Windows.MessageBoxResult messageBoxResult = MessageBox.Show("Please connect USB");
                ClickOnScreen(300, 890);   ////Upload Logs
                Thread.Sleep(6000);
                screenshot("Upload_Logs_Done_40_110");

                ////Media
                ClickOnScreen(300, 1000);   ////Media
                Thread.Sleep(500);
                screenshot("Media_41_54_127");
                Thread.Sleep(1000);
                //////ClickOnScreen(400, 230);   ////video1
                //////Thread.Sleep(2000);
                //////screenshot("Media_41_141");
                //////ClickOnScreen(550, 230);   ////off
                //////Thread.Sleep(2000);

                ////backToSettings
                ClickOnScreen(80, 100);

                ////MainMenu
                ClickOnScreen(80, 100);
                Thread.Sleep(2000);

                Login();

                //BODY HANDPIECES
                //MINISHAPER MAX
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT

                Button bodyMiniShaperHPBtn = window.Get<Button>(SearchCriteria.ByText("MiniShaperMax").AndIndex(0));
                bodyMiniShaperHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("MiniShaperMaxBody_7_12_13_23_30_36_31_117_128_129");
                returnFromHPTreatments();

                ////SHAPER MAX
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT

                Button bodyShaperHPBtn = window.Get<Button>(SearchCriteria.ByText("ShaperMax"));
                bodyShaperHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("ShaperMaxBody_14_12_15_16_17_13_18_23_36_30_117_128_129");
                returnFromHPTreatments();

                ////CONTOUR MAX
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT

                Button bodyContourHPBtn = window.Get<Button>(SearchCriteria.ByText("ContourMax"));
                bodyContourHPBtn.Click();
                Thread.Sleep(2000);
                screenshot("ContourMaxBody_14_15_18_16_17_30_31_23_36_128_129_117");
                returnFromHPTreatments();

                ////FSR MAX 
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT

                //Mouse.Instance.Location = newLocation = new System.Windows.Point(windowBounds.X + 400, windowBounds.Y + 1300);  ////FSRMAX
                //Mouse.Instance.Click();
                ClickOnScreen(400, 1300);   ////FSRMAX
                Thread.Sleep(1000);
                screenshot("FSRMaxBody_19_7_16_15_12_25_23_22_128_129");
                returnFromHPTreatments();

                ////INTENSIF MAX 
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT

                ClickOnScreen(750, 1300);  ////IntensifMAX
                Thread.Sleep(2000);
                screenshot("IntensifMAXBody_Msgs_11_8_4_5_25_26_22_21_23_24_125_128_129");
                returnFromHPTreatments();

                //ConnectHP / Dissconect HP / No Motion / Bad Contact 
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT
                System.Windows.MessageBoxResult messageBoxResultDissconectHP = MessageBox.Show("Please connect ShaperMAX then press OK to continue..");
                Button bodyShaperMAXforDisconnecting = window.Get<Button>(SearchCriteria.ByText("ShaperMax"));
                bodyShaperMAXforDisconnecting.Click();
                Thread.Sleep(2000);
                ClickOnScreen(50, 200);  ////Flanks
                ClickOnScreen(790, 1200);  ////START
                Thread.Sleep(500);
                System.Windows.MessageBoxResult messageBoxResultBadContact = MessageBox.Show("Emit Bad contact then press OK to continue..");
                screenshot("Bad_Contact_Msg_56");
                System.Windows.MessageBoxResult messageBoxResultMotion = MessageBox.Show("Emit motion then press OK to continue..");
                screenshot("Motion_Msg_116");
                System.Windows.MessageBoxResult messageBoxResultNoMotion = MessageBox.Show("Emit No motion then press OK to continue..");
                screenshot("No_Notion_Msg_57");
                System.Windows.MessageBoxResult messageBoxResultReconnectHP = MessageBox.Show("Please Disconnect ShaperMAX then press OK to continue..");
                screenshot("Handpiece was disconnected. Press OK to continue_Msg_98");
                Button dissconectHPMsg = window.Get<Button>(SearchCriteria.ByText("Button").AndAutomationId(""));
                Thread.Sleep(1000);
                dissconectHPMsg.Click();

                //TIP'S Statuses
                ClickOnScreen(500, 500);  ////BODY TREATMENT SELECT
                System.Windows.MessageBoxResult messageBoxResultReconnectIntensifHP = MessageBox.Show("Please connect Intensif MAX to the RIGHT system connector then press OK to continue..");
                ClickOnScreen(750, 1300);    ////IntensifMAX
                Thread.Sleep(2000);
                screenshot("Connect_the_handpiece_to_the_left_side!_Msg_61");
                ClickOnScreen(500, 920);    ////Right side error OK button
                ClickOnScreen(500, 500);    ////BODY
                Thread.Sleep(1000);
                System.Windows.MessageBoxResult messageBoxResultReconnectIntensiLEFTfHP = MessageBox.Show("Please connect Intensif MAX to the LEFT system connector then press OK to continue..");
                ClickOnScreen(750, 1300);    ////IntensifMAX
                Thread.Sleep(2000);
                ClickOnScreen(50, 200);    ////Decolltage
                Thread.Sleep(500);
                ClickOnScreen(790, 1200);    ////START
                Thread.Sleep(2500);
                screenshot("Background_Tip_Status_No_Tip_153");
                System.Windows.MessageBoxResult messageBoxResultReconnectIntensifNoTip = MessageBox.Show("Emit pulse without any TIP then press OK to continue..");
                screenshot("No_Tip_Status_Msg_109");
                Thread.Sleep(500);
                ClickOnScreen(500, 950);    //// OK button
                Thread.Sleep(500);
                System.Windows.MessageBoxResult messageBoxResultTipExpiredStatus = MessageBox.Show("Emit pulses until tip is EXPIRED and press OK");
                screenshot("No_Tip_Status_Expired_154");
                Thread.Sleep(2500);
                System.Windows.MessageBoxResult messageBoxResultReconnectIntensifExpiredTip = MessageBox.Show("connect expired TIP then press OK to continue..");
                screenshot("Expired_Tip_Status_Msg_64");
                Thread.Sleep(1500);
                ClickOnScreen(500, 950);    //// OK button
                Thread.Sleep(500);
                System.Windows.MessageBoxResult messageBoxResultReconnectIntensifUnburnedTip = MessageBox.Show("Connect UNBURNED/UNRECOGNIZED TIP then press OK to continue..");
                ClickOnScreen(790, 1200);    ////START
                Thread.Sleep(6000);
                screenshot("Unburned_Tip_Status_Msg_139");
                Thread.Sleep(500);
                ClickOnScreen(500, 950);    ////OK button
                Thread.Sleep(500);
                returnFromHPTreatments();

                ////FSR
                ClickOnScreen(500, 500);////BODY
                Thread.Sleep(1000);
                System.Windows.MessageBoxResult messageBoxResultDissconectIntensif = MessageBox.Show("Dissconect the Intensif MAX then press OK to continue..");
                Button dissconectMsg = window.Get<Button>(SearchCriteria.ByText("Button").AndAutomationId(""));
                Thread.Sleep(1000);
                dissconectMsg.Click();
                System.Windows.MessageBoxResult messageBoxResultConnectFSR = MessageBox.Show("Connect FSR MAX to the LEFT side then press OK to continue..");
                ClickOnScreen(400, 1300);   ////FSRMAX
                Thread.Sleep(1000);
                ClickOnScreen(50, 200);   /////Hands
                Thread.Sleep(500);
                ClickOnScreen(790, 1200);   ////START
                Thread.Sleep(2500);
                screenshot("FSR_NO_TIP_Msg_100");
                ClickOnScreen(500, 950);    //// OK button
                Thread.Sleep(500);
                System.Windows.MessageBoxResult messageBoxResultFSRexpiredtip = MessageBox.Show("Connect expired tip then press OK to continue..");
                screenshot("FSR_EXPIRED_TIP");
                ClickOnScreen(500, 950);    //// OK button
                Thread.Sleep(500);
                System.Windows.MessageBoxResult messageBoxResultFSR30Pulses = MessageBox.Show("Emit 30 pulses, you have 1 minute, when message is pop stop triggering..");
                Thread.Sleep(90000);
                screenshot("Wipe_FSR_Tip_Msg_59");
                ClickOnScreen(500, 950);    //// OK button
                Thread.Sleep(500);
            }
            else
            {
                screenshot("Communication_Fail_55");
                ClickOnScreen(500, 920);   ////Lost comminication OK button

            }
        }
    }
}
