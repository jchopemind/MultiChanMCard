using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiChanMCard
{
    /// <summary>
    /// ParametersConfig.xaml 的交互逻辑
    /// </summary>
    public partial class ParametersConfig : Page
    {
        public ParametersConfig()
        {
            InitializeComponent();
        }

        private void select_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;

            if(timeset_grid == null || windowLength_grid == null || filter_grid == null || measureRate_grid == null || zengYi_grid == null || channels_grid == null)
            {
                return;
            }

            switch (listView.SelectedIndex)
            {
                case 0:
                    windowLength_grid.Visibility = Visibility.Visible;
                    measureRate_grid.Visibility = Visibility.Hidden;
                    zengYi_grid.Visibility = Visibility.Hidden;
                    filter_grid.Visibility = Visibility.Hidden;
                    channels_grid.Visibility = Visibility.Hidden;
                    timeset_grid.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    windowLength_grid.Visibility = Visibility.Hidden;
                    measureRate_grid.Visibility = Visibility.Visible;
                    zengYi_grid.Visibility = Visibility.Hidden;
                    filter_grid.Visibility = Visibility.Hidden;
                    channels_grid.Visibility = Visibility.Hidden;
                    timeset_grid.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    windowLength_grid.Visibility = Visibility.Hidden;
                    measureRate_grid.Visibility = Visibility.Hidden;
                    zengYi_grid.Visibility = Visibility.Visible;
                    filter_grid.Visibility = Visibility.Hidden;
                    channels_grid.Visibility = Visibility.Hidden;
                    timeset_grid.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    windowLength_grid.Visibility = Visibility.Hidden;
                    measureRate_grid.Visibility = Visibility.Hidden;
                    zengYi_grid.Visibility = Visibility.Hidden;
                    filter_grid.Visibility = Visibility.Visible;
                    channels_grid.Visibility = Visibility.Hidden;
                    timeset_grid.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    windowLength_grid.Visibility = Visibility.Hidden;
                    measureRate_grid.Visibility = Visibility.Hidden;
                    zengYi_grid.Visibility = Visibility.Hidden;
                    filter_grid.Visibility = Visibility.Hidden;
                    channels_grid.Visibility = Visibility.Visible;
                    timeset_grid.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    windowLength_grid.Visibility = Visibility.Hidden;
                    measureRate_grid.Visibility = Visibility.Hidden;
                    zengYi_grid.Visibility = Visibility.Hidden;
                    filter_grid.Visibility = Visibility.Hidden;
                    channels_grid.Visibility = Visibility.Hidden;
                    timeset_grid.Visibility = Visibility.Visible;
                    break;
            }
        }


        #region Window Length Set
        private void winLength_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox winLen_cb = sender as ComboBox;

            ProtocolCommands.setWindowLength(Convert.ToByte(winLen_cb.SelectedIndex + 1));
        }
        #endregion

        #region Sample Rate Setup
        private void freqSelect_rd_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdBtn = sender as RadioButton;
            if (highFreq_cb == null || midFreq_cb == null || lowFreq_cb == null)
            {
                return;
            }

            if (rdBtn.Content.ToString() == "高频")
            {
                highFreq_cb.Visibility = Visibility.Visible;
                midFreq_cb.Visibility = Visibility.Hidden;
                lowFreq_cb.Visibility = Visibility.Hidden;
                highFreq_cb.SelectedIndex = 0;
                ProtocolCommands.setSampleRate(0x01, 1);
            }
            else if (rdBtn.Content.ToString() == "中频")
            {
                highFreq_cb.Visibility = Visibility.Hidden;
                midFreq_cb.Visibility = Visibility.Visible;
                lowFreq_cb.Visibility = Visibility.Hidden;
                midFreq_cb.SelectedIndex = 0;
                ProtocolCommands.setSampleRate(0x02, 1);
            }
            else if (rdBtn.Content.ToString() == "低频")
            {
                highFreq_cb.Visibility = Visibility.Hidden;
                midFreq_cb.Visibility = Visibility.Hidden;
                lowFreq_cb.Visibility = Visibility.Visible;
                lowFreq_cb.SelectedIndex = 0;
                ProtocolCommands.setSampleRate(0x03, 1);

            }
        }

        private void sampleRate_high_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setSampleRate(0x01, Convert.ToByte( cb.SelectedIndex + 1));
        }

        private void sampleRate_mid_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setSampleRate(0x02, Convert.ToByte(cb.SelectedIndex + 1));
        }

        private void sampleRate_low_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setSampleRate(0x03, Convert.ToByte(cb.SelectedIndex + 1));
        }
        #endregion

        #region Gain setup
        private void zengYiSelect_rd_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdBtn = sender as RadioButton;
            if (highZengyi_cb == null || midZengyi_cb == null || lowZengyi_cb == null)
            {
                return;
            }

            if (rdBtn.Content.ToString() == "高频")
            {
                highZengyi_cb.Visibility = Visibility.Visible;
                midZengyi_cb.Visibility = Visibility.Hidden;
                lowZengyi_cb.Visibility = Visibility.Hidden;
                highZengyi_cb.SelectedIndex = 0;
                ProtocolCommands.setGain(0x01, 1);
            }
            else if (rdBtn.Content.ToString() == "中频")
            {
                highZengyi_cb.Visibility = Visibility.Hidden;
                midZengyi_cb.Visibility = Visibility.Visible;
                lowZengyi_cb.Visibility = Visibility.Hidden;
                midZengyi_cb.SelectedIndex = 0;
                ProtocolCommands.setGain(0x01, 1);
            }
            else if (rdBtn.Content.ToString() == "低频")
            {
                highZengyi_cb.Visibility = Visibility.Hidden;
                midZengyi_cb.Visibility = Visibility.Hidden;
                lowZengyi_cb.Visibility = Visibility.Visible;
                lowZengyi_cb.SelectedIndex = 0;
                ProtocolCommands.setGain(0x01, 1);
            }
        }
        private void gain_low_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setGain(0x03, Convert.ToByte(cb.SelectedIndex + 1));

        }
        private void gain_mid_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setGain(0x02, Convert.ToByte(cb.SelectedIndex + 1));

        }
        private void gain_high_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setGain(0x01, Convert.ToByte(cb.SelectedIndex + 1));

        }
        #endregion

        #region Filter Setup
        private void filterSelect_rd_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rdBtn = sender as RadioButton;
            if (highFilter_cb == null || midFilter_cb == null || lowFilter_cb == null)
            {
                return;
            }

            if (rdBtn.Content.ToString() == "高频")
            {
                highFilter_cb.Visibility = Visibility.Visible;
                midFilter_cb.Visibility = Visibility.Hidden;
                lowFilter_cb.Visibility = Visibility.Hidden;
                highFilter_cb.SelectedIndex = 0;
                ProtocolCommands.setFilter(0x01, 1);
            }
            else if (rdBtn.Content.ToString() == "中频")
            {
                highFilter_cb.Visibility = Visibility.Hidden;
                midFilter_cb.Visibility = Visibility.Visible;
                lowFilter_cb.Visibility = Visibility.Hidden;
                midFilter_cb.SelectedIndex = 0;
                ProtocolCommands.setFilter(0x02, 1);
            }
            else if (rdBtn.Content.ToString() == "低频")
            {
                highFilter_cb.Visibility = Visibility.Hidden;
                midFilter_cb.Visibility = Visibility.Hidden;
                lowFilter_cb.Visibility = Visibility.Visible;
                lowFilter_cb.SelectedIndex = 0;
                ProtocolCommands.setFilter(0x03, 1);
            }
        }

        private void filter_low_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setFilter(0x03, Convert.ToByte(cb.SelectedIndex + 1));

        }
        private void filter_mid_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setFilter(0x02, Convert.ToByte(cb.SelectedIndex + 1));

        }
        private void filter_high_CB_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Visibility == Visibility.Visible)
                ProtocolCommands.setFilter(0x01, Convert.ToByte(cb.SelectedIndex + 1));
        }


        #endregion


        private void paramConfigCompleteButton_click(object sender, RoutedEventArgs e)
        {
            Int32 timelen;
            byte hour;
            byte mins;
            byte secs;

            try
            {
                timelen = Convert.ToInt32(sampleTimeLength_tb.Text);
                hour = Convert.ToByte(hour_tbox.Text);
                mins = Convert.ToByte(hour_tbox.Text);
                secs = Convert.ToByte(hour_tbox.Text);
            }
            catch {
                MessageBox.Show("请输入正确的时长和时间！");
                return;
            }

            #region Channels Configuration
            byte[] channelsStatus = new byte[12];

            if (ch1_cb.IsChecked == true)
                channelsStatus[0] = 0x01;
            else
                channelsStatus[0] = 0x00;

            if (ch2_cb.IsChecked == true)
                channelsStatus[1] = 0x01;
            else
                channelsStatus[1] = 0x00;

            if (ch3_cb.IsChecked == true)
                channelsStatus[2] = 0x01;
            else
                channelsStatus[2] = 0x00;
            if (ch4_cb.IsChecked == true)
                channelsStatus[3] = 0x01;
            else
                channelsStatus[3] = 0x00;
            if (ch5_cb.IsChecked == true)
                channelsStatus[4] = 0x01;
            else
                channelsStatus[4] = 0x00;
            if (ch6_cb.IsChecked == true)
                channelsStatus[5] = 0x01;
            else
                channelsStatus[5] = 0x00;
            if (ch7_cb.IsChecked == true)
                channelsStatus[6] = 0x01;
            else
                channelsStatus[6] = 0x00;
            if (ch8_cb.IsChecked == true)
                channelsStatus[7] = 0x01;
            else
                channelsStatus[7] = 0x00;
            if (ch9_cb.IsChecked == true)
                channelsStatus[8] = 0x01;
            else
                channelsStatus[8] = 0x00;
            if (ch10_cb.IsChecked == true)
                channelsStatus[9] = 0x01;
            else
                channelsStatus[9] = 0x00;
            if (ch11_cb.IsChecked == true)
                channelsStatus[10] = 0x01;
            else
                channelsStatus[10] = 0x00;
            if (ch1_cb.IsChecked == true)
                channelsStatus[11] = 0x01;
            else
                channelsStatus[11] = 0x00;

            ProtocolCommands.setChannels(channelsStatus);

            #endregion

            #region Time Configuration
            ProtocolCommands.setSampleTime(timelen, hour, mins, secs);
            #endregion


            
        }
    }
}
