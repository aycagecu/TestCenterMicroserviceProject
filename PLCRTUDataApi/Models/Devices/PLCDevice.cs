using S7.Net;

namespace PLCRTUDataApi.Models.Devices
{
    public class PLCDevice : BaseDevice
    {
        private Plc plc;
        public PLCDevice(string ipAddress, List<Register> registers) : base( ipAddress, registers)
        {
            plc = new Plc(CpuType.S71500, ipAddress, 0, 1);
        }
        public PLCDevice()
        {
            
        }
        public void ConnectPLC()
        {
            plc.Open();
        }

        public void DisconnectPLC()
        {
            plc.Close();
        }

        public override void ReadRegisters()
        {
            ConnectPLC();
            if (plc.IsConnected)
            {

                foreach (var register in registers)
                {
                    try
                    {
                        if (register.IsReadable())
                        {
                            register.SetValue(plc.Read(register.address));
                            db.SaveChanges();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }

                }
            }
            DisconnectPLC();
        }

        public override void WriteRegister(string address, object value)
        {
            ConnectPLC();
            if (plc.IsConnected)
            {
                foreach (var register in registers)
                {
                    if (register.address==address&&register.IsWritable())
                    {
                        try
                        {
                            plc.Write(register.address, value);
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
            DisconnectPLC();

        }
    }
}
