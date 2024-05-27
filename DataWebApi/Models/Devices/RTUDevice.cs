using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.IO.Ports;
using System.Net.Sockets;
using S7.Net;
using System.Net;
using NModbus.Extensions.Enron;
using Modbus;
using Modbus.Device;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Modbus.Extensions.Enron;

namespace DataWebApi.Models.Devices
{
    public class RTUDevice : BaseDevice
    {
        private byte slaveId;
        private int port;
        private TcpClient tcpClient;
        private ModbusIpMaster master;

        public RTUDevice(int id, string ipAddress, byte slaveId, List<Register> registers) : base(id, ipAddress, registers)
        {
            //modbus icin gerekli
            port = 502;
            this.slaveId = slaveId;
        }
        public RTUDevice(string ipAddress, byte slaveId, List<Register> registers) : base(ipAddress, registers)
        {
            //modbus icin gerekli
            port = 502;
            this.slaveId = slaveId;
        }
        public RTUDevice()
        {

        }

        /// <summary>
        /// 13300-40001
        /// </summary>
        public void ConnectRTU()
        {
            tcpClient = new TcpClient(ipAddress, port);
            master = ModbusIpMaster.CreateIp(tcpClient);
        }

        public void DisconnectRTU()
        {
            tcpClient.Close();

        }

        public override void ReadRegisters()
        {
            ConnectRTU();
            if (tcpClient.Connected)
            {
                foreach (var register in registers)
                {
                    try
                    {
                        if (register.IsReadable())
                        {
                            register.SetValue(master.ReadHoldingRegisters(slaveId, Convert.ToUInt16(register.address) ,1));
                            db.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }

                }
            }
            DisconnectRTU();
        }

        public override void WriteRegister(string address, object value)
        {
            ConnectRTU();
            if (tcpClient.Connected)
            {
                foreach (var register in registers)
                {
                    if (register.address == address && register.IsWritable())
                    {
                        try
                        {
                            master.WriteSingleRegister(slaveId,Convert.ToUInt16(register.address), Convert.ToUInt16(value));
                            register.SetValue(value);
                            db.SaveChanges();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.Message);
                        }
                    }
                }
            }
            DisconnectRTU();
        }

        private float GetFloat(ushort P1, ushort P2)
        {
            int intSign, intSignRest, intExponent, intExponentRest;
            float faResult, faDigit;
            intSign = P1 / 32768;
            intSignRest = P1 % 32768;
            intExponent = intSignRest / 128;
            intExponentRest = intSignRest % 128;
            faDigit = (float)(intExponentRest * 65536 + P2) / 8388608;
            faResult = (float)Math.Pow(-1, intSign) * (float)Math.Pow(2, intExponent - 127) * (faDigit + 1);
            return faResult;
        }
    }
}
