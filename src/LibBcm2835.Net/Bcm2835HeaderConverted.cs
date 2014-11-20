#region License
//The MIT License (MIT)

//Copyright (c) 2014 Frank Hommers ( http://hmm.rs/LibBcm2835.Net )

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion
#region Attribution
// Based on the bcm2835.h file from http://www.airspayce.com/mikem/bcm2835/
// The bcm2835.h file is converted automatically to this partial class.
#endregion
using System;
using System.Runtime.InteropServices;

namespace LibBcm2835.Net
{
  public sealed partial class Bcm2835
  {
    #region "Defines from bcm2835.h"
    public const Byte HIGH = 0x1;
    public const Byte LOW = 0x0;
    /// <summary>250 MHz</summary>
    public const UInt32 BCM2835_CORE_CLK_HZ = 250000000;
    public const UInt32 BCM2835_PERI_BASE = 0x20000000;
    public const UInt32 BCM2835_ST_BASE = (BCM2835_PERI_BASE + 0x3000);
    public const UInt32 BCM2835_GPIO_PADS = (BCM2835_PERI_BASE + 0x100000);
    public const UInt32 BCM2835_CLOCK_BASE = (BCM2835_PERI_BASE + 0x101000);
    public const UInt32 BCM2835_GPIO_BASE = (BCM2835_PERI_BASE + 0x200000);
    public const UInt32 BCM2835_SPI0_BASE = (BCM2835_PERI_BASE + 0x204000);
    public const UInt32 BCM2835_BSC0_BASE = (BCM2835_PERI_BASE + 0x205000);
    public const UInt32 BCM2835_GPIO_PWM = (BCM2835_PERI_BASE + 0x20C000);
    public const UInt32 BCM2835_BSC1_BASE = (BCM2835_PERI_BASE + 0x804000);
    public const UInt32 BCM2835_PAGE_SIZE = (4 * 1024);
    public const UInt32 BCM2835_BLOCK_SIZE = (4 * 1024);
    /// <summary>GPIO Function Select 0</summary>
    public const UInt32 BCM2835_GPFSEL0 = 0x0000;
    /// <summary>GPIO Function Select 1</summary>
    public const UInt32 BCM2835_GPFSEL1 = 0x0004;
    /// <summary>GPIO Function Select 2</summary>
    public const UInt32 BCM2835_GPFSEL2 = 0x0008;
    /// <summary>GPIO Function Select 3</summary>
    public const UInt32 BCM2835_GPFSEL3 = 0x000c;
    /// <summary>GPIO Function Select 4</summary>
    public const UInt32 BCM2835_GPFSEL4 = 0x0010;
    /// <summary>GPIO Function Select 5</summary>
    public const UInt32 BCM2835_GPFSEL5 = 0x0014;
    /// <summary>GPIO Pin Output Set 0</summary>
    public const UInt32 BCM2835_GPSET0 = 0x001c;
    /// <summary>GPIO Pin Output Set 1</summary>
    public const UInt32 BCM2835_GPSET1 = 0x0020;
    /// <summary>GPIO Pin Output Clear 0</summary>
    public const UInt32 BCM2835_GPCLR0 = 0x0028;
    /// <summary>GPIO Pin Output Clear 1</summary>
    public const UInt32 BCM2835_GPCLR1 = 0x002c;
    /// <summary>GPIO Pin Level 0</summary>
    public const UInt32 BCM2835_GPLEV0 = 0x0034;
    /// <summary>GPIO Pin Level 1</summary>
    public const UInt32 BCM2835_GPLEV1 = 0x0038;
    /// <summary>GPIO Pin Event Detect Status 0</summary>
    public const UInt32 BCM2835_GPEDS0 = 0x0040;
    /// <summary>GPIO Pin Event Detect Status 1</summary>
    public const UInt32 BCM2835_GPEDS1 = 0x0044;
    /// <summary>GPIO Pin Rising Edge Detect Enable 0</summary>
    public const UInt32 BCM2835_GPREN0 = 0x004c;
    /// <summary>GPIO Pin Rising Edge Detect Enable 1</summary>
    public const UInt32 BCM2835_GPREN1 = 0x0050;
    /// <summary>GPIO Pin Falling Edge Detect Enable 0</summary>
    public const UInt32 BCM2835_GPFEN0 = 0x0058;
    /// <summary>GPIO Pin Falling Edge Detect Enable 1</summary>
    public const UInt32 BCM2835_GPFEN1 = 0x005c;
    /// <summary>GPIO Pin High Detect Enable 0</summary>
    public const UInt32 BCM2835_GPHEN0 = 0x0064;
    /// <summary>GPIO Pin High Detect Enable 1</summary>
    public const UInt32 BCM2835_GPHEN1 = 0x0068;
    /// <summary>GPIO Pin Low Detect Enable 0</summary>
    public const UInt32 BCM2835_GPLEN0 = 0x0070;
    /// <summary>GPIO Pin Low Detect Enable 1</summary>
    public const UInt32 BCM2835_GPLEN1 = 0x0074;
    /// <summary>GPIO Pin Async. Rising Edge Detect 0</summary>
    public const UInt32 BCM2835_GPAREN0 = 0x007c;
    /// <summary>GPIO Pin Async. Rising Edge Detect 1</summary>
    public const UInt32 BCM2835_GPAREN1 = 0x0080;
    /// <summary>GPIO Pin Async. Falling Edge Detect 0</summary>
    public const UInt32 BCM2835_GPAFEN0 = 0x0088;
    /// <summary>GPIO Pin Async. Falling Edge Detect 1</summary>
    public const UInt32 BCM2835_GPAFEN1 = 0x008c;
    /// <summary>GPIO Pin Pull-up/down Enable</summary>
    public const UInt32 BCM2835_GPPUD = 0x0094;
    /// <summary>GPIO Pin Pull-up/down Enable Clock 0</summary>
    public const UInt32 BCM2835_GPPUDCLK0 = 0x0098;
    /// <summary>GPIO Pin Pull-up/down Enable Clock 1</summary>
    public const UInt32 BCM2835_GPPUDCLK1 = 0x009c;
    /// <summary>Pad control register for pads 0 to 27</summary>
    public const UInt32 BCM2835_PADS_GPIO_0_27 = 0x002c;
    /// <summary>Pad control register for pads 28 to 45</summary>
    public const UInt32 BCM2835_PADS_GPIO_28_45 = 0x0030;
    /// <summary>Pad control register for pads 46 to 53</summary>
    public const UInt32 BCM2835_PADS_GPIO_46_53 = 0x0034;
    /// <summary>Password to enable setting pad mask</summary>
    public const UInt32 BCM2835_PAD_PASSWRD = (0x5A << 24);
    /// <summary>Slew rate unlimited</summary>
    public const UInt32 BCM2835_PAD_SLEW_RATE_UNLIMITED = 0x10;
    /// <summary>Hysteresis enabled</summary>
    public const UInt32 BCM2835_PAD_HYSTERESIS_ENABLED = 0x08;
    /// <summary>2mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_2mA = 0x00;
    /// <summary>4mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_4mA = 0x01;
    /// <summary>6mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_6mA = 0x02;
    /// <summary>8mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_8mA = 0x03;
    /// <summary>10mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_10mA = 0x04;
    /// <summary>12mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_12mA = 0x05;
    /// <summary>14mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_14mA = 0x06;
    /// <summary>16mA drive current</summary>
    public const UInt32 BCM2835_PAD_DRIVE_16mA = 0x07;
    /// <summary>SPI Master Control and Status</summary>
    public const UInt32 BCM2835_SPI0_CS = 0x0000;
    /// <summary>SPI Master TX and RX FIFOs</summary>
    public const UInt32 BCM2835_SPI0_FIFO = 0x0004;
    /// <summary>SPI Master Clock Divider</summary>
    public const UInt32 BCM2835_SPI0_CLK = 0x0008;
    /// <summary>SPI Master Data Length</summary>
    public const UInt32 BCM2835_SPI0_DLEN = 0x000c;
    /// <summary>SPI LOSSI mode TOH</summary>
    public const UInt32 BCM2835_SPI0_LTOH = 0x0010;
    /// <summary>SPI DMA DREQ Controls</summary>
    public const UInt32 BCM2835_SPI0_DC = 0x0014;
    /// <summary>Enable Long data word in Lossi mode if DMA_LEN is set</summary>
    public const UInt32 BCM2835_SPI0_CS_LEN_LONG = 0x02000000;
    /// <summary>Enable DMA mode in Lossi mode</summary>
    public const UInt32 BCM2835_SPI0_CS_DMA_LEN = 0x01000000;
    /// <summary>Chip Select 2 Polarity</summary>
    public const UInt32 BCM2835_SPI0_CS_CSPOL2 = 0x00800000;
    /// <summary>Chip Select 1 Polarity</summary>
    public const UInt32 BCM2835_SPI0_CS_CSPOL1 = 0x00400000;
    /// <summary>Chip Select 0 Polarity</summary>
    public const UInt32 BCM2835_SPI0_CS_CSPOL0 = 0x00200000;
    /// <summary>RXF - RX FIFO Full</summary>
    public const UInt32 BCM2835_SPI0_CS_RXF = 0x00100000;
    /// <summary>RXR RX FIFO needs Reading ( full)</summary>
    public const UInt32 BCM2835_SPI0_CS_RXR = 0x00080000;
    /// <summary>TXD TX FIFO can accept Data</summary>
    public const UInt32 BCM2835_SPI0_CS_TXD = 0x00040000;
    /// <summary>RXD RX FIFO contains Data</summary>
    public const UInt32 BCM2835_SPI0_CS_RXD = 0x00020000;
    /// <summary>Done transfer Done</summary>
    public const UInt32 BCM2835_SPI0_CS_DONE = 0x00010000;
    /// <summary>Unused</summary>
    public const UInt32 BCM2835_SPI0_CS_TE_EN = 0x00008000;
    /// <summary>Unused</summary>
    public const UInt32 BCM2835_SPI0_CS_LMONO = 0x00004000;
    /// <summary>LEN LoSSI enable</summary>
    public const UInt32 BCM2835_SPI0_CS_LEN = 0x00002000;
    /// <summary>REN Read Enable</summary>
    public const UInt32 BCM2835_SPI0_CS_REN = 0x00001000;
    /// <summary>ADCS Automatically Deassert Chip Select</summary>
    public const UInt32 BCM2835_SPI0_CS_ADCS = 0x00000800;
    /// <summary>INTR Interrupt on RXR</summary>
    public const UInt32 BCM2835_SPI0_CS_INTR = 0x00000400;
    /// <summary>INTD Interrupt on Done</summary>
    public const UInt32 BCM2835_SPI0_CS_INTD = 0x00000200;
    /// <summary>DMAEN DMA Enable</summary>
    public const UInt32 BCM2835_SPI0_CS_DMAEN = 0x00000100;
    /// <summary>Transfer Active</summary>
    public const UInt32 BCM2835_SPI0_CS_TA = 0x00000080;
    /// <summary>Chip Select Polarity</summary>
    public const UInt32 BCM2835_SPI0_CS_CSPOL = 0x00000040;
    /// <summary>Clear FIFO Clear RX and TX</summary>
    public const UInt32 BCM2835_SPI0_CS_CLEAR = 0x00000030;
    /// <summary>Clear FIFO Clear RX</summary>
    public const UInt32 BCM2835_SPI0_CS_CLEAR_RX = 0x00000020;
    /// <summary>Clear FIFO Clear TX</summary>
    public const UInt32 BCM2835_SPI0_CS_CLEAR_TX = 0x00000010;
    /// <summary>Clock Polarity</summary>
    public const UInt32 BCM2835_SPI0_CS_CPOL = 0x00000008;
    /// <summary>Clock Phase</summary>
    public const UInt32 BCM2835_SPI0_CS_CPHA = 0x00000004;
    /// <summary>Chip Select</summary>
    public const UInt32 BCM2835_SPI0_CS_CS = 0x00000003;
    /// <summary>BSC Master Control</summary>
    public const UInt32 BCM2835_BSC_C = 0x0000;
    /// <summary>BSC Master Status</summary>
    public const UInt32 BCM2835_BSC_S = 0x0004;
    /// <summary>BSC Master Data Length</summary>
    public const UInt32 BCM2835_BSC_DLEN = 0x0008;
    /// <summary>BSC Master Slave Address</summary>
    public const UInt32 BCM2835_BSC_A = 0x000c;
    /// <summary>BSC Master Data FIFO</summary>
    public const UInt32 BCM2835_BSC_FIFO = 0x0010;
    /// <summary>BSC Master Clock Divider</summary>
    public const UInt32 BCM2835_BSC_DIV = 0x0014;
    /// <summary>BSC Master Data Delay</summary>
    public const UInt32 BCM2835_BSC_DEL = 0x0018;
    /// <summary>BSC Master Clock Stretch Timeout</summary>
    public const UInt32 BCM2835_BSC_CLKT = 0x001c;
    /// <summary>I2C Enable, 0 = disabled, 1 = enabled</summary>
    public const UInt32 BCM2835_BSC_C_I2CEN = 0x00008000;
    /// <summary>Interrupt on RX</summary>
    public const UInt32 BCM2835_BSC_C_INTR = 0x00000400;
    /// <summary>Interrupt on TX</summary>
    public const UInt32 BCM2835_BSC_C_INTT = 0x00000200;
    /// <summary>Interrupt on DONE</summary>
    public const UInt32 BCM2835_BSC_C_INTD = 0x00000100;
    /// <summary>Start transfer, 1 = Start a new transfer</summary>
    public const UInt32 BCM2835_BSC_C_ST = 0x00000080;
    /// <summary>Clear FIFO Clear</summary>
    public const UInt32 BCM2835_BSC_C_CLEAR_1 = 0x00000020;
    /// <summary>Clear FIFO Clear</summary>
    public const UInt32 BCM2835_BSC_C_CLEAR_2 = 0x00000010;
    /// <summary>Read transfer</summary>
    public const UInt32 BCM2835_BSC_C_READ = 0x00000001;
    /// <summary>Clock stretch timeout</summary>
    public const UInt32 BCM2835_BSC_S_CLKT = 0x00000200;
    /// <summary>ACK error</summary>
    public const UInt32 BCM2835_BSC_S_ERR = 0x00000100;
    /// <summary>RXF FIFO full, 0 = FIFO is not full, 1 = FIFO is full</summary>
    public const UInt32 BCM2835_BSC_S_RXF = 0x00000080;
    /// <summary>TXE FIFO full, 0 = FIFO is not full, 1 = FIFO is full</summary>
    public const UInt32 BCM2835_BSC_S_TXE = 0x00000040;
    /// <summary>RXD FIFO contains data</summary>
    public const UInt32 BCM2835_BSC_S_RXD = 0x00000020;
    /// <summary>TXD FIFO can accept data</summary>
    public const UInt32 BCM2835_BSC_S_TXD = 0x00000010;
    /// <summary>RXR FIFO needs reading (full)</summary>
    public const UInt32 BCM2835_BSC_S_RXR = 0x00000008;
    /// <summary>TXW FIFO needs writing (full)</summary>
    public const UInt32 BCM2835_BSC_S_TXW = 0x00000004;
    /// <summary>Transfer DONE</summary>
    public const UInt32 BCM2835_BSC_S_DONE = 0x00000002;
    /// <summary>Transfer Active</summary>
    public const UInt32 BCM2835_BSC_S_TA = 0x00000001;
    /// <summary>BSC FIFO size</summary>
    public const UInt32 BCM2835_BSC_FIFO_SIZE = 16;
    /// <summary>System Timer Control/Status</summary>
    public const UInt32 BCM2835_ST_CS = 0x0000;
    /// <summary>System Timer Counter Lower 32 bits</summary>
    public const UInt32 BCM2835_ST_CLO = 0x0004;
    /// <summary>System Timer Counter Upper 32 bits</summary>
    public const UInt32 BCM2835_ST_CHI = 0x0008;
    public const UInt32 BCM2835_PWMCLK_CNTL = 40;
    public const UInt32 BCM2835_PWMCLK_DIV = 41;
    /// <summary>Password to enable setting PWM clock</summary>
    public const UInt32 BCM2835_PWM_PASSWRD = (0x5A << 24);
    /// <summary>Run in Mark/Space mode</summary>
    public const UInt32 BCM2835_PWM1_MS_MODE = 0x8000;
    /// <summary>Data from FIFO</summary>
    public const UInt32 BCM2835_PWM1_USEFIFO = 0x2000;
    /// <summary>Reverse polarity</summary>
    public const UInt32 BCM2835_PWM1_REVPOLAR = 0x1000;
    /// <summary>Ouput Off state</summary>
    public const UInt32 BCM2835_PWM1_OFFSTATE = 0x0800;
    /// <summary>Repeat last value if FIFO empty</summary>
    public const UInt32 BCM2835_PWM1_REPEATFF = 0x0400;
    /// <summary>Run in serial mode</summary>
    public const UInt32 BCM2835_PWM1_SERIAL = 0x0200;
    /// <summary>Channel Enable</summary>
    public const UInt32 BCM2835_PWM1_ENABLE = 0x0100;
    /// <summary>Run in Mark/Space mode</summary>
    public const UInt32 BCM2835_PWM0_MS_MODE = 0x0080;
    /// <summary>Clear FIFO</summary>
    public const UInt32 BCM2835_PWM_CLEAR_FIFO = 0x0040;
    /// <summary>Data from FIFO</summary>
    public const UInt32 BCM2835_PWM0_USEFIFO = 0x0020;
    /// <summary>Reverse polarity</summary>
    public const UInt32 BCM2835_PWM0_REVPOLAR = 0x0010;
    /// <summary>Ouput Off state</summary>
    public const UInt32 BCM2835_PWM0_OFFSTATE = 0x0008;
    /// <summary>Repeat last value if FIFO empty</summary>
    public const UInt32 BCM2835_PWM0_REPEATFF = 0x0004;
    /// <summary>Run in serial mode</summary>
    public const UInt32 BCM2835_PWM0_SERIAL = 0x0002;
    /// <summary>Channel Enable</summary>
    public const UInt32 BCM2835_PWM0_ENABLE = 0x0001;

    #endregion

    #region "enums from bcm2835.h"
    public enum bcm2835RegisterBase
    {
      /// <summary>Base of the ST (System Timer) registers.</summary>
      BCM2835_REGBASE_ST = 1,
      /// <summary>Base of the GPIO registers.</summary>
      BCM2835_REGBASE_GPIO = 2,
      /// <summary>Base of the PWM registers.</summary>
      BCM2835_REGBASE_PWM = 3,
      /// <summary>Base of the CLK registers.</summary>
      BCM2835_REGBASE_CLK = 4,
      /// <summary>Base of the PADS registers.</summary>
      BCM2835_REGBASE_PADS = 5,
      /// <summary>Base of the SPI0 registers.</summary>
      BCM2835_REGBASE_SPI0 = 6,
      /// <summary>Base of the BSC0 registers.</summary>
      BCM2835_REGBASE_BSC0 = 7,
      /// <summary>Base of the BSC1 registers.</summary>
      BCM2835_REGBASE_BSC1 = 8,
    }
    public enum bcm2835FunctionSelect
    {
      /// <summary>Input</summary>
      BCM2835_GPIO_FSEL_INPT = 0,
      /// <summary>Output</summary>
      BCM2835_GPIO_FSEL_OUTP = 1,
      /// <summary>Alternate function 0</summary>
      BCM2835_GPIO_FSEL_ALT0 = 4,
      /// <summary>Alternate function 1</summary>
      BCM2835_GPIO_FSEL_ALT1 = 5,
      /// <summary>Alternate function 2</summary>
      BCM2835_GPIO_FSEL_ALT2 = 6,
      /// <summary>Alternate function 3</summary>
      BCM2835_GPIO_FSEL_ALT3 = 7,
      /// <summary>Alternate function 4</summary>
      BCM2835_GPIO_FSEL_ALT4 = 3,
      /// <summary>Alternate function 5</summary>
      BCM2835_GPIO_FSEL_ALT5 = 2,
      /// <summary>Function select bits mask</summary>
      BCM2835_GPIO_FSEL_MASK = 7,
    }
    public enum bcm2835PUDControl
    {
      /// <summary>Off ? disable pull-up/down</summary>
      BCM2835_GPIO_PUD_OFF = 0,
      /// <summary>Enable Pull Down control</summary>
      BCM2835_GPIO_PUD_DOWN = 1,
      /// <summary>Enable Pull Up control</summary>
      BCM2835_GPIO_PUD_UP = 2,
    }
    public enum bcm2835PadGroup
    {
      /// <summary>Pad group for GPIO pads 0 to 27</summary>
      BCM2835_PAD_GROUP_GPIO_0_27 = 0,
      /// <summary>Pad group for GPIO pads 28 to 45</summary>
      BCM2835_PAD_GROUP_GPIO_28_45 = 1,
      /// <summary>Pad group for GPIO pads 46 to 53</summary>
      BCM2835_PAD_GROUP_GPIO_46_53 = 2,
    }
    public enum RPiGPIOPin
    {
      /// <summary>Version 1, Pin P1-03</summary>
      RPI_GPIO_P1_03 = 0,
      /// <summary>Version 1, Pin P1-05</summary>
      RPI_GPIO_P1_05 = 1,
      /// <summary>Version 1, Pin P1-07</summary>
      RPI_GPIO_P1_07 = 4,
      /// <summary>Version 1, Pin P1-08, defaults to alt function 0 UART0_TXD</summary>
      RPI_GPIO_P1_08 = 14,
      /// <summary>Version 1, Pin P1-10, defaults to alt function 0 UART0_RXD</summary>
      RPI_GPIO_P1_10 = 15,
      /// <summary>Version 1, Pin P1-11</summary>
      RPI_GPIO_P1_11 = 17,
      /// <summary>Version 1, Pin P1-12, can be PWM channel 0 in ALT FUN 5</summary>
      RPI_GPIO_P1_12 = 18,
      /// <summary>Version 1, Pin P1-13</summary>
      RPI_GPIO_P1_13 = 21,
      /// <summary>Version 1, Pin P1-15</summary>
      RPI_GPIO_P1_15 = 22,
      /// <summary>Version 1, Pin P1-16</summary>
      RPI_GPIO_P1_16 = 23,
      /// <summary>Version 1, Pin P1-18</summary>
      RPI_GPIO_P1_18 = 24,
      /// <summary>Version 1, Pin P1-19, MOSI when SPI0 in use</summary>
      RPI_GPIO_P1_19 = 10,
      /// <summary>Version 1, Pin P1-21, MISO when SPI0 in use</summary>
      RPI_GPIO_P1_21 = 9,
      /// <summary>Version 1, Pin P1-22</summary>
      RPI_GPIO_P1_22 = 25,
      /// <summary>Version 1, Pin P1-23, CLK when SPI0 in use</summary>
      RPI_GPIO_P1_23 = 11,
      /// <summary>Version 1, Pin P1-24, CE0 when SPI0 in use</summary>
      RPI_GPIO_P1_24 = 8,
      /// <summary>Version 1, Pin P1-26, CE1 when SPI0 in use</summary>
      RPI_GPIO_P1_26 = 7,
      /// <summary>Version 2, Pin P1-03</summary>
      RPI_V2_GPIO_P1_03 = 2,
      /// <summary>Version 2, Pin P1-05</summary>
      RPI_V2_GPIO_P1_05 = 3,
      /// <summary>Version 2, Pin P1-07</summary>
      RPI_V2_GPIO_P1_07 = 4,
      /// <summary>Version 2, Pin P1-08, defaults to alt function 0 UART0_TXD</summary>
      RPI_V2_GPIO_P1_08 = 14,
      /// <summary>Version 2, Pin P1-10, defaults to alt function 0 UART0_RXD</summary>
      RPI_V2_GPIO_P1_10 = 15,
      /// <summary>Version 2, Pin P1-11</summary>
      RPI_V2_GPIO_P1_11 = 17,
      /// <summary>Version 2, Pin P1-12, can be PWM channel 0 in ALT FUN 5</summary>
      RPI_V2_GPIO_P1_12 = 18,
      /// <summary>Version 2, Pin P1-13</summary>
      RPI_V2_GPIO_P1_13 = 27,
      /// <summary>Version 2, Pin P1-15</summary>
      RPI_V2_GPIO_P1_15 = 22,
      /// <summary>Version 2, Pin P1-16</summary>
      RPI_V2_GPIO_P1_16 = 23,
      /// <summary>Version 2, Pin P1-18</summary>
      RPI_V2_GPIO_P1_18 = 24,
      /// <summary>Version 2, Pin P1-19, MOSI when SPI0 in use</summary>
      RPI_V2_GPIO_P1_19 = 10,
      /// <summary>Version 2, Pin P1-21, MISO when SPI0 in use</summary>
      RPI_V2_GPIO_P1_21 = 9,
      /// <summary>Version 2, Pin P1-22</summary>
      RPI_V2_GPIO_P1_22 = 25,
      /// <summary>Version 2, Pin P1-23, CLK when SPI0 in use</summary>
      RPI_V2_GPIO_P1_23 = 11,
      /// <summary>Version 2, Pin P1-24, CE0 when SPI0 in use</summary>
      RPI_V2_GPIO_P1_24 = 8,
      /// <summary>Version 2, Pin P1-26, CE1 when SPI0 in use</summary>
      RPI_V2_GPIO_P1_26 = 7,
      /// <summary>Version 2, Pin P5-03</summary>
      RPI_V2_GPIO_P5_03 = 28,
      /// <summary>Version 2, Pin P5-04</summary>
      RPI_V2_GPIO_P5_04 = 29,
      /// <summary>Version 2, Pin P5-05</summary>
      RPI_V2_GPIO_P5_05 = 30,
      /// <summary>Version 2, Pin P5-06</summary>
      RPI_V2_GPIO_P5_06 = 31,
      /// <summary>B+, Pin J8-03</summary>
      RPI_BPLUS_GPIO_J8_03 = 2,
      /// <summary>B+, Pin J8-05</summary>
      RPI_BPLUS_GPIO_J8_05 = 3,
      /// <summary>B+, Pin J8-07</summary>
      RPI_BPLUS_GPIO_J8_07 = 4,
      /// <summary>B+, Pin J8-08, defaults to alt function 0 UART0_TXD</summary>
      RPI_BPLUS_GPIO_J8_08 = 14,
      /// <summary>B+, Pin J8-10, defaults to alt function 0 UART0_RXD</summary>
      RPI_BPLUS_GPIO_J8_10 = 15,
      /// <summary>B+, Pin J8-11</summary>
      RPI_BPLUS_GPIO_J8_11 = 17,
      /// <summary>B+, Pin J8-12, can be PWM channel 0 in ALT FUN 5</summary>
      RPI_BPLUS_GPIO_J8_12 = 18,
      /// <summary>B+, Pin J8-13</summary>
      RPI_BPLUS_GPIO_J8_13 = 27,
      /// <summary>B+, Pin J8-15</summary>
      RPI_BPLUS_GPIO_J8_15 = 22,
      /// <summary>B+, Pin J8-16</summary>
      RPI_BPLUS_GPIO_J8_16 = 23,
      /// <summary>B+, Pin J8-18</summary>
      RPI_BPLUS_GPIO_J8_18 = 24,
      /// <summary>B+, Pin J8-19, MOSI when SPI0 in use</summary>
      RPI_BPLUS_GPIO_J8_19 = 10,
      /// <summary>B+, Pin J8-21, MISO when SPI0 in use</summary>
      RPI_BPLUS_GPIO_J8_21 = 9,
      /// <summary>B+, Pin J8-22</summary>
      RPI_BPLUS_GPIO_J8_22 = 25,
      /// <summary>B+, Pin J8-23, CLK when SPI0 in use</summary>
      RPI_BPLUS_GPIO_J8_23 = 11,
      /// <summary>B+, Pin J8-24, CE0 when SPI0 in use</summary>
      RPI_BPLUS_GPIO_J8_24 = 8,
      /// <summary>B+, Pin J8-26, CE1 when SPI0 in use</summary>
      RPI_BPLUS_GPIO_J8_26 = 7,
      /// <summary>B+, Pin J8-29,</summary>
      RPI_BPLUS_GPIO_J8_29 = 5,
      /// <summary>B+, Pin J8-31,</summary>
      RPI_BPLUS_GPIO_J8_31 = 6,
      /// <summary>B+, Pin J8-32,</summary>
      RPI_BPLUS_GPIO_J8_32 = 12,
      /// <summary>B+, Pin J8-33,</summary>
      RPI_BPLUS_GPIO_J8_33 = 13,
      /// <summary>B+, Pin J8-35,</summary>
      RPI_BPLUS_GPIO_J8_35 = 19,
      /// <summary>B+, Pin J8-36,</summary>
      RPI_BPLUS_GPIO_J8_36 = 16,
      /// <summary>B+, Pin J8-37,</summary>
      RPI_BPLUS_GPIO_J8_37 = 26,
      /// <summary>B+, Pin J8-38,</summary>
      RPI_BPLUS_GPIO_J8_38 = 20,
      /// <summary>B+, Pin J8-40,</summary>
      RPI_BPLUS_GPIO_J8_40 = 21,
    }
    public enum bcm2835SPIBitOrder
    {
      /// <summary>LSB First</summary>
      BCM2835_SPI_BIT_ORDER_LSBFIRST = 0,
      /// <summary>MSB First</summary>
      BCM2835_SPI_BIT_ORDER_MSBFIRST = 1,
    }
    public enum bcm2835SPIMode
    {
      /// <summary>CPOL = 0, CPHA = 0</summary>
      BCM2835_SPI_MODE0 = 0,
      /// <summary>CPOL = 0, CPHA = 1</summary>
      BCM2835_SPI_MODE1 = 1,
      /// <summary>CPOL = 1, CPHA = 0</summary>
      BCM2835_SPI_MODE2 = 2,
      /// <summary>CPOL = 1, CPHA = 1</summary>
      BCM2835_SPI_MODE3 = 3,
    }
    public enum bcm2835SPIChipSelect
    {
      /// <summary>Chip Select 0</summary>
      BCM2835_SPI_CS0 = 0,
      /// <summary>Chip Select 1</summary>
      BCM2835_SPI_CS1 = 1,
      /// <summary>Chip Select 2 (ie pins CS1 and CS2 are asserted)</summary>
      BCM2835_SPI_CS2 = 2,
      /// <summary>No CS, control it yourself</summary>
      BCM2835_SPI_CS_NONE = 3,
    }
    public enum bcm2835SPIClockDivider
    {
      /// <summary>65536 = 262.144us = 3.814697260kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_65536 = 0,
      /// <summary>32768 = 131.072us = 7.629394531kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_32768 = 32768,
      /// <summary>16384 = 65.536us = 15.25878906kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_16384 = 16384,
      /// <summary>8192 = 32.768us = 30/51757813kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_8192 = 8192,
      /// <summary>4096 = 16.384us = 61.03515625kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_4096 = 4096,
      /// <summary>2048 = 8.192us = 122.0703125kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_2048 = 2048,
      /// <summary>1024 = 4.096us = 244.140625kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_1024 = 1024,
      /// <summary>512 = 2.048us = 488.28125kHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_512 = 512,
      /// <summary>256 = 1.024us = 976.5625MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_256 = 256,
      /// <summary>128 = 512ns = = 1.953125MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_128 = 128,
      /// <summary>64 = 256ns = 3.90625MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_64 = 64,
      /// <summary>32 = 128ns = 7.8125MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_32 = 32,
      /// <summary>16 = 64ns = 15.625MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_16 = 16,
      /// <summary>8 = 32ns = 31.25MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_8 = 8,
      /// <summary>4 = 16ns = 62.5MHz</summary>
      BCM2835_SPI_CLOCK_DIVIDER_4 = 4,
      /// <summary>2 = 8ns = 125MHz, fastest you can get</summary>
      BCM2835_SPI_CLOCK_DIVIDER_2 = 2,
      /// <summary>1 = 262.144us = 3.814697260kHz, same as 0/65536</summary>
      BCM2835_SPI_CLOCK_DIVIDER_1 = 1,
    }
    public enum bcm2835I2CClockDivider
    {
      /// <summary>2500 = 10us = 100 kHz</summary>
      BCM2835_I2C_CLOCK_DIVIDER_2500 = 2500,
      /// <summary>622 = 2.504us = 399.3610 kHz</summary>
      BCM2835_I2C_CLOCK_DIVIDER_626 = 626,
      /// <summary>150 = 60ns = 1.666 MHz (default at reset)</summary>
      BCM2835_I2C_CLOCK_DIVIDER_150 = 150,
      /// <summary>148 = 59ns = 1.689 MHz</summary>
      BCM2835_I2C_CLOCK_DIVIDER_148 = 148,
    }
    public enum bcm2835I2CReasonCodes
    {
      /// <summary>Success</summary>
      BCM2835_I2C_REASON_OK = 0x00,
      /// <summary>Received a NACK</summary>
      BCM2835_I2C_REASON_ERROR_NACK = 0x01,
      /// <summary>Received Clock Stretch Timeout</summary>
      BCM2835_I2C_REASON_ERROR_CLKT = 0x02,
      /// <summary>Not all data is sent / received</summary>
      BCM2835_I2C_REASON_ERROR_DATA = 0x04,
    }
    public enum bcm2835PWMClockDivider
    {
      /// <summary>32768 = 585Hz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_32768 = 32768,
      /// <summary>16384 = 1171.8Hz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_16384 = 16384,
      /// <summary>8192 = 2.34375kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_8192 = 8192,
      /// <summary>4096 = 4.6875kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_4096 = 4096,
      /// <summary>2048 = 9.375kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_2048 = 2048,
      /// <summary>1024 = 18.75kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_1024 = 1024,
      /// <summary>512 = 37.5kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_512 = 512,
      /// <summary>256 = 75kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_256 = 256,
      /// <summary>128 = 150kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_128 = 128,
      /// <summary>64 = 300kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_64 = 64,
      /// <summary>32 = 600.0kHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_32 = 32,
      /// <summary>16 = 1.2MHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_16 = 16,
      /// <summary>8 = 2.4MHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_8 = 8,
      /// <summary>4 = 4.8MHz</summary>
      BCM2835_PWM_CLOCK_DIVIDER_4 = 4,
      /// <summary>2 = 9.6MHz, fastest you can get</summary>
      BCM2835_PWM_CLOCK_DIVIDER_2 = 2,
      /// <summary>1 = 4.6875kHz, same as divider 4096</summary>
      BCM2835_PWM_CLOCK_DIVIDER_1 = 1,
    }

    #endregion

    #region "Functions/methods from bcm2835.h"
    #region "bcm2835_init"
    private delegate Int32 bcm2835_init_delegate();
    private Int32 bcm2835_init_unresolved() { throw new MissingMethodException(); }
    private bcm2835_init_delegate _bcm2835_init_method;
    /// <summary>Initialise the library by opening /dev/mem and getting pointers to the</summary>
    /// <remarks>
    /// internal memory for BCM 2835 device registers. You must call this (successfully)
    /// before calling any other
    /// functions in this library (except bcm2835_set_debug).
    /// If bcm2835_init() fails by returning 0,
    /// calling any other function may result in crashes or other failures.
    /// Prints messages to stderr in case of errors.
    /// </remarks>
    /// <returns>1 if successful else 0</returns>
    public Int32 bcm2835_init()
    {
      return _bcm2835_init_method();
    }
    #endregion

    #region "bcm2835_close"
    private delegate Int32 bcm2835_close_delegate();
    private Int32 bcm2835_close_unresolved() { throw new MissingMethodException(); }
    private bcm2835_close_delegate _bcm2835_close_method;
    /// <summary>Close the library, deallocating any allocated memory and closing /dev/mem</summary>
    /// <returns>1 if successful else 0</returns>
    public Int32 bcm2835_close()
    {
      return _bcm2835_close_method();
    }
    #endregion

    #region "bcm2835_set_debug"
    private delegate void bcm2835_set_debug_delegate(Byte debug);
    private void bcm2835_set_debug_unresolved(Byte debug) { throw new MissingMethodException(); }
    private bcm2835_set_debug_delegate _bcm2835_set_debug_method;
    /// <summary>Sets the debug level of the library.</summary>
    /// <remarks>
    /// A value of 1 prevents mapping to /dev/mem, and makes the library print out
    /// what it would do, rather than accessing the GPIO registers.
    /// A value of 0, the default, causes normal operation.
    /// Call this before calling bcm2835_init();
    /// </remarks>
    /// <param name="debug">The new debug level. 1 means debug</param>
    public void bcm2835_set_debug(Byte debug)
    {
      _bcm2835_set_debug_method(debug);
    }
    #endregion

    #region "bcm2835_regbase"
    private delegate IntPtr bcm2835_regbase_delegate(Byte regbase);
    private IntPtr bcm2835_regbase_unresolved(Byte regbase) { throw new MissingMethodException(); }
    private bcm2835_regbase_delegate _bcm2835_regbase_method;
    /// <summary>Gets the base of a register</summary>
    /// <remarks>
    /// in bcm2835RegisterBase
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="regbase">You can use one of the common values BCM2835_REGBASE_*</param>
    /// <returns>the register base</returns>
    public IntPtr bcm2835_regbase(Byte regbase)
    {
      return _bcm2835_regbase_method(regbase);
    }
    #endregion

    #region "bcm2835_peri_read"
    private delegate UInt32 bcm2835_peri_read_delegate(IntPtr paddr);
    private UInt32 bcm2835_peri_read_unresolved(IntPtr paddr) { throw new MissingMethodException(); }
    private bcm2835_peri_read_delegate _bcm2835_peri_read_method;
    /// <summary>Reads 32 bit value from a peripheral address</summary>
    /// <remarks>
    /// The read is done twice, and is therefore always safe in terms of
    /// manual section 1.3 Peripheral access precautions for correct memory ordering
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="paddr">Physical address to read from. See BCM2835_GPIO_BASE etc.</param>
    /// <returns>the value read from the 32 bit register</returns>
    public UInt32 bcm2835_peri_read(IntPtr paddr)
    {
      return _bcm2835_peri_read_method(paddr);
    }
    #endregion

    #region "bcm2835_peri_read_nb"
    private delegate UInt32 bcm2835_peri_read_nb_delegate(IntPtr paddr);
    private UInt32 bcm2835_peri_read_nb_unresolved(IntPtr paddr) { throw new MissingMethodException(); }
    private bcm2835_peri_read_nb_delegate _bcm2835_peri_read_nb_method;
    /// <summary>Reads 32 bit value from a peripheral address without the read barrier</summary>
    /// <remarks>
    /// You should only use this when your code has previously called bcm2835_peri_read()
    /// within the same peripheral, and no other peripheral access has occurred since.
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="paddr">Physical address to read from. See BCM2835_GPIO_BASE etc.</param>
    /// <returns>the value read from the 32 bit register</returns>
    public UInt32 bcm2835_peri_read_nb(IntPtr paddr)
    {
      return _bcm2835_peri_read_nb_method(paddr);
    }
    #endregion

    #region "bcm2835_peri_write"
    private delegate void bcm2835_peri_write_delegate(IntPtr paddr, UInt32 value);
    private void bcm2835_peri_write_unresolved(IntPtr paddr, UInt32 value) { throw new MissingMethodException(); }
    private bcm2835_peri_write_delegate _bcm2835_peri_write_method;
    /// <summary>Writes 32 bit value from a peripheral address</summary>
    /// <remarks>
    /// The write is done twice, and is therefore always safe in terms of
    /// manual section 1.3 Peripheral access precautions for correct memory ordering
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="paddr">Physical address to read from. See BCM2835_GPIO_BASE etc.</param>
    /// <param name="value">The 32 bit value to write</param>
    public void bcm2835_peri_write(IntPtr paddr, UInt32 value)
    {
      _bcm2835_peri_write_method(paddr, value);
    }
    #endregion

    #region "bcm2835_peri_write_nb"
    private delegate void bcm2835_peri_write_nb_delegate(IntPtr paddr, UInt32 value);
    private void bcm2835_peri_write_nb_unresolved(IntPtr paddr, UInt32 value) { throw new MissingMethodException(); }
    private bcm2835_peri_write_nb_delegate _bcm2835_peri_write_nb_method;
    /// <summary>Writes 32 bit value from a peripheral address without the write barrier</summary>
    /// <remarks>
    /// You should only use this when your code has previously called bcm2835_peri_write()
    /// within the same peripheral, and no other peripheral access has occurred since.
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="paddr">Physical address to read from. See BCM2835_GPIO_BASE etc.</param>
    /// <param name="value">The 32 bit value to write</param>
    public void bcm2835_peri_write_nb(IntPtr paddr, UInt32 value)
    {
      _bcm2835_peri_write_nb_method(paddr, value);
    }
    #endregion

    #region "bcm2835_peri_set_bits"
    private delegate void bcm2835_peri_set_bits_delegate(IntPtr paddr, UInt32 value, UInt32 mask);
    private void bcm2835_peri_set_bits_unresolved(IntPtr paddr, UInt32 value, UInt32 mask) { throw new MissingMethodException(); }
    private bcm2835_peri_set_bits_delegate _bcm2835_peri_set_bits_method;
    /// <summary>Alters a number of bits in a 32 peripheral regsiter.</summary>
    /// <remarks>
    /// It reads the current valu and then alters the bits deines as 1 in mask,
    /// according to the bit value in value.
    /// All other bits that are 0 in the mask are unaffected.
    /// Use this to alter a subset of the bits in a register.
    /// The write is done twice, and is therefore always safe in terms of
    /// manual section 1.3 Peripheral access precautions for correct memory ordering
    /// (see also) Physical Addresses
    /// </remarks>
    /// <param name="paddr">Physical address to read from. See BCM2835_GPIO_BASE etc.</param>
    /// <param name="value">The 32 bit value to write, masked in by mask.</param>
    /// <param name="mask">Bitmask that defines the bits that will be altered in the register.</param>
    public void bcm2835_peri_set_bits(IntPtr paddr, UInt32 value, UInt32 mask)
    {
      _bcm2835_peri_set_bits_method(paddr, value, mask);
    }
    #endregion

    #region "bcm2835_gpio_fsel"
    private delegate void bcm2835_gpio_fsel_delegate(Byte pin, Byte mode);
    private void bcm2835_gpio_fsel_unresolved(Byte pin, Byte mode) { throw new MissingMethodException(); }
    private bcm2835_gpio_fsel_delegate _bcm2835_gpio_fsel_method;
    /// <summary>Sets the Function Select register for the given pin, which configures</summary>
    /// <remarks>
    /// the pin as Input, Output or one of the 6 alternate functions.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <param name="mode">Mode to set the pin to, one of BCM2835_GPIO_FSEL_* from bcm2835FunctionSelect</param>
    public void bcm2835_gpio_fsel(Byte pin, Byte mode)
    {
      _bcm2835_gpio_fsel_method(pin, mode);
    }
    #endregion

    #region "bcm2835_gpio_set"
    private delegate void bcm2835_gpio_set_delegate(Byte pin);
    private void bcm2835_gpio_set_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_set_delegate _bcm2835_gpio_set_method;
    /// <summary>Sets the specified pin output to</summary>
    /// <remarks>
    /// HIGH.
    /// (see also) bcm2835_gpio_write()
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_set(Byte pin)
    {
      _bcm2835_gpio_set_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr"
    private delegate void bcm2835_gpio_clr_delegate(Byte pin);
    private void bcm2835_gpio_clr_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_delegate _bcm2835_gpio_clr_method;
    /// <summary>Sets the specified pin output to</summary>
    /// <remarks>
    /// LOW.
    /// (see also) bcm2835_gpio_write()
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr(Byte pin)
    {
      _bcm2835_gpio_clr_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_set_multi"
    private delegate void bcm2835_gpio_set_multi_delegate(UInt32 mask);
    private void bcm2835_gpio_set_multi_unresolved(UInt32 mask) { throw new MissingMethodException(); }
    private bcm2835_gpio_set_multi_delegate _bcm2835_gpio_set_multi_method;
    /// <summary>Sets any of the first 32 GPIO output pins specified in the mask to</summary>
    /// <remarks>
    /// HIGH.
    /// (see also) bcm2835_gpio_write_multi()
    /// </remarks>
    /// <param name="mask">Mask of pins to affect. Use eg: (1 &lt;&lt; RPI_GPIO_P1_03) | (1 &lt;&lt; RPI_GPIO_P1_05)</param>
    public void bcm2835_gpio_set_multi(UInt32 mask)
    {
      _bcm2835_gpio_set_multi_method(mask);
    }
    #endregion

    #region "bcm2835_gpio_clr_multi"
    private delegate void bcm2835_gpio_clr_multi_delegate(UInt32 mask);
    private void bcm2835_gpio_clr_multi_unresolved(UInt32 mask) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_multi_delegate _bcm2835_gpio_clr_multi_method;
    /// <summary>Sets any of the first 32 GPIO output pins specified in the mask to</summary>
    /// <remarks>
    /// LOW.
    /// (see also) bcm2835_gpio_write_multi()
    /// </remarks>
    /// <param name="mask">Mask of pins to affect. Use eg: (1 &lt;&lt; RPI_GPIO_P1_03) | (1 &lt;&lt; RPI_GPIO_P1_05)</param>
    public void bcm2835_gpio_clr_multi(UInt32 mask)
    {
      _bcm2835_gpio_clr_multi_method(mask);
    }
    #endregion

    #region "bcm2835_gpio_lev"
    private delegate Byte bcm2835_gpio_lev_delegate(Byte pin);
    private Byte bcm2835_gpio_lev_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_lev_delegate _bcm2835_gpio_lev_method;
    /// <summary>Reads the current level on the specified</summary>
    /// <remarks>
    /// pin and returns either HIGH or LOW. Works whether or not the pin
    /// is an input or an output.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <returns>the current level either HIGH or LOW</returns>
    public Byte bcm2835_gpio_lev(Byte pin)
    {
      return _bcm2835_gpio_lev_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_eds"
    private delegate Byte bcm2835_gpio_eds_delegate(Byte pin);
    private Byte bcm2835_gpio_eds_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_eds_delegate _bcm2835_gpio_eds_method;
    /// <summary>Event Detect Status.</summary>
    /// <remarks>
    /// Tests whether the specified pin has detected a level or edge
    /// as requested by bcm2835_gpio_ren(), bcm2835_gpio_fen(), bcm2835_gpio_hen(),
    /// bcm2835_gpio_len(), bcm2835_gpio_aren(), bcm2835_gpio_afen().
    /// Clear the flag for a given pin by calling bcm2835_gpio_set_eds(pin);
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <returns>HIGH if the event detect status for the given pin is true.</returns>
    public Byte bcm2835_gpio_eds(Byte pin)
    {
      return _bcm2835_gpio_eds_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_set_eds"
    private delegate void bcm2835_gpio_set_eds_delegate(Byte pin);
    private void bcm2835_gpio_set_eds_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_set_eds_delegate _bcm2835_gpio_set_eds_method;
    /// <summary>Sets the Event Detect Status register for a given pin to 1,</summary>
    /// <remarks>
    /// which has the effect of clearing the flag. Use this afer seeing
    /// an Event Detect Status on the pin.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_set_eds(Byte pin)
    {
      _bcm2835_gpio_set_eds_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_ren"
    private delegate void bcm2835_gpio_ren_delegate(Byte pin);
    private void bcm2835_gpio_ren_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_ren_delegate _bcm2835_gpio_ren_method;
    /// <summary>Enable Rising Edge Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a rising edge is detected, sets the appropriate pin in Event Detect Status.
    /// The GPRENn registers use
    /// synchronous edge detection. This means the input signal is sampled using the
    /// system clock and then it is looking for a ?011? pattern on the sampled signal. This
    /// has the effect of suppressing glitches.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_ren(Byte pin)
    {
      _bcm2835_gpio_ren_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_ren"
    private delegate void bcm2835_gpio_clr_ren_delegate(Byte pin);
    private void bcm2835_gpio_clr_ren_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_ren_delegate _bcm2835_gpio_clr_ren_method;
    /// <summary>Disable Rising Edge Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_ren(Byte pin)
    {
      _bcm2835_gpio_clr_ren_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_fen"
    private delegate void bcm2835_gpio_fen_delegate(Byte pin);
    private void bcm2835_gpio_fen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_fen_delegate _bcm2835_gpio_fen_method;
    /// <summary>Enable Falling Edge Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a falling edge is detected, sets the appropriate pin in Event Detect Status.
    /// The GPRENn registers use
    /// synchronous edge detection. This means the input signal is sampled using the
    /// system clock and then it is looking for a ?100? pattern on the sampled signal. This
    /// has the effect of suppressing glitches.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_fen(Byte pin)
    {
      _bcm2835_gpio_fen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_fen"
    private delegate void bcm2835_gpio_clr_fen_delegate(Byte pin);
    private void bcm2835_gpio_clr_fen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_fen_delegate _bcm2835_gpio_clr_fen_method;
    /// <summary>Disable Falling Edge Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_fen(Byte pin)
    {
      _bcm2835_gpio_clr_fen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_hen"
    private delegate void bcm2835_gpio_hen_delegate(Byte pin);
    private void bcm2835_gpio_hen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_hen_delegate _bcm2835_gpio_hen_method;
    /// <summary>Enable High Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a HIGH level is detected on the pin, sets the appropriate pin in Event Detect Status.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_hen(Byte pin)
    {
      _bcm2835_gpio_hen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_hen"
    private delegate void bcm2835_gpio_clr_hen_delegate(Byte pin);
    private void bcm2835_gpio_clr_hen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_hen_delegate _bcm2835_gpio_clr_hen_method;
    /// <summary>Disable High Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_hen(Byte pin)
    {
      _bcm2835_gpio_clr_hen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_len"
    private delegate void bcm2835_gpio_len_delegate(Byte pin);
    private void bcm2835_gpio_len_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_len_delegate _bcm2835_gpio_len_method;
    /// <summary>Enable Low Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a LOW level is detected on the pin, sets the appropriate pin in Event Detect Status.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_len(Byte pin)
    {
      _bcm2835_gpio_len_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_len"
    private delegate void bcm2835_gpio_clr_len_delegate(Byte pin);
    private void bcm2835_gpio_clr_len_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_len_delegate _bcm2835_gpio_clr_len_method;
    /// <summary>Disable Low Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_len(Byte pin)
    {
      _bcm2835_gpio_clr_len_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_aren"
    private delegate void bcm2835_gpio_aren_delegate(Byte pin);
    private void bcm2835_gpio_aren_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_aren_delegate _bcm2835_gpio_aren_method;
    /// <summary>Enable Asynchronous Rising Edge Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a rising edge is detected, sets the appropriate pin in Event Detect Status.
    /// Asynchronous means the incoming signal is not sampled by the system clock. As such
    /// rising edges of very short duration can be detected.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_aren(Byte pin)
    {
      _bcm2835_gpio_aren_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_aren"
    private delegate void bcm2835_gpio_clr_aren_delegate(Byte pin);
    private void bcm2835_gpio_clr_aren_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_aren_delegate _bcm2835_gpio_clr_aren_method;
    /// <summary>Disable Asynchronous Rising Edge Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_aren(Byte pin)
    {
      _bcm2835_gpio_clr_aren_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_afen"
    private delegate void bcm2835_gpio_afen_delegate(Byte pin);
    private void bcm2835_gpio_afen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_afen_delegate _bcm2835_gpio_afen_method;
    /// <summary>Enable Asynchronous Falling Edge Detect Enable for the specified pin.</summary>
    /// <remarks>
    /// When a falling edge is detected, sets the appropriate pin in Event Detect Status.
    /// Asynchronous means the incoming signal is not sampled by the system clock. As such
    /// falling edges of very short duration can be detected.
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_afen(Byte pin)
    {
      _bcm2835_gpio_afen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_clr_afen"
    private delegate void bcm2835_gpio_clr_afen_delegate(Byte pin);
    private void bcm2835_gpio_clr_afen_unresolved(Byte pin) { throw new MissingMethodException(); }
    private bcm2835_gpio_clr_afen_delegate _bcm2835_gpio_clr_afen_method;
    /// <summary>Disable Asynchronous Falling Edge Detect Enable for the specified pin.</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    public void bcm2835_gpio_clr_afen(Byte pin)
    {
      _bcm2835_gpio_clr_afen_method(pin);
    }
    #endregion

    #region "bcm2835_gpio_pud"
    private delegate void bcm2835_gpio_pud_delegate(Byte pud);
    private void bcm2835_gpio_pud_unresolved(Byte pud) { throw new MissingMethodException(); }
    private bcm2835_gpio_pud_delegate _bcm2835_gpio_pud_method;
    /// <summary>Sets the Pull-up/down register for the given pin. This is</summary>
    /// <remarks>
    /// used with bcm2835_gpio_pudclk() to set the Pull-up/down resistor for the given pin.
    /// However, it is usually more convenient to use bcm2835_gpio_set_pud().
    /// (see also) bcm2835_gpio_set_pud()
    /// </remarks>
    /// <param name="pud">The desired Pull-up/down mode. One of BCM2835_GPIO_PUD_* from bcm2835PUDControl</param>
    public void bcm2835_gpio_pud(Byte pud)
    {
      _bcm2835_gpio_pud_method(pud);
    }
    #endregion

    #region "bcm2835_gpio_pudclk"
    private delegate void bcm2835_gpio_pudclk_delegate(Byte pin, Byte on);
    private void bcm2835_gpio_pudclk_unresolved(Byte pin, Byte on) { throw new MissingMethodException(); }
    private bcm2835_gpio_pudclk_delegate _bcm2835_gpio_pudclk_method;
    /// <summary>Clocks the Pull-up/down value set earlier by bcm2835_gpio_pud() into the pin.</summary>
    /// <remarks>
    /// LOW to remove the clock.
    /// (see also) bcm2835_gpio_set_pud()
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <param name="on">HIGH to clock the value from bcm2835_gpio_pud() into the pin.</param>
    public void bcm2835_gpio_pudclk(Byte pin, Byte on)
    {
      _bcm2835_gpio_pudclk_method(pin, on);
    }
    #endregion

    #region "bcm2835_gpio_pad"
    private delegate UInt32 bcm2835_gpio_pad_delegate(Byte group);
    private UInt32 bcm2835_gpio_pad_unresolved(Byte group) { throw new MissingMethodException(); }
    private bcm2835_gpio_pad_delegate _bcm2835_gpio_pad_method;
    /// <summary>Reads and returns the Pad Control for the given GPIO group.</summary>
    /// <param name="group">The GPIO pad group number, one of BCM2835_PAD_GROUP_GPIO_*</param>
    /// <returns>Mask of bits from BCM2835_PAD_* from bcm2835PadGroup</returns>
    public UInt32 bcm2835_gpio_pad(Byte group)
    {
      return _bcm2835_gpio_pad_method(group);
    }
    #endregion

    #region "bcm2835_gpio_set_pad"
    private delegate void bcm2835_gpio_set_pad_delegate(Byte group, UInt32 control);
    private void bcm2835_gpio_set_pad_unresolved(Byte group, UInt32 control) { throw new MissingMethodException(); }
    private bcm2835_gpio_set_pad_delegate _bcm2835_gpio_set_pad_method;
    /// <summary>Sets the Pad Control for the given GPIO group.</summary>
    /// <remarks>
    /// that it is not necessary to include BCM2835_PAD_PASSWRD in the mask as this
    /// is automatically included.
    /// </remarks>
    /// <param name="group">The GPIO pad group number, one of BCM2835_PAD_GROUP_GPIO_*</param>
    /// <param name="control">Mask of bits from BCM2835_PAD_* from bcm2835PadGroup. Note</param>
    public void bcm2835_gpio_set_pad(Byte group, UInt32 control)
    {
      _bcm2835_gpio_set_pad_method(group, control);
    }
    #endregion

    #region "bcm2835_delay"
    private delegate void bcm2835_delay_delegate(UInt32 millis);
    private void bcm2835_delay_unresolved(UInt32 millis) { throw new MissingMethodException(); }
    private bcm2835_delay_delegate _bcm2835_delay_method;
    /// <summary>Delays for the specified number of milliseconds.</summary>
    /// <remarks>
    /// Uses nanosleep(), and therefore does not use CPU until the time is up.
    /// However, you are at the mercy of nanosleep(). From the manual for nanosleep():
    /// If the interval specified in req is not an exact multiple of the granularity
    /// underlying clock (see time(7)), then the interval will be
    /// rounded up to the next multiple. Furthermore, after the sleep completes,
    /// there may still be a delay before the CPU becomes free to once
    /// again execute the calling thread.
    /// </remarks>
    /// <param name="millis">Delay in milliseconds</param>
    public void bcm2835_delay(UInt32 millis)
    {
      _bcm2835_delay_method(millis);
    }
    #endregion

    #region "bcm2835_delayMicroseconds"
    private delegate void bcm2835_delayMicroseconds_delegate(UInt64 micros);
    private void bcm2835_delayMicroseconds_unresolved(UInt64 micros) { throw new MissingMethodException(); }
    private bcm2835_delayMicroseconds_delegate _bcm2835_delayMicroseconds_method;
    /// <summary>Delays for the specified number of microseconds.</summary>
    /// <remarks>
    /// Uses a combination of nanosleep() and a busy wait loop on the BCM2835 system timers,
    /// However, you are at the mercy of nanosleep(). From the manual for nanosleep():
    /// If the interval specified in req is not an exact multiple of the granularity
    /// underlying clock (see time(7)), then the interval will be
    /// rounded up to the next multiple. Furthermore, after the sleep completes,
    /// there may still be a delay before the CPU becomes free to once
    /// again execute the calling thread.
    /// For times less than about 450 microseconds, uses a busy wait on the System Timer.
    /// It is reported that a delay of 0 microseconds on RaspberryPi will in fact
    /// result in a delay of about 80 microseconds. Your mileage may vary.
    /// </remarks>
    /// <param name="micros">Delay in microseconds</param>
    public void bcm2835_delayMicroseconds(UInt64 micros)
    {
      _bcm2835_delayMicroseconds_method(micros);
    }
    #endregion

    #region "bcm2835_gpio_write"
    private delegate void bcm2835_gpio_write_delegate(Byte pin, Byte on);
    private void bcm2835_gpio_write_unresolved(Byte pin, Byte on) { throw new MissingMethodException(); }
    private bcm2835_gpio_write_delegate _bcm2835_gpio_write_method;
    /// <summary>Sets the output state of the specified pin</summary>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <param name="on">HIGH sets the output to HIGH and LOW to LOW.</param>
    public void bcm2835_gpio_write(Byte pin, Byte on)
    {
      _bcm2835_gpio_write_method(pin, on);
    }
    #endregion

    #region "bcm2835_gpio_write_multi"
    private delegate void bcm2835_gpio_write_multi_delegate(UInt32 mask, Byte on);
    private void bcm2835_gpio_write_multi_unresolved(UInt32 mask, Byte on) { throw new MissingMethodException(); }
    private bcm2835_gpio_write_multi_delegate _bcm2835_gpio_write_multi_method;
    /// <summary>Sets any of the first 32 GPIO output pins specified in the mask to the state given by on</summary>
    /// <param name="mask">Mask of pins to affect. Use eg: (1 &lt;&lt; RPI_GPIO_P1_03) | (1 &lt;&lt; RPI_GPIO_P1_05)</param>
    /// <param name="on">HIGH sets the output to HIGH and LOW to LOW.</param>
    public void bcm2835_gpio_write_multi(UInt32 mask, Byte on)
    {
      _bcm2835_gpio_write_multi_method(mask, on);
    }
    #endregion

    #region "bcm2835_gpio_write_mask"
    private delegate void bcm2835_gpio_write_mask_delegate(UInt32 value, UInt32 mask);
    private void bcm2835_gpio_write_mask_unresolved(UInt32 value, UInt32 mask) { throw new MissingMethodException(); }
    private bcm2835_gpio_write_mask_delegate _bcm2835_gpio_write_mask_method;
    /// <summary>Sets the first 32 GPIO output pins specified in the mask to the value given by value</summary>
    /// <param name="value">values required for each bit masked in by mask, eg: (1 &lt;&lt; RPI_GPIO_P1_03) | (1 &lt;&lt; RPI_GPIO_P1_05)</param>
    /// <param name="mask">Mask of pins to affect. Use eg: (1 &lt;&lt; RPI_GPIO_P1_03) | (1 &lt;&lt; RPI_GPIO_P1_05)</param>
    public void bcm2835_gpio_write_mask(UInt32 value, UInt32 mask)
    {
      _bcm2835_gpio_write_mask_method(value, mask);
    }
    #endregion

    #region "bcm2835_gpio_set_pud"
    private delegate void bcm2835_gpio_set_pud_delegate(Byte pin, Byte pud);
    private void bcm2835_gpio_set_pud_unresolved(Byte pin, Byte pud) { throw new MissingMethodException(); }
    private bcm2835_gpio_set_pud_delegate _bcm2835_gpio_set_pud_method;
    /// <summary>Sets the Pull-up/down mode for the specified pin. This is more convenient than</summary>
    /// <remarks>
    /// clocking the mode in with bcm2835_gpio_pud() and bcm2835_gpio_pudclk().
    /// </remarks>
    /// <param name="pin">GPIO number, or one of RPI_GPIO_P1_* from RPiGPIOPin.</param>
    /// <param name="pud">The desired Pull-up/down mode. One of BCM2835_GPIO_PUD_* from bcm2835PUDControl</param>
    public void bcm2835_gpio_set_pud(Byte pin, Byte pud)
    {
      _bcm2835_gpio_set_pud_method(pin, pud);
    }
    #endregion

    #region "bcm2835_spi_begin"
    private delegate void bcm2835_spi_begin_delegate();
    private void bcm2835_spi_begin_unresolved() { throw new MissingMethodException(); }
    private bcm2835_spi_begin_delegate _bcm2835_spi_begin_method;
    /// <summary>Start SPI operations.</summary>
    /// <remarks>
    /// Forces RPi SPI0 pins P1-19 (MOSI), P1-21 (MISO), P1-23 (CLK), P1-24 (CE0) and P1-26 (CE1)
    /// to alternate function ALT0, which enables those pins for SPI interface.
    /// You should call bcm2835_spi_end() when all SPI funcitons are complete to return the pins to
    /// their default functions
    /// (see also) bcm2835_spi_end()
    /// </remarks>
    public void bcm2835_spi_begin()
    {
      _bcm2835_spi_begin_method();
    }
    #endregion

    #region "bcm2835_spi_end"
    private delegate void bcm2835_spi_end_delegate();
    private void bcm2835_spi_end_unresolved() { throw new MissingMethodException(); }
    private bcm2835_spi_end_delegate _bcm2835_spi_end_method;
    /// <summary>End SPI operations.</summary>
    /// <remarks>
    /// SPI0 pins P1-19 (MOSI), P1-21 (MISO), P1-23 (CLK), P1-24 (CE0) and P1-26 (CE1)
    /// are returned to their default INPUT behaviour.
    /// </remarks>
    public void bcm2835_spi_end()
    {
      _bcm2835_spi_end_method();
    }
    #endregion

    #region "bcm2835_spi_setBitOrder"
    private delegate void bcm2835_spi_setBitOrder_delegate(Byte order);
    private void bcm2835_spi_setBitOrder_unresolved(Byte order) { throw new MissingMethodException(); }
    private bcm2835_spi_setBitOrder_delegate _bcm2835_spi_setBitOrder_method;
    /// <summary>Sets the SPI bit order</summary>
    /// <remarks>
    /// NOTE: has no effect. Not supported by SPI0.
    /// Defaults to
    /// see bcm2835SPIBitOrder
    /// </remarks>
    /// <param name="order">The desired bit order, one of BCM2835_SPI_BIT_ORDER_*,</param>
    public void bcm2835_spi_setBitOrder(Byte order)
    {
      _bcm2835_spi_setBitOrder_method(order);
    }
    #endregion

    #region "bcm2835_spi_setClockDivider"
    private delegate void bcm2835_spi_setClockDivider_delegate(UInt16 divider);
    private void bcm2835_spi_setClockDivider_unresolved(UInt16 divider) { throw new MissingMethodException(); }
    private bcm2835_spi_setClockDivider_delegate _bcm2835_spi_setClockDivider_method;
    /// <summary>Sets the SPI clock divider and therefore the</summary>
    /// <remarks>
    /// SPI clock speed.
    /// see bcm2835SPIClockDivider
    /// </remarks>
    /// <param name="divider">The desired SPI clock divider, one of BCM2835_SPI_CLOCK_DIVIDER_*,</param>
    public void bcm2835_spi_setClockDivider(UInt16 divider)
    {
      _bcm2835_spi_setClockDivider_method(divider);
    }
    #endregion

    #region "bcm2835_spi_setDataMode"
    private delegate void bcm2835_spi_setDataMode_delegate(Byte mode);
    private void bcm2835_spi_setDataMode_unresolved(Byte mode) { throw new MissingMethodException(); }
    private bcm2835_spi_setDataMode_delegate _bcm2835_spi_setDataMode_method;
    /// <summary>Sets the SPI data mode</summary>
    /// <remarks>
    /// Sets the clock polariy and phase
    /// see bcm2835SPIMode
    /// </remarks>
    /// <param name="mode">The desired data mode, one of BCM2835_SPI_MODE*,</param>
    public void bcm2835_spi_setDataMode(Byte mode)
    {
      _bcm2835_spi_setDataMode_method(mode);
    }
    #endregion

    #region "bcm2835_spi_chipSelect"
    private delegate void bcm2835_spi_chipSelect_delegate(Byte cs);
    private void bcm2835_spi_chipSelect_unresolved(Byte cs) { throw new MissingMethodException(); }
    private bcm2835_spi_chipSelect_delegate _bcm2835_spi_chipSelect_method;
    /// <summary>Sets the chip select pin(s)</summary>
    /// <remarks>
    /// When an bcm2835_spi_transfer() is made, the selected pin(s) will be asserted during the
    /// transfer.
    /// One of BCM2835_SPI_CS*, see bcm2835SPIChipSelect
    /// </remarks>
    /// <param name="cs">Specifies the CS pins(s) that are used to activate the desired slave.</param>
    public void bcm2835_spi_chipSelect(Byte cs)
    {
      _bcm2835_spi_chipSelect_method(cs);
    }
    #endregion

    #region "bcm2835_spi_setChipSelectPolarity"
    private delegate void bcm2835_spi_setChipSelectPolarity_delegate(Byte cs, Byte active);
    private void bcm2835_spi_setChipSelectPolarity_unresolved(Byte cs, Byte active) { throw new MissingMethodException(); }
    private bcm2835_spi_setChipSelectPolarity_delegate _bcm2835_spi_setChipSelectPolarity_method;
    /// <summary>Sets the chip select pin polarity for a given pin</summary>
    /// <remarks>
    /// When an bcm2835_spi_transfer() occurs, the currently selected chip select pin(s)
    /// will be asserted to the
    /// value given by active. When transfers are not happening, the chip select pin(s)
    /// return to the complement (inactive) value.
    /// </remarks>
    /// <param name="cs">The chip select pin to affect</param>
    /// <param name="active">Whether the chip select pin is to be active HIGH</param>
    public void bcm2835_spi_setChipSelectPolarity(Byte cs, Byte active)
    {
      _bcm2835_spi_setChipSelectPolarity_method(cs, active);
    }
    #endregion

    #region "bcm2835_spi_transfer"
    private delegate Byte bcm2835_spi_transfer_delegate(Byte value);
    private Byte bcm2835_spi_transfer_unresolved(Byte value) { throw new MissingMethodException(); }
    private bcm2835_spi_transfer_delegate _bcm2835_spi_transfer_method;
    /// <summary>Transfers one byte to and from the currently selected SPI slave.</summary>
    /// <remarks>
    /// Asserts the currently selected CS pins (as previously set by bcm2835_spi_chipSelect)
    /// during the transfer.
    /// Clocks the 8 bit value out on MOSI, and simultaneously clocks in data from MISO.
    /// Returns the read data byte from the slave.
    /// Uses polled transfer as per section 10.6.1 of the BCM 2835 ARM Peripherls manual
    /// (see also) bcm2835_spi_transfern()
    /// </remarks>
    /// <param name="value">The 8 bit data byte to write to MOSI</param>
    /// <returns>The 8 bit byte simultaneously read from MISO</returns>
    public Byte bcm2835_spi_transfer(Byte value)
    {
      return _bcm2835_spi_transfer_method(value);
    }
    #endregion

    #region "bcm2835_spi_transfernb"
    private delegate void bcm2835_spi_transfernb_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] tbuf, [MarshalAs(UnmanagedType.LPArray)]byte[] rbuf, UInt32 len);
    private void bcm2835_spi_transfernb_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] tbuf, [MarshalAs(UnmanagedType.LPArray)]byte[] rbuf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_spi_transfernb_delegate _bcm2835_spi_transfernb_method;
    /// <summary>Transfers any number of bytes to and from the currently selected SPI slave.</summary>
    /// <remarks>
    /// Asserts the currently selected CS pins (as previously set by bcm2835_spi_chipSelect)
    /// during the transfer.
    /// Clocks the len 8 bit bytes out on MOSI, and simultaneously clocks in data from MISO.
    /// The data read read from the slave is placed into rbuf. rbuf must be at least len bytes long
    /// Uses polled transfer as per section 10.6.1 of the BCM 2835 ARM Peripherls manual
    /// \param[out] rbuf Received bytes will by put in this buffer
    /// (see also) bcm2835_spi_transfer()
    /// </remarks>
    /// <param name="tbuf">Buffer of bytes to send.</param>
    /// <param name="len">Number of bytes in the tbuf buffer, and the number of bytes to send/received</param>
    public void bcm2835_spi_transfernb([MarshalAs(UnmanagedType.LPArray)]byte[] tbuf, [MarshalAs(UnmanagedType.LPArray)]byte[] rbuf, UInt32 len)
    {
      _bcm2835_spi_transfernb_method(tbuf, rbuf, len);
    }
    #endregion

    #region "bcm2835_spi_transfern"
    private delegate void bcm2835_spi_transfern_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len);
    private void bcm2835_spi_transfern_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_spi_transfern_delegate _bcm2835_spi_transfern_method;
    /// <summary>Transfers any number of bytes to and from the currently selected SPI slave</summary>
    /// <remarks>
    /// using bcm2835_spi_transfernb.
    /// The returned data from the slave replaces the transmitted data in the buffer.
    /// \param[in,out] buf Buffer of bytes to send. Received bytes will replace the contents
    /// (see also) bcm2835_spi_transfer()
    /// </remarks>
    /// <param name="len">Number of bytes int eh buffer, and the number of bytes to send/received</param>
    public void bcm2835_spi_transfern([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len)
    {
      _bcm2835_spi_transfern_method(buf, len);
    }
    #endregion

    #region "bcm2835_spi_writenb"
    private delegate void bcm2835_spi_writenb_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len);
    private void bcm2835_spi_writenb_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_spi_writenb_delegate _bcm2835_spi_writenb_method;
    /// <summary>Transfers any number of bytes to the currently selected SPI slave.</summary>
    /// <remarks>
    /// Asserts the currently selected CS pins (as previously set by bcm2835_spi_chipSelect)
    /// during the transfer.
    /// </remarks>
    /// <param name="buf">Buffer of bytes to send.</param>
    /// <param name="len">Number of bytes in the tbuf buffer, and the number of bytes to send</param>
    public void bcm2835_spi_writenb([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len)
    {
      _bcm2835_spi_writenb_method(buf, len);
    }
    #endregion

    #region "bcm2835_i2c_begin"
    private delegate void bcm2835_i2c_begin_delegate();
    private void bcm2835_i2c_begin_unresolved() { throw new MissingMethodException(); }
    private bcm2835_i2c_begin_delegate _bcm2835_i2c_begin_method;
    /// <summary>Start I2C operations.</summary>
    /// <remarks>
    /// Forces RPi I2C pins P1-03 (SDA) and P1-05 (SCL)
    /// to alternate function ALT0, which enables those pins for I2C interface.
    /// You should call bcm2835_i2c_end() when all I2C functions are complete to return the pins to
    /// their default functions
    /// (see also) bcm2835_i2c_end()
    /// </remarks>
    public void bcm2835_i2c_begin()
    {
      _bcm2835_i2c_begin_method();
    }
    #endregion

    #region "bcm2835_i2c_end"
    private delegate void bcm2835_i2c_end_delegate();
    private void bcm2835_i2c_end_unresolved() { throw new MissingMethodException(); }
    private bcm2835_i2c_end_delegate _bcm2835_i2c_end_method;
    /// <summary>End I2C operations.</summary>
    /// <remarks>
    /// I2C pins P1-03 (SDA) and P1-05 (SCL)
    /// are returned to their default INPUT behaviour.
    /// </remarks>
    public void bcm2835_i2c_end()
    {
      _bcm2835_i2c_end_method();
    }
    #endregion

    #region "bcm2835_i2c_setSlaveAddress"
    private delegate void bcm2835_i2c_setSlaveAddress_delegate(Byte addr);
    private void bcm2835_i2c_setSlaveAddress_unresolved(Byte addr) { throw new MissingMethodException(); }
    private bcm2835_i2c_setSlaveAddress_delegate _bcm2835_i2c_setSlaveAddress_method;
    /// <summary>Sets the I2C slave address.</summary>
    /// <param name="addr">The I2C slave address.</param>
    public void bcm2835_i2c_setSlaveAddress(Byte addr)
    {
      _bcm2835_i2c_setSlaveAddress_method(addr);
    }
    #endregion

    #region "bcm2835_i2c_setClockDivider"
    private delegate void bcm2835_i2c_setClockDivider_delegate(UInt16 divider);
    private void bcm2835_i2c_setClockDivider_unresolved(UInt16 divider) { throw new MissingMethodException(); }
    private bcm2835_i2c_setClockDivider_delegate _bcm2835_i2c_setClockDivider_method;
    /// <summary>Sets the I2C clock divider and therefore the I2C clock speed.</summary>
    /// <remarks>
    /// see bcm2835I2CClockDivider
    /// </remarks>
    /// <param name="divider">The desired I2C clock divider, one of BCM2835_I2C_CLOCK_DIVIDER_*,</param>
    public void bcm2835_i2c_setClockDivider(UInt16 divider)
    {
      _bcm2835_i2c_setClockDivider_method(divider);
    }
    #endregion

    #region "bcm2835_i2c_set_baudrate"
    private delegate void bcm2835_i2c_set_baudrate_delegate(UInt32 baudrate);
    private void bcm2835_i2c_set_baudrate_unresolved(UInt32 baudrate) { throw new MissingMethodException(); }
    private bcm2835_i2c_set_baudrate_delegate _bcm2835_i2c_set_baudrate_method;
    /// <summary>Sets the I2C clock divider by converting the baudrate parameter to</summary>
    /// <remarks>
    /// the equivalent I2C clock divider. ( see (see also) bcm2835_i2c_setClockDivider)
    /// For the I2C standard 100khz you would set baudrate to 100000
    /// The use of baudrate corresponds to its use in the I2C kernel device
    /// driver. (Of course, bcm2835 has nothing to do with the kernel driver)
    /// </remarks>
    public void bcm2835_i2c_set_baudrate(UInt32 baudrate)
    {
      _bcm2835_i2c_set_baudrate_method(baudrate);
    }
    #endregion

    #region "bcm2835_i2c_write"
    private delegate Byte bcm2835_i2c_write_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len);
    private Byte bcm2835_i2c_write_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_i2c_write_delegate _bcm2835_i2c_write_method;
    /// <summary>Transfers any number of bytes to the currently selected I2C slave.</summary>
    /// <remarks>
    /// (as previously set by (see also) bcm2835_i2c_setSlaveAddress)
    /// </remarks>
    /// <param name="buf">Buffer of bytes to send.</param>
    /// <param name="len">Number of bytes in the buf buffer, and the number of bytes to send.</param>
    /// <returns>reason see bcm2835I2CReasonCodes</returns>
    public Byte bcm2835_i2c_write([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len)
    {
      return _bcm2835_i2c_write_method(buf, len);
    }
    #endregion

    #region "bcm2835_i2c_read"
    private delegate Byte bcm2835_i2c_read_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len);
    private Byte bcm2835_i2c_read_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_i2c_read_delegate _bcm2835_i2c_read_method;
    /// <summary>Transfers any number of bytes from the currently selected I2C slave.</summary>
    /// <remarks>
    /// (as previously set by (see also) bcm2835_i2c_setSlaveAddress)
    /// </remarks>
    /// <param name="buf">Buffer of bytes to receive.</param>
    /// <param name="len">Number of bytes in the buf buffer, and the number of bytes to received.</param>
    /// <returns>reason see bcm2835I2CReasonCodes</returns>
    public Byte bcm2835_i2c_read([MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len)
    {
      return _bcm2835_i2c_read_method(buf, len);
    }
    #endregion

    #region "bcm2835_i2c_read_register_rs"
    private delegate Byte bcm2835_i2c_read_register_rs_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] regaddr, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len);
    private Byte bcm2835_i2c_read_register_rs_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] regaddr, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len) { throw new MissingMethodException(); }
    private bcm2835_i2c_read_register_rs_delegate _bcm2835_i2c_read_register_rs_method;
    /// <summary>Allows reading from I2C slaves that require a repeated start (without any prior stop)</summary>
    /// <remarks>
    /// to read after the required slave register has been set. For example, the popular
    /// MPL3115A2 pressure and temperature sensor. Note that your device must support or
    /// require this mode. If your device does not require this mode then the standard
    /// combined:
    /// (see also) bcm2835_i2c_write
    /// (see also) bcm2835_i2c_read
    /// are a better choice.
    /// Will read from the slave previously set by (see also) bcm2835_i2c_setSlaveAddress
    /// </remarks>
    /// <param name="regaddr">Buffer containing the slave register you wish to read from.</param>
    /// <param name="buf">Buffer of bytes to receive.</param>
    /// <param name="len">Number of bytes in the buf buffer, and the number of bytes to received.</param>
    /// <returns>reason see bcm2835I2CReasonCodes</returns>
    public Byte bcm2835_i2c_read_register_rs([MarshalAs(UnmanagedType.LPArray)]byte[] regaddr, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 len)
    {
      return _bcm2835_i2c_read_register_rs_method(regaddr, buf, len);
    }
    #endregion

    #region "bcm2835_i2c_write_read_rs"
    private delegate Byte bcm2835_i2c_write_read_rs_delegate([MarshalAs(UnmanagedType.LPArray)]byte[] cmds, UInt32 cmds_len, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 buf_len);
    private Byte bcm2835_i2c_write_read_rs_unresolved([MarshalAs(UnmanagedType.LPArray)]byte[] cmds, UInt32 cmds_len, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 buf_len) { throw new MissingMethodException(); }
    private bcm2835_i2c_write_read_rs_delegate _bcm2835_i2c_write_read_rs_method;
    /// <summary>Allows sending an arbitrary number of bytes to I2C slaves before issuing a repeated</summary>
    /// <remarks>
    /// start (with no prior stop) and reading a response.
    /// Necessary for devices that require such behavior, such as the MLX90620.
    /// Will write to and read from the slave previously set by (see also) bcm2835_i2c_setSlaveAddress
    /// </remarks>
    /// <param name="cmds">Buffer containing the bytes to send before the repeated start condition.</param>
    /// <param name="cmds_len">Number of bytes to send from cmds buffer</param>
    /// <param name="buf">Buffer of bytes to receive.</param>
    /// <param name="buf_len">Number of bytes to receive in the buf buffer.</param>
    /// <returns>reason see bcm2835I2CReasonCodes</returns>
    public Byte bcm2835_i2c_write_read_rs([MarshalAs(UnmanagedType.LPArray)]byte[] cmds, UInt32 cmds_len, [MarshalAs(UnmanagedType.LPArray)]byte[] buf, UInt32 buf_len)
    {
      return _bcm2835_i2c_write_read_rs_method(cmds, cmds_len, buf, buf_len);
    }
    #endregion

    #region "bcm2835_st_read"
    private delegate UInt64 bcm2835_st_read_delegate();
    private UInt64 bcm2835_st_read_unresolved() { throw new MissingMethodException(); }
    private bcm2835_st_read_delegate _bcm2835_st_read_method;
    /// <summary>Read the System Timer Counter register.</summary>
    /// <returns>the value read from the System Timer Counter Lower 32 bits register</returns>
    public UInt64 bcm2835_st_read()
    {
      return _bcm2835_st_read_method();
    }
    #endregion

    #region "bcm2835_st_delay"
    private delegate void bcm2835_st_delay_delegate(UInt64 offset_micros, UInt64 micros);
    private void bcm2835_st_delay_unresolved(UInt64 offset_micros, UInt64 micros) { throw new MissingMethodException(); }
    private bcm2835_st_delay_delegate _bcm2835_st_delay_method;
    /// <summary>Delays for the specified number of microseconds with offset.</summary>
    /// <param name="offset_micros">Offset in microseconds</param>
    /// <param name="micros">Delay in microseconds</param>
    public void bcm2835_st_delay(UInt64 offset_micros, UInt64 micros)
    {
      _bcm2835_st_delay_method(offset_micros, micros);
    }
    #endregion

    #region "bcm2835_pwm_set_clock"
    private delegate void bcm2835_pwm_set_clock_delegate(UInt32 divisor);
    private void bcm2835_pwm_set_clock_unresolved(UInt32 divisor) { throw new MissingMethodException(); }
    private bcm2835_pwm_set_clock_delegate _bcm2835_pwm_set_clock_method;
    /// <summary>Sets the PWM clock divisor,</summary>
    /// <remarks>
    /// to control the basic PWM pulse widths.
    /// values BCM2835_PWM_CLOCK_DIVIDER_* in bcm2835PWMClockDivider
    /// </remarks>
    /// <param name="divisor">Divides the basic 19.2MHz PWM clock. You can use one of the common</param>
    public void bcm2835_pwm_set_clock(UInt32 divisor)
    {
      _bcm2835_pwm_set_clock_method(divisor);
    }
    #endregion

    #region "bcm2835_pwm_set_mode"
    private delegate void bcm2835_pwm_set_mode_delegate(Byte channel, Byte markspace, Byte enabled);
    private void bcm2835_pwm_set_mode_unresolved(Byte channel, Byte markspace, Byte enabled) { throw new MissingMethodException(); }
    private bcm2835_pwm_set_mode_delegate _bcm2835_pwm_set_mode_method;
    /// <summary>Sets the mode of the given PWM channel,</summary>
    /// <remarks>
    /// allowing you to control the PWM mode and enable/disable that channel
    /// </remarks>
    /// <param name="channel">The PWM channel. 0 or 1.</param>
    /// <param name="markspace">Set true if you want Mark-Space mode. 0 for Balanced mode.</param>
    /// <param name="enabled">Set true to enable this channel and produce PWM pulses.</param>
    public void bcm2835_pwm_set_mode(Byte channel, Byte markspace, Byte enabled)
    {
      _bcm2835_pwm_set_mode_method(channel, markspace, enabled);
    }
    #endregion

    #region "bcm2835_pwm_set_range"
    private delegate void bcm2835_pwm_set_range_delegate(Byte channel, UInt32 range);
    private void bcm2835_pwm_set_range_unresolved(Byte channel, UInt32 range) { throw new MissingMethodException(); }
    private bcm2835_pwm_set_range_delegate _bcm2835_pwm_set_range_method;
    /// <summary>Sets the maximum range of the PWM output.</summary>
    /// <remarks>
    /// The data value can vary between 0 and this range to control PWM output
    /// </remarks>
    /// <param name="channel">The PWM channel. 0 or 1.</param>
    /// <param name="range">The maximum value permitted for DATA.</param>
    public void bcm2835_pwm_set_range(Byte channel, UInt32 range)
    {
      _bcm2835_pwm_set_range_method(channel, range);
    }
    #endregion

    #region "bcm2835_pwm_set_data"
    private delegate void bcm2835_pwm_set_data_delegate(Byte channel, UInt32 data);
    private void bcm2835_pwm_set_data_unresolved(Byte channel, UInt32 data) { throw new MissingMethodException(); }
    private bcm2835_pwm_set_data_delegate _bcm2835_pwm_set_data_method;
    /// <summary>Sets the PWM pulse ratio to emit to DATA/RANGE,</summary>
    /// <remarks>
    /// where RANGE is set by bcm2835_pwm_set_range().
    /// Can vary from 0 to RANGE.
    /// </remarks>
    /// <param name="channel">The PWM channel. 0 or 1.</param>
    /// <param name="data">Controls the PWM output ratio as a fraction of the range.</param>
    public void bcm2835_pwm_set_data(Byte channel, UInt32 data)
    {
      _bcm2835_pwm_set_data_method(channel, data);
    }
    #endregion


    #endregion

    #region "Delegate Initializer"
    private void InitializeDelegates()
    {
      _bcm2835_init_method = GetDelegate<bcm2835_init_delegate>("bcm2835_init", bcm2835_init_unresolved);
      _bcm2835_close_method = GetDelegate<bcm2835_close_delegate>("bcm2835_close", bcm2835_close_unresolved);
      _bcm2835_set_debug_method = GetDelegate<bcm2835_set_debug_delegate>("bcm2835_set_debug", bcm2835_set_debug_unresolved);
      _bcm2835_regbase_method = GetDelegate<bcm2835_regbase_delegate>("bcm2835_regbase", bcm2835_regbase_unresolved);
      _bcm2835_peri_read_method = GetDelegate<bcm2835_peri_read_delegate>("bcm2835_peri_read", bcm2835_peri_read_unresolved);
      _bcm2835_peri_read_nb_method = GetDelegate<bcm2835_peri_read_nb_delegate>("bcm2835_peri_read_nb", bcm2835_peri_read_nb_unresolved);
      _bcm2835_peri_write_method = GetDelegate<bcm2835_peri_write_delegate>("bcm2835_peri_write", bcm2835_peri_write_unresolved);
      _bcm2835_peri_write_nb_method = GetDelegate<bcm2835_peri_write_nb_delegate>("bcm2835_peri_write_nb", bcm2835_peri_write_nb_unresolved);
      _bcm2835_peri_set_bits_method = GetDelegate<bcm2835_peri_set_bits_delegate>("bcm2835_peri_set_bits", bcm2835_peri_set_bits_unresolved);
      _bcm2835_gpio_fsel_method = GetDelegate<bcm2835_gpio_fsel_delegate>("bcm2835_gpio_fsel", bcm2835_gpio_fsel_unresolved);
      _bcm2835_gpio_set_method = GetDelegate<bcm2835_gpio_set_delegate>("bcm2835_gpio_set", bcm2835_gpio_set_unresolved);
      _bcm2835_gpio_clr_method = GetDelegate<bcm2835_gpio_clr_delegate>("bcm2835_gpio_clr", bcm2835_gpio_clr_unresolved);
      _bcm2835_gpio_set_multi_method = GetDelegate<bcm2835_gpio_set_multi_delegate>("bcm2835_gpio_set_multi", bcm2835_gpio_set_multi_unresolved);
      _bcm2835_gpio_clr_multi_method = GetDelegate<bcm2835_gpio_clr_multi_delegate>("bcm2835_gpio_clr_multi", bcm2835_gpio_clr_multi_unresolved);
      _bcm2835_gpio_lev_method = GetDelegate<bcm2835_gpio_lev_delegate>("bcm2835_gpio_lev", bcm2835_gpio_lev_unresolved);
      _bcm2835_gpio_eds_method = GetDelegate<bcm2835_gpio_eds_delegate>("bcm2835_gpio_eds", bcm2835_gpio_eds_unresolved);
      _bcm2835_gpio_set_eds_method = GetDelegate<bcm2835_gpio_set_eds_delegate>("bcm2835_gpio_set_eds", bcm2835_gpio_set_eds_unresolved);
      _bcm2835_gpio_ren_method = GetDelegate<bcm2835_gpio_ren_delegate>("bcm2835_gpio_ren", bcm2835_gpio_ren_unresolved);
      _bcm2835_gpio_clr_ren_method = GetDelegate<bcm2835_gpio_clr_ren_delegate>("bcm2835_gpio_clr_ren", bcm2835_gpio_clr_ren_unresolved);
      _bcm2835_gpio_fen_method = GetDelegate<bcm2835_gpio_fen_delegate>("bcm2835_gpio_fen", bcm2835_gpio_fen_unresolved);
      _bcm2835_gpio_clr_fen_method = GetDelegate<bcm2835_gpio_clr_fen_delegate>("bcm2835_gpio_clr_fen", bcm2835_gpio_clr_fen_unresolved);
      _bcm2835_gpio_hen_method = GetDelegate<bcm2835_gpio_hen_delegate>("bcm2835_gpio_hen", bcm2835_gpio_hen_unresolved);
      _bcm2835_gpio_clr_hen_method = GetDelegate<bcm2835_gpio_clr_hen_delegate>("bcm2835_gpio_clr_hen", bcm2835_gpio_clr_hen_unresolved);
      _bcm2835_gpio_len_method = GetDelegate<bcm2835_gpio_len_delegate>("bcm2835_gpio_len", bcm2835_gpio_len_unresolved);
      _bcm2835_gpio_clr_len_method = GetDelegate<bcm2835_gpio_clr_len_delegate>("bcm2835_gpio_clr_len", bcm2835_gpio_clr_len_unresolved);
      _bcm2835_gpio_aren_method = GetDelegate<bcm2835_gpio_aren_delegate>("bcm2835_gpio_aren", bcm2835_gpio_aren_unresolved);
      _bcm2835_gpio_clr_aren_method = GetDelegate<bcm2835_gpio_clr_aren_delegate>("bcm2835_gpio_clr_aren", bcm2835_gpio_clr_aren_unresolved);
      _bcm2835_gpio_afen_method = GetDelegate<bcm2835_gpio_afen_delegate>("bcm2835_gpio_afen", bcm2835_gpio_afen_unresolved);
      _bcm2835_gpio_clr_afen_method = GetDelegate<bcm2835_gpio_clr_afen_delegate>("bcm2835_gpio_clr_afen", bcm2835_gpio_clr_afen_unresolved);
      _bcm2835_gpio_pud_method = GetDelegate<bcm2835_gpio_pud_delegate>("bcm2835_gpio_pud", bcm2835_gpio_pud_unresolved);
      _bcm2835_gpio_pudclk_method = GetDelegate<bcm2835_gpio_pudclk_delegate>("bcm2835_gpio_pudclk", bcm2835_gpio_pudclk_unresolved);
      _bcm2835_gpio_pad_method = GetDelegate<bcm2835_gpio_pad_delegate>("bcm2835_gpio_pad", bcm2835_gpio_pad_unresolved);
      _bcm2835_gpio_set_pad_method = GetDelegate<bcm2835_gpio_set_pad_delegate>("bcm2835_gpio_set_pad", bcm2835_gpio_set_pad_unresolved);
      _bcm2835_delay_method = GetDelegate<bcm2835_delay_delegate>("bcm2835_delay", bcm2835_delay_unresolved);
      _bcm2835_delayMicroseconds_method = GetDelegate<bcm2835_delayMicroseconds_delegate>("bcm2835_delayMicroseconds", bcm2835_delayMicroseconds_unresolved);
      _bcm2835_gpio_write_method = GetDelegate<bcm2835_gpio_write_delegate>("bcm2835_gpio_write", bcm2835_gpio_write_unresolved);
      _bcm2835_gpio_write_multi_method = GetDelegate<bcm2835_gpio_write_multi_delegate>("bcm2835_gpio_write_multi", bcm2835_gpio_write_multi_unresolved);
      _bcm2835_gpio_write_mask_method = GetDelegate<bcm2835_gpio_write_mask_delegate>("bcm2835_gpio_write_mask", bcm2835_gpio_write_mask_unresolved);
      _bcm2835_gpio_set_pud_method = GetDelegate<bcm2835_gpio_set_pud_delegate>("bcm2835_gpio_set_pud", bcm2835_gpio_set_pud_unresolved);
      _bcm2835_spi_begin_method = GetDelegate<bcm2835_spi_begin_delegate>("bcm2835_spi_begin", bcm2835_spi_begin_unresolved);
      _bcm2835_spi_end_method = GetDelegate<bcm2835_spi_end_delegate>("bcm2835_spi_end", bcm2835_spi_end_unresolved);
      _bcm2835_spi_setBitOrder_method = GetDelegate<bcm2835_spi_setBitOrder_delegate>("bcm2835_spi_setBitOrder", bcm2835_spi_setBitOrder_unresolved);
      _bcm2835_spi_setClockDivider_method = GetDelegate<bcm2835_spi_setClockDivider_delegate>("bcm2835_spi_setClockDivider", bcm2835_spi_setClockDivider_unresolved);
      _bcm2835_spi_setDataMode_method = GetDelegate<bcm2835_spi_setDataMode_delegate>("bcm2835_spi_setDataMode", bcm2835_spi_setDataMode_unresolved);
      _bcm2835_spi_chipSelect_method = GetDelegate<bcm2835_spi_chipSelect_delegate>("bcm2835_spi_chipSelect", bcm2835_spi_chipSelect_unresolved);
      _bcm2835_spi_setChipSelectPolarity_method = GetDelegate<bcm2835_spi_setChipSelectPolarity_delegate>("bcm2835_spi_setChipSelectPolarity", bcm2835_spi_setChipSelectPolarity_unresolved);
      _bcm2835_spi_transfer_method = GetDelegate<bcm2835_spi_transfer_delegate>("bcm2835_spi_transfer", bcm2835_spi_transfer_unresolved);
      _bcm2835_spi_transfernb_method = GetDelegate<bcm2835_spi_transfernb_delegate>("bcm2835_spi_transfernb", bcm2835_spi_transfernb_unresolved);
      _bcm2835_spi_transfern_method = GetDelegate<bcm2835_spi_transfern_delegate>("bcm2835_spi_transfern", bcm2835_spi_transfern_unresolved);
      _bcm2835_spi_writenb_method = GetDelegate<bcm2835_spi_writenb_delegate>("bcm2835_spi_writenb", bcm2835_spi_writenb_unresolved);
      _bcm2835_i2c_begin_method = GetDelegate<bcm2835_i2c_begin_delegate>("bcm2835_i2c_begin", bcm2835_i2c_begin_unresolved);
      _bcm2835_i2c_end_method = GetDelegate<bcm2835_i2c_end_delegate>("bcm2835_i2c_end", bcm2835_i2c_end_unresolved);
      _bcm2835_i2c_setSlaveAddress_method = GetDelegate<bcm2835_i2c_setSlaveAddress_delegate>("bcm2835_i2c_setSlaveAddress", bcm2835_i2c_setSlaveAddress_unresolved);
      _bcm2835_i2c_setClockDivider_method = GetDelegate<bcm2835_i2c_setClockDivider_delegate>("bcm2835_i2c_setClockDivider", bcm2835_i2c_setClockDivider_unresolved);
      _bcm2835_i2c_set_baudrate_method = GetDelegate<bcm2835_i2c_set_baudrate_delegate>("bcm2835_i2c_set_baudrate", bcm2835_i2c_set_baudrate_unresolved);
      _bcm2835_i2c_write_method = GetDelegate<bcm2835_i2c_write_delegate>("bcm2835_i2c_write", bcm2835_i2c_write_unresolved);
      _bcm2835_i2c_read_method = GetDelegate<bcm2835_i2c_read_delegate>("bcm2835_i2c_read", bcm2835_i2c_read_unresolved);
      _bcm2835_i2c_read_register_rs_method = GetDelegate<bcm2835_i2c_read_register_rs_delegate>("bcm2835_i2c_read_register_rs", bcm2835_i2c_read_register_rs_unresolved);
      _bcm2835_i2c_write_read_rs_method = GetDelegate<bcm2835_i2c_write_read_rs_delegate>("bcm2835_i2c_write_read_rs", bcm2835_i2c_write_read_rs_unresolved);
      _bcm2835_st_read_method = GetDelegate<bcm2835_st_read_delegate>("bcm2835_st_read", bcm2835_st_read_unresolved);
      _bcm2835_st_delay_method = GetDelegate<bcm2835_st_delay_delegate>("bcm2835_st_delay", bcm2835_st_delay_unresolved);
      _bcm2835_pwm_set_clock_method = GetDelegate<bcm2835_pwm_set_clock_delegate>("bcm2835_pwm_set_clock", bcm2835_pwm_set_clock_unresolved);
      _bcm2835_pwm_set_mode_method = GetDelegate<bcm2835_pwm_set_mode_delegate>("bcm2835_pwm_set_mode", bcm2835_pwm_set_mode_unresolved);
      _bcm2835_pwm_set_range_method = GetDelegate<bcm2835_pwm_set_range_delegate>("bcm2835_pwm_set_range", bcm2835_pwm_set_range_unresolved);
      _bcm2835_pwm_set_data_method = GetDelegate<bcm2835_pwm_set_data_delegate>("bcm2835_pwm_set_data", bcm2835_pwm_set_data_unresolved);

    }
    #endregion

  }
}
