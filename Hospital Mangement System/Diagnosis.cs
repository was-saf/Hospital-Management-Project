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
    public partial class Diagnosis : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WASSAF;Initial Catalog=Hospital;Integrated Security=True");

        public Diagnosis()
        {
            InitializeComponent();
            populate();
            populatePatientID();
            populateDoctorID();
            fetchPatientName();
            fetchDoctorName();
            CBPatientID.SelectedIndexChanged += CBPatientID_SelectedIndexChanged;
            CBDoctorID.SelectedIndexChanged += CBDoctorID_SelectedIndexChanged;
        }

        private void CBPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchPatientName();
        }

        private void CBDoctorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchDoctorName();
        }

        void populatePatientID()
        {
            string query = "SELECT * FROM PATIENT";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader sqlDataReader;
            try {
                conn.Open();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("PatientID", typeof(int));
                sqlDataReader = cmd.ExecuteReader();    
                dataTable.Load(sqlDataReader);
                CBPatientID.ValueMember = "PatientID";
                CBPatientID.DisplayMember = "PatientID";
                CBPatientID.DataSource = dataTable;
                conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void populateDoctorID()
        {
            string query = "SELECT * FROM Doctor";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader sqlDataReader;
            try
            {
                conn.Open();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("DoctorID", typeof(int));
                sqlDataReader = cmd.ExecuteReader();
                dataTable.Load(sqlDataReader);
                CBDoctorID.ValueMember = "DoctorID";
                CBDoctorID.DisplayMember = "DoctorID";
                CBDoctorID.DataSource = dataTable;
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string PatientName;

        void fetchPatientName()
        {
            conn.Open();
            string query =  "SELECT * FROM Patient where PatientID = "+CBPatientID.Text+"";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows) { 
                PatientName = dataRow["PatientName"].ToString();
                txtPatientName.Text = PatientName;  
            }
            conn.Close();
        }

        string DoctorName;

        void fetchDoctorName()
        {
            conn.Open();
            string query = "SELECT * FROM Doctor where DoctorID = " + CBDoctorID.Text + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                DoctorName = dataRow["DoctorName"].ToString();
                txtDoctorName.Text = DoctorName;
            }
            conn.Close();
        }

        void populate() 
        {
            conn.Open();
            string query = "SELECT * FROM Diagnosis";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DGVDiagnosis.DataSource = dataSet.Tables[0];
            conn.Close();
        }

        private void reset()
        {
            DateTime dateTime = DateTime.Today;
            txtDiagnosisID.Text = "";
            CBPatientID.Text = "Patient ID";
            txtPatientName.Text = "";
            CBDoctorID.Text = "Doctor ID";
            txtDoctorName.Text = "";
            dateDiagnosis.Text = dateTime.ToString();
            txtDiagnosisDescription.Text = "";
            txtTreatmentPlan.Text = "";
        }



        private void Diagnosis_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDiagnosisID.Text == "" || CBPatientID.Text == "" || CBDoctorID.Text == "" || dateDiagnosis.Value.ToString() == "" || txtDiagnosisDescription.Text == "" || txtTreatmentPlan.Text == "")
            {
                MessageBox.Show("Missing Information! Fill all details carefully.");
            }
            else
            {
                conn.Open();
                string query = "INSERT INTO Diagnosis values("+txtDiagnosisID.Text+","+CBPatientID.Text+","+CBDoctorID.Text+",'"+ dateDiagnosis.Value.ToString() + "', '"+txtDiagnosisDescription.Text+"','"+txtTreatmentPlan.Text+"' )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Added Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void DGVDiagnosis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDiagnosisID.Text = DGVDiagnosis.SelectedRows[0].Cells[0].Value.ToString();
            CBPatientID.Text = DGVDiagnosis.SelectedRows[0].Cells[1].Value.ToString(); ;
            fetchPatientName();
            CBDoctorID.Text = DGVDiagnosis.SelectedRows[0].Cells[2].Value.ToString(); ;
            fetchDoctorName();
            dateDiagnosis.Text = DGVDiagnosis.SelectedRows[0].Cells[3].Value.ToString();
            txtDiagnosisDescription.Text = DGVDiagnosis.SelectedRows[0].Cells[4].Value.ToString(); ;
            txtTreatmentPlan.Text = DGVDiagnosis.SelectedRows[0].Cells[5].Value.ToString(); ;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDiagnosisID.Text == "")
            {
                MessageBox.Show("Enter Diagnosis ID to update it.");
            }
            else
            {
                conn.Open();
                string query = "UPDATE Diagnosis Set PatientID = "+ CBPatientID.Text+",DoctorID = "+CBDoctorID.Text+", DiagnosisDate = '"+ dateDiagnosis.Value.ToString() + "',TreatmentPlan = '"+txtTreatmentPlan.Text+"' WHERE DiagnosisID = " + txtDiagnosisID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Details Updated Successfully.");
                conn.Close();
                populate();
                reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDiagnosisID.Text == "")
            {
                MessageBox.Show("Enter Diagnosis ID to delete it");
            }
            else
            {
                conn.Open();
                string query = "DELETE FROM DIAGNOSIS WHERE DiagnosisID = " + txtDiagnosisID.Text + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Diagnosis Deleted Successfully.");
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
