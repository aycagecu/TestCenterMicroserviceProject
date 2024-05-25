using DataWebApi.Models.Devices;
using DataWebApi.Models;
using Microsoft.AspNetCore.Mvc;

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
            Register register;
            List<Register> regList = new List<Register>();
            List<BaseDevice> deviceList = new List<BaseDevice>();
            List<BaseProcess> processList = new List<BaseProcess>();

            register = new Register("Dam_CurrentVolume", "43120", true, true);
            regList.Add(register);
            register = new Register("Dam_Level", "43108", true, true);
            regList.Add(register);
            register = new Register("Dam_LimitSwitch", "13100", true, true);
            regList.Add(register);
            register = new Register("Dam_Pump1", "13105", true, true);
            regList.Add(register);
            register = new Register("Dam_Pump2", "13106", true, true);
            regList.Add(register);
            register = new Register("Dam_Pump3", "13107", true, true);
            regList.Add(register);
            register = new Register("Treat_CurrentVolume", "43100", true, true);
            regList.Add(register);
            register = new Register("Treat_Level1", "43102", true, true);
            regList.Add(register);
            register = new Register("Treat_Level2", "43104", true, true);
            regList.Add(register);
            register = new Register("Treat_LimitSwitch1", "13101", true, true);
            regList.Add(register);
            register = new Register("Treat_Pump1", "13102", true, true);
            regList.Add(register);
            register = new Register("Treat_Pump2", "13103", true, true);
            regList.Add(register);
            register = new Register("Treat_Pump3", "13104", true, true);
            regList.Add(register);
            register = new Register("Treat_PumpFlowLiterMin", "43106", true, true);
            regList.Add(register);
            register = new Register("Treat_ScenarioID", "43152", true, true);
            regList.Add(register);

            foreach(Register reg in regList) if(db.)

            BaseDevice Treatment_RTU = new RTUDevice("192.168.31.10", regList);
            deviceList.Add(Treatment_RTU);
            db.Add(Treatment_RTU);
            db.SaveChanges();

            register = null;
            regList.Clear();
            register = new Register("EReservoir_CurrentVolume", "43200", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Level1", "43202", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Level2", "43204", true, true);
            regList.Add(register);
            register = new Register("EReservoir_LimitSwitch", "13200", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump1", "13201", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump2", "13202", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump3", "13203", true, true);
            regList.Add(register);
            register = new Register("EReservoir_PumpFlowLiterMin", "43206", true, true);
            regList.Add(register);
            register = new Register("EReservoir_ScenarioID", "43252", true, true);
            regList.Add(register);
            BaseDevice Elevator_Reservoir_RTU = new RTUDevice("192.168.32.10", regList);
            deviceList.Add(Elevator_Reservoir_RTU);


            register = null;
            regList.Clear();
            register = new Register("CReservoir_CurrentVolume", "43300", true, true);
            regList.Add(register);
            register = new Register("CReservoir_DrainFlowLiterMin", "43308", true, true);
            regList.Add(register);
            register = new Register("CReservoir_DrainValve", "13301", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Level1", "43302", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Level2", "43304", true, true);
            regList.Add(register);
            register = new Register("CReservoir_LimitSwitch", "13300", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump1", "13302", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump2", "13303", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump3", "13304", true, true);
            regList.Add(register);
            register = new Register("CReservoir_PumpFlowLiterMin", "43306", true, true);
            regList.Add(register);
            register = new Register("CReservoir_ScenarioID", "43352", true, true);
            regList.Add(register);
            register = new Register("EA_current", "43372", true, true);
            regList.Add(register);
            register = new Register("EA_frequency", "43374", true, true);
            regList.Add(register);
            register = new Register("EA_voltage", "43370", true, true);
            regList.Add(register);
            BaseDevice Consumer_Reservoir_RTU = new RTUDevice("192.168.33.10", regList);
            deviceList.Add(Consumer_Reservoir_RTU);


            register = null;
            regList.Clear();
            register = new Register("Tank_CurrentVolume", "43400", true, true);
            regList.Add(register);
            register = new Register("Tank_DrainFlowLiterMin", "43406", true, true);
            regList.Add(register);
            register = new Register("Tank_DrainValve", "13401", true, true);
            regList.Add(register);
            register = new Register("Tank_Level1", "43402", true, true);
            regList.Add(register);
            register = new Register("Tank_Level2", "43404", true, true);
            regList.Add(register);
            register = new Register("Tank_LimitSwitch", "13400", true, true);
            regList.Add(register);
            register = new Register("Tank_ScenarioID", "43452", true, true);
            regList.Add(register);
            BaseDevice Tank_RTU = new RTUDevice("192.168.34.10", regList);
            deviceList.Add(Tank_RTU);

            BaseProcess PotableWaterProcess = new BaseProcess(deviceList);
            processList.Add(PotableWaterProcess);
            db.Add(PotableWaterProcess);
            db.SaveChanges();

            deviceList.Clear();
            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("Limitswitch", "I0.0", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I0.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_circulation_scenario_start", "M32.0", true, true);
            regList.Add(register);
            register = new Register("promotion1_collect_scenario_start", "M32.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level", "IW64", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level_norm", "MD2", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level_real", "MD36", true, true);
            regList.Add(register);
            register = new Register("promotion1_drain_scenario_start", "M32.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_level_update", "M32.3", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor1", "Q0.0", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor2", "Q0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor3", "Q0.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_pump_flow_meter", "I0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_reset_sim", "M51.4", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Promotion1 = new PLCDevice("192.168.41.10", regList);
            deviceList.Add(S7_1200_Promotion1);

            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("LimitSwitch", "I0.0", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I0.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_circulation_scenario_start", "M12.0", true, true);
            regList.Add(register);
            register = new Register("promotion2_collect_scenario_start", "M12.1", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level", "IW64", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level_norm", "MD27", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level_real", "MD32", true, true);
            regList.Add(register);
            register = new Register("promotion2_drain_scenario_start", "M12.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor1", "Q0.0", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor2", "Q0.1", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor3", "Q0.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_pump_flow_meter", "I0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_reset_sim", "M21.5", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Promotion2 = new PLCDevice("192.168.42.10", regList);
            deviceList.Add(S7_1200_Promotion2);


            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("Flowmeter", "I10.0", true, true);
            regList.Add(register);
            register = new Register("Level_Update2", "M20.3", true, true);
            regList.Add(register);
            register = new Register("Limitswitch", "I10.1", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I10.2", true, true);
            regList.Add(register);
            register = new Register("treatment_circulation_scenario_start", "M20.5", true, true);
            regList.Add(register);
            register = new Register("treatment_collect_scenario_start", "M20.1", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level", "IW0", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level_norm", "MD22", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level_real", "MD32", true, true);
            regList.Add(register);
            register = new Register("treatment_drain_scenario_start", "M20.2", true, true);
            regList.Add(register);
            register = new Register("treatment_reset_sim", "M20.4", true, true);
            regList.Add(register);
            register = new Register("treatment_total_cm_evacuated", "MD16", true, true);
            regList.Add(register);
            register = new Register("treatment_total_volume_evacuated", "MD10", true, true);
            regList.Add(register);
            register = new Register("treatment_valf", "Q4.04", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Treatment = new PLCDevice("192.168.43.10", regList);
            deviceList.Add(S7_1200_Treatment);

            BaseProcess WasteWaterProcess = new BaseProcess(deviceList);
            processList.Add(WasteWaterProcess);

            testCenter = new TestCenter(processList);
            db.Add(testCenter);
            db.SaveChanges();
        }

        public void Initialize2()
        {
            Register register;
            List<Register> regList = new List<Register>();
            List<BaseDevice> deviceList = new List<BaseDevice>();
            List<BaseProcess> processList = new List<BaseProcess>();

            register = new Register("Dam_CurrentVolume", "43120", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Dam_Level", "43108", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Dam_LimitSwitch", "13100", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Dam_Pump1", "13105", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Dam_Pump2", "13106", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Dam_Pump3", "13107", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_CurrentVolume", "43100", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_Level1", "43102", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_Level2", "43104", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_LimitSwitch1", "13101", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_Pump1", "13102", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_Pump2", "13103", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_Pump3", "13104", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_PumpFlowLiterMin", "43106", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            register = new Register("Treat_ScenarioID", "43152", true, true);
            regList.Add(register);
            db.Add(register);
            db.SaveChanges();
            BaseDevice Treatment_RTU = new RTUDevice("192.168.31.10", regList);
            deviceList.Add(Treatment_RTU);
            db.Add(Treatment_RTU);
            db.SaveChanges();

            register = null;
            regList.Clear();
            register = new Register("EReservoir_CurrentVolume", "43200", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Level1", "43202", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Level2", "43204", true, true);
            regList.Add(register);
            register = new Register("EReservoir_LimitSwitch", "13200", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump1", "13201", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump2", "13202", true, true);
            regList.Add(register);
            register = new Register("EReservoir_Pump3", "13203", true, true);
            regList.Add(register);
            register = new Register("EReservoir_PumpFlowLiterMin", "43206", true, true);
            regList.Add(register);
            register = new Register("EReservoir_ScenarioID", "43252", true, true);
            regList.Add(register);
            BaseDevice Elevator_Reservoir_RTU = new RTUDevice("192.168.32.10", regList);
            deviceList.Add(Elevator_Reservoir_RTU);


            register = null;
            regList.Clear();
            register = new Register("CReservoir_CurrentVolume", "43300", true, true);
            regList.Add(register);
            register = new Register("CReservoir_DrainFlowLiterMin", "43308", true, true);
            regList.Add(register);
            register = new Register("CReservoir_DrainValve", "13301", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Level1", "43302", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Level2", "43304", true, true);
            regList.Add(register);
            register = new Register("CReservoir_LimitSwitch", "13300", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump1", "13302", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump2", "13303", true, true);
            regList.Add(register);
            register = new Register("CReservoir_Pump3", "13304", true, true);
            regList.Add(register);
            register = new Register("CReservoir_PumpFlowLiterMin", "43306", true, true);
            regList.Add(register);
            register = new Register("CReservoir_ScenarioID", "43352", true, true);
            regList.Add(register);
            register = new Register("EA_current", "43372", true, true);
            regList.Add(register);
            register = new Register("EA_frequency", "43374", true, true);
            regList.Add(register);
            register = new Register("EA_voltage", "43370", true, true);
            regList.Add(register);
            BaseDevice Consumer_Reservoir_RTU = new RTUDevice("192.168.33.10", regList);
            deviceList.Add(Consumer_Reservoir_RTU);


            register = null;
            regList.Clear();
            register = new Register("Tank_CurrentVolume", "43400", true, true);
            regList.Add(register);
            register = new Register("Tank_DrainFlowLiterMin", "43406", true, true);
            regList.Add(register);
            register = new Register("Tank_DrainValve", "13401", true, true);
            regList.Add(register);
            register = new Register("Tank_Level1", "43402", true, true);
            regList.Add(register);
            register = new Register("Tank_Level2", "43404", true, true);
            regList.Add(register);
            register = new Register("Tank_LimitSwitch", "13400", true, true);
            regList.Add(register);
            register = new Register("Tank_ScenarioID", "43452", true, true);
            regList.Add(register);
            BaseDevice Tank_RTU = new RTUDevice("192.168.34.10", regList);
            deviceList.Add(Tank_RTU);

            BaseProcess PotableWaterProcess = new BaseProcess(deviceList);
            processList.Add(PotableWaterProcess);
            db.Add(PotableWaterProcess);
            db.SaveChanges();

            deviceList.Clear();
            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("Limitswitch", "I0.0", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I0.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_circulation_scenario_start", "M32.0", true, true);
            regList.Add(register);
            register = new Register("promotion1_collect_scenario_start", "M32.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level", "IW64", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level_norm", "MD2", true, true);
            regList.Add(register);
            register = new Register("promotion1_current_level_real", "MD36", true, true);
            regList.Add(register);
            register = new Register("promotion1_drain_scenario_start", "M32.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_level_update", "M32.3", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor1", "Q0.0", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor2", "Q0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_motor3", "Q0.2", true, true);
            regList.Add(register);
            register = new Register("promotion1_pump_flow_meter", "I0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_reset_sim", "M51.4", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Promotion1 = new PLCDevice("192.168.41.10", regList);
            deviceList.Add(S7_1200_Promotion1);

            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("LimitSwitch", "I0.0", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I0.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_circulation_scenario_start", "M12.0", true, true);
            regList.Add(register);
            register = new Register("promotion2_collect_scenario_start", "M12.1", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level", "IW64", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level_norm", "MD27", true, true);
            regList.Add(register);
            register = new Register("promotion2_current_level_real", "MD32", true, true);
            regList.Add(register);
            register = new Register("promotion2_drain_scenario_start", "M12.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor1", "Q0.0", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor2", "Q0.1", true, true);
            regList.Add(register);
            register = new Register("promotion2_motor3", "Q0.2", true, true);
            regList.Add(register);
            register = new Register("promotion2_pump_flow_meter", "I0.1", true, true);
            regList.Add(register);
            register = new Register("promotion1_reset_sim", "M21.5", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Promotion2 = new PLCDevice("192.168.42.10", regList);
            deviceList.Add(S7_1200_Promotion2);


            register = null;
            regList.Clear();
            register = new Register("clock_1hz", "M0.5", true, true);
            regList.Add(register);
            register = new Register("Flowmeter", "I10.0", true, true);
            regList.Add(register);
            register = new Register("Level_Update2", "M20.3", true, true);
            regList.Add(register);
            register = new Register("Limitswitch", "I10.1", true, true);
            regList.Add(register);
            register = new Register("Local_Control", "I10.2", true, true);
            regList.Add(register);
            register = new Register("treatment_circulation_scenario_start", "M20.5", true, true);
            regList.Add(register);
            register = new Register("treatment_collect_scenario_start", "M20.1", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level", "IW0", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level_norm", "MD22", true, true);
            regList.Add(register);
            register = new Register("treatment_current_level_real", "MD32", true, true);
            regList.Add(register);
            register = new Register("treatment_drain_scenario_start", "M20.2", true, true);
            regList.Add(register);
            register = new Register("treatment_reset_sim", "M20.4", true, true);
            regList.Add(register);
            register = new Register("treatment_total_cm_evacuated", "MD16", true, true);
            regList.Add(register);
            register = new Register("treatment_total_volume_evacuated", "MD10", true, true);
            regList.Add(register);
            register = new Register("treatment_valf", "Q4.04", true, true);
            regList.Add(register);
            register = new Register("WebServerTag", "MW7", true, true);
            regList.Add(register);

            BaseDevice S7_1200_Treatment = new PLCDevice("192.168.43.10", regList);
            deviceList.Add(S7_1200_Treatment);

            BaseProcess WasteWaterProcess = new BaseProcess(deviceList);
            processList.Add(WasteWaterProcess);

            testCenter = new TestCenter(processList);
            db.Add(testCenter);
            db.SaveChanges();
        }
        public void GetValues()
        {
            Initialize();
            List<BaseProcess> processes = testCenter.processes;

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
