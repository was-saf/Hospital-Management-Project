using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Mangement_System
{
    public partial class Doctor : Form 
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");
        public Doctor()
        {
            InitializeComponent();
            populate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Show();
            this.Hide();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            BloodDonor bloodDonor = new BloodDonor();
            bloodDonor.Show();
            this.Hide();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            OutGoingPatient outGoingPatient = new OutGoingPatient();
            outGoingPatient.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == "" || txtDoctorName.Text == "" || txtSpecialization.Text == "" || txtContactNo.Text == "" || txtDepartmentID.Text == "" || txtExperienceYears.Text == "") {
                MessageBox.Show("Missing Information! Fill all details carefully.");
            }
            else { 
                conn.Open();
                string query = "INSERT INTO DOCTOR values("+txtDoctorID.Text+",'"+txtDoctorName.Text+"','"+txtSpecialization.Text+"','"+txtContactNo.Text+"',"+txtDepartmentID.Text+","+txtExperienceYears.Text+")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void reset() {
            txtDoctorID.Text = "";
            txtDoctorName.Text = "";
            txtSpecialization.Text = "";
            txtContactNo.Text = "";
            txtDepartmentID.Text = "";
            txtExperienceYears.Text = "";
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        void populate() { 
            conn.Open();
            string query = "SELECT * FROM DOCTOR";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DGVDoctor.DataSource = dataSet.Tables[0];
            conn.Close();
        }

        private void DGVDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDoctorID.Text = DGVDoctor.SelectedRows[0].Cells[0].Value.ToString();
            txtDoctorName.Text = DGVDoctor.SelectedRows[0].Cells[1].Value.ToString();
            txtSpecialization.Text = DGVDoctor.SelectedRows[0].Cells[2].Value.ToString();
            txtContactNo.Text = DGVDoctor.SelectedRows[0].Cells[3].Value.ToString();
            txtDepartmentID.Text = DGVDoctor.SelectedRows[0].Cells[4].Value.ToString();
            txtExperienceYears.Text = DGVDoctor.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == "")
            {
                MessageBox.Show("Enter Doctor ID to update it.");
            }
            else
            {
                conn.Open();
                string query = "UPDATE DOCTOR Set DoctorName = '" + txtDoctorName.Text + "',Specialization = '" + txtSpecialization.Text + "', ContactNumber = '" + txtContactNo.Text + "',DepartmentID = " + txtDepartmentID.Text + ",ExperienceYears = " + txtExperienceYears.Text + " WHERE DoctorID = " + txtDoctorID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Details Updated Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == "")
            {
                MessageBox.Show("Enter Doctor ID to delete it");
            }
            else {
                conn.Open();
                string query = "DELETE FROM DOCTOR  WHERE DoctorID = " + txtDoctorID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Deleted Successfully.");
                conn.Close();
                populate();
                reset();
            }
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
    }
}