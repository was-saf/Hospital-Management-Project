using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class WardAdmission : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");

        public WardAdmission()
        {
            InitializeComponent();
            populate();
        }

        void populate()
        {
            conn.Open();
            string query = "SELECT * FROM WardAdmission";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DGVWardAdmission.DataSource = dataSet.Tables[0];
            conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Hide();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Show();
            this.Hide();
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.Show();
            this.Hide();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Hide();
        }

        private void btnSurgery_Click(object sender, EventArgs e)
        {
            Surgery surgery = new Surgery();
            surgery.Show();
            this.Hide();
        }

        private void btnLabTests_Click(object sender, EventArgs e)
        {
            LabTest labTests = new LabTest();
            labTests.Show();
            this.Hide();
        }

        private void btnRadiology_Click(object sender, EventArgs e)
        {
            Radiology radiology = new Radiology();
            radiology.Show();
            this.Hide();
        }

        private void btnBloodDonor_Click(object sender, EventArgs e)
        {
            BloodDonor bloodDonor = new BloodDonor();
            bloodDonor.Show();
            this.Hide();
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.Show();
            this.Hide();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            Department departments = new Department();
            departments.Show();
            this.Hide();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            this.Hide();
        }

        private void btnWardAdmission_Click(object sender, EventArgs e)
        {
            WardAdmission wardAdmission = new WardAdmission();
            wardAdmission.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Hide();
        }

        private void btnOutGoingPatient_Click(object sender, EventArgs e)
        {
            OutGoingPatient outGoingPatient = new OutGoingPatient();
            outGoingPatient.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
            this.Hide();
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
            this.Hide();
        }

        private void btnMaintenanceLog_Click(object sender, EventArgs e)
        {
            MaintenanceLog maintenanceLog = new MaintenanceLog();
            maintenanceLog.Show();
            this.Hide();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Hide();
        }

        private void btnNurseWardStaff_Click(object sender, EventArgs e)
        {
            NurseWardStaff nurseWardStaff = new NurseWardStaff();
            nurseWardStaff.Show();
            this.Hide();
        }

        private void btnSecurityStaff_Click(object sender, EventArgs e)
        {
            SecurityStaff securityStaff = new SecurityStaff();
            securityStaff.Show();
            this.Hide();
        }

        private void btnTransportStaff_Click(object sender, EventArgs e)
        {
            TransportStaff transportStaff = new TransportStaff();
            transportStaff.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
