using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiChanMCard
{

    class ProtocolCommands
    {
        /* 命令中编号的下标索引 */
        private const int numberAreaIndex = 2;

        /* 命令中数据域的下标索引 */
        private const int dataAreaSIndex = 4;

        #region Command Description
        /* <header> <funcode> <num> <dataLen> <data...> <end> */
        public static byte[] CMD_START =           { 0xee, 0x01, 0x00, 0x01, 0x01, 0xfc };
        public static byte[] CMD_END =             { 0xee, 0x01, 0x00, 0x01, 0x01, 0xfc };
        public static byte[] CMD_WINLENTHSETSET =  { 0xee, 0x02, 0x00, 0x01, 0x01, 0xfc };
        public static byte[] CMD_SAMPLERATESET =   { 0xee, 0x03, 0x03, 0x01, 0x01, 0xfc };
        public static byte[] CMD_GAINSET =         { 0xee, 0x04, 0x03, 0x01, 0x01, 0xfc };
        public static byte[] CMD_FILTERSET =       { 0xee, 0x05, 0x03, 0x01, 0x01, 0xfc};
        public static byte[] CMD_ENDISCHANNEL =    { 0xee, 0x06, 0x00, 0x0c,
                                                      0x00, 0x00, 0x00, 0x00,
                                                      0x00, 0x00, 0x00, 0x00,
                                                      0x00, 0x00, 0x00, 0x00, 0xfc};
        public static byte[] CMD_SAMPLETIME =      { 0xee, 0x07, 0x00, 0x07,
                                                      0x00, 0x00, 0x00, 0x00,
                                                      0x00, 0x00, 0x00, 0xfc};
        #endregion

        public static void setWindowLength(byte value)
        {
            CMD_WINLENTHSETSET[dataAreaSIndex] = value;
        }

        public static void setSampleRate(byte num, byte value)
        {
            CMD_SAMPLERATESET[numberAreaIndex] = num;
            CMD_SAMPLERATESET[dataAreaSIndex] = value;
        }

        public static void setGain(byte num, byte value)
        {
            CMD_GAINSET[numberAreaIndex] = num;
            CMD_GAINSET[dataAreaSIndex] = value;
        }

        public static void setFilter(byte num, byte value)
        {
            CMD_FILTERSET[numberAreaIndex] = num;
            CMD_FILTERSET[dataAreaSIndex] = value;
        }

        public static void setChannels(byte[] value)
        {
            if (value.Length == 12)
            {
                for(int i = 0; i < 12; i++)
                    CMD_ENDISCHANNEL[dataAreaSIndex+i] = value[i];
            }
        }

        public static void setSampleTime(Int32 timeLen, byte hour, byte mins, byte secs)
        {
            byte[] timelength = BitConverter.GetBytes(timeLen);

            CMD_SAMPLETIME[dataAreaSIndex]     = timelength[0];
            CMD_SAMPLETIME[dataAreaSIndex + 1] = timelength[1];
            CMD_SAMPLETIME[dataAreaSIndex + 2] = timelength[2];
            CMD_SAMPLETIME[dataAreaSIndex + 3] = timelength[3];

            CMD_SAMPLETIME[dataAreaSIndex + 3] = hour;
            CMD_SAMPLETIME[dataAreaSIndex + 4] = mins;
            CMD_SAMPLETIME[dataAreaSIndex + 5] = secs;
        }
    }
}
