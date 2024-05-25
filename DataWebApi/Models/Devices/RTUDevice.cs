using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using NModbus;
//using NModbus.Serial;
using System;
using System.IO.Ports;
//using NModbus.Device;
using System.Net.Sockets;
using S7.Net;
using EasyModbus;
using static EasyModbus.ModbusServer;
using System.Net;
//using NModbus.Extensions.Enron;
using System.Text;

namespace DataWebApi.Models.Devices
{
    public class RTUDevice : BaseDevice
    {
        private int port;
        private EasyModbus.ModbusClient modbusClient;
        public RTUDevice(string ipAddress, List<Register> registers) : base(ipAddress, registers)
        {
            //modbus icin gerekli
            port = 502;
            modbusClient = new EasyModbus.ModbusClient(ipAddress, port);
        }
        public RTUDevice()
        {
            
        }

        public void ConnectRTU()
        {
            modbusClient.Connect();
        }

        public void DisconnectRTU()
        {
            modbusClient.Disconnect();
        }

        public override void ReadRegisters()
        {
            ConnectRTU();
            if (modbusClient.Connected)
            {
                foreach (var register in registers)
                {
                    try
                    {
                        if (register.IsReadable())
                        {
                            register.SetValue(modbusClient.ReadHoldingRegisters(Convert.ToInt32(register.address), 1)[0]);
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

        public override void WriteRegister(string address,object value)
        {
            ConnectRTU();
            if (modbusClient.Connected)
            {
                foreach (var register in registers)
                {
                    if (register.address == address && register.IsWritable())
                    {
                        try
                        {
                            modbusClient.WriteSingleRegister(Convert.ToInt32(register.address), Convert.ToInt32(value));
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
    }
}
