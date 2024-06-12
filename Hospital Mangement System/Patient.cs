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
    public partial class Patient : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");

        public Patient()
        {
            InitializeComponent();
            populate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void DGVPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtPatientID.Text = DGVPatients.SelectedRows[0].Cells[0].Value.ToString();
            txtPatientName.Text = DGVPatients.SelectedRows[0].Cells[1].Value.ToString();
            txtAge.Text = DGVPatients.SelectedRows[0].Cells[2].Value.ToString();
            CBGender.Text = DGVPatients.SelectedRows[0].Cells[3].Value.ToString();
            CBBloodGroup.Text = DGVPatients.SelectedRows[0].Cells[4].Value.ToString();
            txtContactNo.Text = DGVPatients.SelectedRows[0].Cells[5].Value.ToString();
            txtMedicalHistory.Text = DGVPatients.SelectedRows[0].Cells[6].Value.ToString();
            txtAddress.Text = DGVPatients.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "" || txtPatientName.Text == "" || txtAge.Text == "" || CBGender.Text == "" || CBBloodGroup.Text == "" || txtContactNo.Text == "" || txtAddress.Text == "" || txtMedicalHistory.Text == "")
            {
                MessageBox.Show("Missing Information! Fill all details carefully.");
            }
            else
            {
                conn.Open();
                string query = "INSERT INTO Patient values("+txtPatientID.Text+",'"+ txtPatientName.Text + "',"  +txtAge.Text+  ",'"+  CBGender.Text+  "','" + CBBloodGroup.Text+  "','"+  txtContactNo.Text + "','" + txtAddress.Text + "','"  +txtMedicalHistory.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Added Successfully.");
                conn.Close();
                populate();
                reset();
            }
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

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.Show();
            this.Hide();
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void populate()
        {
            conn.Open();
            string query = "SELECT * FROM Patient";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DGVPatients.DataSource = dataSet.Tables[0];
            conn.Close();
        }

        private void reset()
        {
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            txtAge.Text = "";
            CBGender.Text = "Select Gender";
            CBBloodGroup.Text = "Select Blood Group";
            txtContactNo.Text = "";
            txtMedicalHistory.Text = "";
            txtAddress.Text = "";
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "")
            {
                MessageBox.Show("Enter Patient ID to update it.");
            }
            else
            {
                conn.Open();
                string query = "UPDATE Patient Set PatientName = '"+txtPatientName.Text+"', Age = "+txtAge.Text+", Gender = '"+ CBGender.Text +"', BloodGroup = '"+CBBloodGroup.Text +"', ContactNumber = '"+ txtContactNo.Text +"', Address = '" + txtAddress.Text  + "', MedicalHistory = '"+ txtMedicalHistory.Text + "' WHERE PatientID = " + txtPatientID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Details Updated Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "")
            {
                MessageBox.Show("Enter Patient ID to delete it");
            }
            else
            {
                conn.Open();
                string query = "DELETE FROM PATIENT WHERE PatientID = " + txtPatientID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Deleted Successfully.");
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
    }
}
