using DataWebApi.Models.Devices;
using DataWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataWebApi.Controllers
{

    public class TestCenterController : Controller
    {
        private TestCenter testCenter;
        private TestCenterDbContext db;
        public TestCenterController(TestCenterDbContext _db)
        {
            this.db = _db;
            testCenter = null;
        }
        public void Initialize()
        {
            if (!db.Register.Any())
            {
                Register register;
                List<Register> regList = new List<Register>();
                List<BaseDevice> deviceList = new List<BaseDevice>();
                List<BaseProcess> processList = new List<BaseProcess>();

                register = new Register("Dam_CurrentVolume", "0", true, true);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Dam_Level", "1", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Dam_LimitSwitch", "2", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Dam_Pump1", "3", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Dam_Pump2", "4", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Dam_Pump3", "5", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_CurrentVolume", "6", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_Level1", "7", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_Level2", "8", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_LimitSwitch1", "9", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_Pump1", "10", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_Pump2", "11", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_Pump3", "12", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_PumpFlowLiterMin", "13", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();
                register = new Register("Treat_ScenarioID", "14", true, true);
                regList.Add(register);
                db.Add(register);
                db.SaveChanges();

                BaseDevice Treatment_RTU = new RTUDevice("192.168.33.106", 1, regList);
                deviceList.Add(Treatment_RTU);
                db.Add(Treatment_RTU);
                db.SaveChanges();

                //register = null;
                //regList.Clear();
                //register = new Register(1, "EReservoir_CurrentVolume", "43200", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "EReservoir_Level1", "43202", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(3, "EReservoir_Level2", "43204", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "EReservoir_LimitSwitch", "13200", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "EReservoir_Pump1", "13201", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "EReservoir_Pump2", "13202", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "EReservoir_Pump3", "13203", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(8, "EReservoir_PumpFlowLiterMin", "43206", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(9, "EReservoir_ScenarioID", "43252", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //BaseDevice Elevator_Reservoir_RTU = new RTUDevice(2,"192.168.32.10",32, regList);
                //deviceList.Add(Elevator_Reservoir_RTU);
                //db.Add(Elevator_Reservoir_RTU);
                //db.SaveChanges();


                //register = null;
                //regList.Clear();
                //register = new Register(1, "CReservoir_CurrentVolume", "43300", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "CReservoir_DrainFlowLiterMin", "43308", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(3, "CReservoir_DrainValve", "13301", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "CReservoir_Level1", "43302", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "CReservoir_Level2", "43304", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "CReservoir_LimitSwitch", "13300", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "CReservoir_Pump1", "13302", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(8, "CReservoir_Pump2", "13303", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(9, "CReservoir_Pump3", "13304", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(10, "CReservoir_PumpFlowLiterMin", "43306", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(11, "CReservoir_ScenarioID", "43352", true, true);
                //regList.Add(register); 
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(12, "EA_current", "43372", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(13, "EA_frequency", "43374", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(14, "EA_voltage", "43370", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //BaseDevice Consumer_Reservoir_RTU = new RTUDevice(3,"192.168.33.10", 33,regList);
                //deviceList.Add(Consumer_Reservoir_RTU);
                //db.Add(Consumer_Reservoir_RTU);
                //db.SaveChanges();


                //register = null;
                //regList.Clear();
                //register = new Register(1, "Tank_CurrentVolume", "43400", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "Tank_DrainFlowLiterMin", "43406", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(3, "Tank_DrainValve", "13401", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "Tank_Level1", "43402", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "Tank_Level2", "43404", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "Tank_LimitSwitch", "13400", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "Tank_ScenarioID", "43452", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //BaseDevice Tank_RTU = new RTUDevice(4,"192.168.34.10",34, regList);
                //deviceList.Add(Tank_RTU);
                //db.Add(Tank_RTU);
                //db.SaveChanges();

                BaseProcess PotableWaterProcess = new BaseProcess(deviceList);
                processList.Add(PotableWaterProcess);
                db.Add(PotableWaterProcess);
                db.SaveChanges();

                //deviceList.Clear();
                //register = null;
                //regList.Clear();
                //register = new Register(1, "clock_1hz", "M0.5", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "Limitswitch", "I0.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(3, "Local_Control", "I0.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "promotion1_circulation_scenario_start", "M32.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "promotion1_collect_scenario_start", "M32.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "promotion1_current_level", "IW64", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "promotion1_current_level_norm", "MD2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(8, "promotion1_current_level_real", "MD36", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(9, "promotion1_drain_scenario_start", "M32.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(10, "promotion1_level_update", "M32.3", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(11, "promotion1_motor1", "Q0.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(12, "promotion1_motor2", "Q0.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(13, "promotion1_motor3", "Q0.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(14, "promotion1_pump_flow_meter", "I0.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(15, "promotion1_reset_sim", "M51.4", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(16, "WebServerTag", "MW7", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();

                //BaseDevice S7_1200_Promotion1 = new PLCDevice("192.168.41.10", regList);
                //deviceList.Add(S7_1200_Promotion1);
                //db.Add(S7_1200_Promotion1);
                //db.SaveChanges();

                //register = null;
                //regList.Clear();
                //register = new Register(1, "clock_1hz", "M0.5", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "LimitSwitch", "I0.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(3, "Local_Control", "I0.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "promotion2_circulation_scenario_start", "M12.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "promotion2_collect_scenario_start", "M12.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "promotion2_current_level", "IW64", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "promotion2_current_level_norm", "MD27", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(8, "promotion2_current_level_real", "MD32", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(9, "promotion2_drain_scenario_start", "M12.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(10, "promotion2_motor1", "Q0.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(11, "promotion2_motor2", "Q0.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(12, "promotion2_motor3", "Q0.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(13, "promotion2_pump_flow_meter", "I0.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(14, "promotion1_reset_sim", "M21.5", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(15, "WebServerTag", "MW7", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();

                //BaseDevice S7_1200_Promotion2 = new PLCDevice("192.168.42.10", regList);
                //deviceList.Add(S7_1200_Promotion2);
                //db.Add(S7_1200_Promotion2);
                //db.SaveChanges();


                //register = null;
                //regList.Clear();
                //register = new Register(1, "clock_1hz", "M0.5", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "Flowmeter", "I10.0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(2, "Level_Update2", "M20.3", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(4, "Limitswitch", "I10.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(5, "Local_Control", "I10.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(6, "treatment_circulation_scenario_start", "M20.5", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(7, "treatment_collect_scenario_start", "M20.1", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(8, "treatment_current_level", "IW0", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(9, "treatment_current_level_norm", "MD22", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(10, "treatment_current_level_real", "MD32", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(11, "treatment_drain_scenario_start", "M20.2", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(12, "treatment_reset_sim", "M20.4", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(13, "treatment_total_cm_evacuated", "MD16", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(14, "treatment_total_volume_evacuated", "MD10", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(15, "treatment_valf", "Q4.04", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();
                //register = new Register(16, "WebServerTag", "MW7", true, true);
                //regList.Add(register);
                //db.Add(register);
                //db.SaveChanges();

                //BaseDevice S7_1200_Treatment = new PLCDevice("192.168.43.10", regList);
                //deviceList.Add(S7_1200_Treatment);
                //db.Add(S7_1200_Treatment);
                //db.SaveChanges();

                //BaseProcess WasteWaterProcess = new BaseProcess(deviceList);
                //processList.Add(WasteWaterProcess);
                //db.Add(WasteWaterProcess);
                //db.SaveChanges();

                testCenter = new TestCenter(processList);
                db.Add(testCenter);
                db.SaveChanges();
            }
        }

        public void GetValues()
        {
            Initialize();
            testCenter = db.TestCenter.Include(tc => tc.processes)
                                      .ThenInclude(p => p.devices)
                                      .ThenInclude(d=>d.registers)
                                      .FirstOrDefault();    

            List<BaseProcess> processes = testCenter.processes.ToList();

            foreach (BaseProcess process in processes)
            {
                List<BaseDevice> devices = process.devices;
                foreach (BaseDevice device in devices)
                {
                    device.ReadRegisters();
                    db.SaveChanges();
                }
            }
        }


        public IActionResult Index()
        {
            //var hhtc = new HttpClient();
            //var response = await hhtc.GetAsync("https://localhost:7147/api/HayvanApi");
            //string resString = await response.Content.ReadAsStringAsync();
            //Hayvanlar = JsonConvert.DeserializeObject<List<Hayvan>>(resString);

            return View();
        }
    }

}
