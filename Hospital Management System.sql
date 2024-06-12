create database Hospital;

-- Departments
CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(100),
    Description NVARCHAR(255)
);

-- Unified Staff Table
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY,
    StaffName NVARCHAR(100),
    ContactNumber NVARCHAR(15),
    Salary DECIMAL(10, 2),
    Shift NVARCHAR(50),
    JoiningDate DATE
);

-- Security Staff
CREATE TABLE SecurityStaff (
    StaffID INT PRIMARY KEY,
    Role NVARCHAR(50),
    DepartmentID INT,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Transport Staff
CREATE TABLE TransportStaff (
    StaffID INT PRIMARY KEY,
    Role NVARCHAR(50),
    DepartmentID INT,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Ward Boys/Nurse Staff
CREATE TABLE NurseWardStaff (
    StaffID INT PRIMARY KEY,
    Role NVARCHAR(50),
    DepartmentID INT,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Medicine Inventory
CREATE TABLE Medicine (
    MedicineID INT PRIMARY KEY,
    MedicineName NVARCHAR(100),
    Manufacturer NVARCHAR(100),
    QuantityAvailable INT,
    ExpiryDate DATE,
    UnitPrice DECIMAL(10, 2),
    Category NVARCHAR(50)
);

-- Patient Appointment
CREATE TABLE Patient (
    PatientID INT PRIMARY KEY,
    PatientName NVARCHAR(100),
    Age INT,
    Gender NVARCHAR(10),
	BloodGroup NVARCHAR(5),
    ContactNumber NVARCHAR(15),
    Address NVARCHAR(255),
    MedicalHistory NVARCHAR(MAX)
);


CREATE TABLE Doctor (
    DoctorID INT PRIMARY KEY,
    DoctorName NVARCHAR(100),
    Specialization NVARCHAR(100),
    ContactNumber NVARCHAR(15),
    DepartmentID INT,
    ExperienceYears INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

CREATE TABLE Appointment (
    AppointmentID INT PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    Status NVARCHAR(50),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID)
);

-- Rooms
CREATE TABLE Room (
    RoomID INT PRIMARY KEY,
    RoomType NVARCHAR(50),
    Availability BIT,
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Billing
CREATE TABLE Billing (
    BillingID INT PRIMARY KEY,
    PatientID INT,
    TotalAmount DECIMAL(10, 2),
    PaymentStatus NVARCHAR(50),
    BillingDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);

-- Prescriptions
CREATE TABLE Prescription (
    PrescriptionID INT PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    MedicineID INT,
    Dosage NVARCHAR(50),
    Instructions NVARCHAR(255),
    IssueDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID)
);

-- Surgery Details
CREATE TABLE Surgery (
    SurgeryID INT PRIMARY KEY,
    SurgeryName NVARCHAR(100),
    DoctorID INT,
    PatientID INT,
    SurgeryDate DATE,
    SurgeryType NVARCHAR(50),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);

-- Employee Attendance
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY,
    StaffID INT,
    Date DATE,
    InTime TIME,
    OutTime TIME,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

-- Equipment Inventory
CREATE TABLE Equipment (
    EquipmentID INT PRIMARY KEY,
    EquipmentName NVARCHAR(100),
    QuantityAvailable INT,
    Condition NVARCHAR(50),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

-- Laboratory Information System
CREATE TABLE LabTest (
    TestID INT PRIMARY KEY,
    TestName NVARCHAR(100),
    TestCost DECIMAL(10, 2),
    Description NVARCHAR(255),
    SampleType NVARCHAR(50),
    DepartmentID INT,
    PatientID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);


-- Radiology Management
CREATE TABLE RadiologyTest (
    XrayID INT PRIMARY KEY,
    XrayType NVARCHAR(50),
    BodyPart NVARCHAR(50),
    Result NVARCHAR(255),
    DoctorID INT,
    PatientID INT,
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID)
);

-- Outpatient Pharmacy
CREATE TABLE OutpatientPrescription (
    PrescriptionID INT PRIMARY KEY,
    PatientID INT,
    MedicineID INT,
    Quantity INT,
    DispensedDate DATE,
    DispensedBy INT,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (MedicineID) REFERENCES Medicine(MedicineID),
    FOREIGN KEY (DispensedBy) REFERENCES Staff(StaffID)
);

-- Blood Bank Management
CREATE TABLE BloodDonor (
    DonorID INT PRIMARY KEY,
    DonorName NVARCHAR(100),
    BloodGroup NVARCHAR(5),
    DonationDate DATE,
    DonationPlace NVARCHAR(100),
    ContactNumber NVARCHAR(15)
);

-- Inpatient Ward Management
CREATE TABLE WardAdmission (
    AdmissionID INT PRIMARY KEY,
    PatientID INT,
    WardNumber INT,
    BedNumber NVARCHAR(50),
    AdmissionDate DATE,
    DischargeDate DATE,
    DischargeReason NVARCHAR(255),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
	FOREIGN KEY (WardNumber) REFERENCES Department(DepartmentID)
);


-- Hospital Maintenance
CREATE TABLE MaintenanceLog (
    LogID INT PRIMARY KEY,
    EquipmentID INT,
    MaintenanceDate DATE,
    MaintenanceType NVARCHAR(50),
    TechnicianID INT,
    Details NVARCHAR(255),
    FOREIGN KEY (EquipmentID) REFERENCES Equipment(EquipmentID),
    FOREIGN KEY (TechnicianID) REFERENCES Staff(StaffID)
);

CREATE TABLE Diagnosis (
    DiagnosisID INT PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    DiagnosisDate DATE,
    DiagnosisDescription NVARCHAR(255),
    TreatmentPlan NVARCHAR(MAX),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID)
);


INSERT INTO Department (DepartmentID, DepartmentName, Description) VALUES
(1, 'Cardiology', 'Department that deals with disorders of the heart and blood vessels.'),
(2, 'Neurology', 'Department specializing in the treatment of the nervous system.'),
(3, 'Oncology', 'Department dedicated to the treatment of cancer.'),
(4, 'Pediatrics', 'Department focused on medical care of infants, children, and adolescents.'),
(5, 'Orthopedics', 'Department specializing in the treatment of the musculoskeletal system.'),
(6, 'Radiology', 'Department that uses imaging technology to diagnose and treat diseases.'),
(7, 'Emergency Medicine', 'Department providing immediate treatment to patients with acute illnesses and injuries.'),
(8, 'Gastroenterology', 'Department dealing with the digestive system and its disorders.'),
(9, 'Gynecology', 'Department focusing on women’s health, especially reproductive organs.'),
(10, 'Dermatology', 'Department that treats skin, hair, and nail conditions.'),
(11, 'Psychiatry', 'Department that deals with mental health and disorders.'),
(12, 'Ophthalmology', 'Department specializing in eye and vision care.'),
(13, 'Pulmonology', 'Department focused on the respiratory system.'),
(14, 'Endocrinology', 'Department that treats hormone-related diseases.'),
(15, 'Nephrology', 'Department dedicated to the treatment of kidney conditions.');


INSERT INTO Staff (StaffID, StaffName, ContactNumber, Salary, Shift, JoiningDate) VALUES
(1, 'Ahmed Khan', '03001234567', 50000.00, 'Morning', '2020-01-15'),
(2, 'Sara Ahmed', '03011234567', 55000.00, 'Evening', '2019-05-10'),
(3, 'Zainab Ali', '03021234567', 48000.00, 'Night', '2018-11-20'),
(4, 'Ali Raza', '03031234567', 60000.00, 'Morning', '2021-03-01'),
(5, 'Ayesha Fatima', '03041234567', 52000.00, 'Evening', '2020-09-17'),
(6, 'Bilal Sheikh', '03051234567', 53000.00, 'Night', '2019-12-12'),
(7, 'Fatima Noor', '03061234567', 57000.00, 'Morning', '2021-06-23'),
(8, 'Hassan Qureshi', '03071234567', 49000.00, 'Evening', '2018-08-30'),
(9, 'Mariam Usman', '03081234567', 51000.00, 'Night', '2019-02-25'),
(10, 'Usman Iqbal', '03091234567', 58000.00, 'Morning', '2021-11-14');


INSERT INTO SecurityStaff (StaffID, Role, DepartmentID) VALUES
(1, 'Security Guard', 1),
(4, 'Security Guard', 7),
(5, 'Security Supervisor', 7);


INSERT INTO TransportStaff (StaffID, Role, DepartmentID) VALUES
(6, 'Driver', 6),
(7, 'Transport Coordinator', 10),
(8, 'Driver', 15),
(10, 'Driver', 12);


INSERT INTO NurseWardStaff (StaffID, Role, DepartmentID) VALUES
(2, 'Nurse', 1),
(9, 'Nurse', 1),
(3, 'Nurse', 2);

INSERT INTO Medicine (MedicineID, MedicineName, Manufacturer, QuantityAvailable, ExpiryDate, UnitPrice, Category) VALUES
(1, 'Paracetamol', 'GSK', 1000, '2024-12-31', 5.00, 'Painkiller'),
(2, 'Ibuprofen', 'Abbott', 800, '2024-10-15', 10.00, 'Painkiller'),
(3, 'Amoxicillin', 'Pfizer', 500, '2025-05-20', 20.00, 'Antibiotic'),
(4, 'Metformin', 'Sanofi', 600, '2024-07-30', 15.00, 'Diabetes'),
(5, 'Atorvastatin', 'Merck', 400, '2024-03-25', 25.00, 'Cholesterol'),
(6, 'Omeprazole', 'Novartis', 700, '2024-09-10', 12.00, 'Antacid'),
(7, 'Cetirizine', 'Bayer', 900, '2025-01-05', 8.00, 'Antihistamine'),
(8, 'Losartan', 'Boehringer', 550, '2024-11-14', 18.00, 'Hypertension'),
(9, 'Levothyroxine', 'AbbVie', 450, '2024-08-29', 22.00, 'Thyroid'),
(10, 'Salbutamol', 'AstraZeneca', 600, '2024-12-22', 14.00, 'Asthma');


INSERT INTO Patient (PatientID, PatientName, Age, Gender, BloodGroup, ContactNumber, Address, MedicalHistory) VALUES
(1, 'Hassan Ali', 30, 'Male', 'B+', '03101234567', 'Karachi', 'Diabetes'),
(2, 'Ayesha Khan', 25, 'Female', 'O-', '03111234567', 'Lahore', 'Hypertension'),
(3, 'Bilal Ahmed', 40, 'Male', 'A+', '03121234567', 'Islamabad', 'Asthma'),
(4, 'Fatima Zahra', 35, 'Female', 'B-', '03131234567', 'Quetta', 'Thyroid'),
(5, 'Usman Farooq', 50, 'Male', 'AB+', '03141234567', 'Peshawar', 'Heart Disease'),
(6, 'Sara Yousuf', 28, 'Female', 'O+', '03151234567', 'Multan', 'Migraine'),
(7, 'Ali Raza', 45, 'Male', 'A-', '03161234567', 'Faisalabad', 'Cholesterol'),
(8, 'Zainab Noor', 32, 'Female', 'B+', '03171234567', 'Hyderabad', 'Allergies'),
(9, 'Hira Malik', 37, 'Female', 'AB-', '03181234567', 'Sialkot', 'Arthritis'),
(10, 'Ahmed Raza', 29, 'Male', 'O+', '03191234567', 'Gujranwala', 'Kidney Stones');


INSERT INTO Doctor (DoctorID, DoctorName, Specialization, ContactNumber, DepartmentID, ExperienceYears) VALUES
(1, 'Dr. Muhammad Ali', 'Cardiology', '03201234567', 1, 10),
(2, 'Dr. Sara Ahmed', 'Neurology', '03211234567', 2, 8),
(3, 'Dr. Bilal Khan', 'Oncology', '03221234567', 3, 12),
(4, 'Dr. Fatima Usman', 'Pediatrics', '03231234567', 4, 6),
(5, 'Dr. Hassan Qureshi', 'Orthopedics', '03241234567', 5, 15),
(6, 'Dr. Ayesha Tariq', 'Radiology', '03251234567', 6, 7),
(7, 'Dr. Usman Malik', 'Gastroenterology', '03261234567', 8, 9),
(8, 'Dr. Zainab Farooq', 'Gynecology', '03271234567', 9, 11),
(9, 'Dr. Ahmed Yousuf', 'Dermatology', '03281234567', 10, 5),
(10, 'Dr. Mariam Ali', 'Psychiatry', '03291234567', 11, 14);


INSERT INTO Appointment (AppointmentID, PatientID, DoctorID, AppointmentDate, AppointmentTime, Status) VALUES
(1, 1, 1, '2024-06-10', '09:00:00', 'Scheduled'),
(2, 2, 2, '2024-06-11', '10:00:00', 'Scheduled'),
(3, 3, 3, '2024-06-12', '11:00:00', 'Scheduled'),
(4, 4, 4, '2024-06-13', '12:00:00', 'Scheduled'),
(5, 5, 5, '2024-06-14', '13:00:00', 'Scheduled'),
(6, 6, 6, '2024-06-15', '14:00:00', 'Scheduled'),
(7, 7, 7, '2024-06-16', '15:00:00', 'Scheduled'),
(8, 8, 8, '2024-06-17', '16:00:00', 'Scheduled'),
(9, 9, 9, '2024-06-18', '17:00:00', 'Scheduled'),
(10, 10, 10, '2024-06-19', '18:00:00', 'Scheduled');


INSERT INTO Room (RoomID, RoomType, Availability, DepartmentID) VALUES
(1, 'Single', 1, 1),
(2, 'Double', 1, 2),
(3, 'Single', 0, 3),
(4, 'Double', 1, 4),
(5, 'Single', 0, 5),
(6, 'Double', 1, 6),
(7, 'Single', 1, 7),
(8, 'Double', 0, 8),
(9, 'Single', 1, 9),
(10, 'Double', 1, 10);

INSERT INTO Billing (BillingID, PatientID, TotalAmount, PaymentStatus, BillingDate) VALUES
(1, 1, 10000.00, 'Paid', '2024-06-01'),
(2, 2, 12000.00, 'Unpaid', '2024-06-02'),
(3, 3, 15000.00, 'Paid', '2024-06-03'),
(4, 4, 8000.00, 'Unpaid', '2024-06-04'),
(5, 5, 9500.00, 'Paid', '2024-06-05'),
(6, 6, 11000.00, 'Paid', '2024-06-06'),
(7, 7, 13000.00, 'Unpaid', '2024-06-07'),
(8, 8, 14000.00, 'Paid', '2024-06-08'),
(9, 9, 12500.00, 'Unpaid', '2024-06-09'),
(10, 10, 11500.00, 'Paid', '2024-06-10');

INSERT INTO Prescription (PrescriptionID, PatientID, DoctorID, MedicineID, Dosage, Instructions, IssueDate) VALUES
(1, 1, 1, 1, '1 tablet', 'Take after meals', '2024-06-01'),
(2, 2, 2, 2, '2 tablets', 'Take before meals', '2024-06-02'),
(3, 3, 3, 3, '1 tablet', 'Take at bedtime', '2024-06-03'),
(4, 4, 4, 4, '2 tablets', 'Take with water', '2024-06-04'),
(5, 5, 5, 5, '1 tablet', 'Take after meals', '2024-06-05'),
(6, 6, 6, 6, '2 tablets', 'Take before meals', '2024-06-06'),
(7, 7, 7, 7, '1 tablet', 'Take at bedtime', '2024-06-07'),
(8, 8, 8, 8, '2 tablets', 'Take with water', '2024-06-08'),
(9, 9, 9, 9, '1 tablet', 'Take after meals', '2024-06-09'),
(10, 10, 10, 10, '2 tablets', 'Take before meals', '2024-06-10');


INSERT INTO Surgery (SurgeryID, SurgeryName, DoctorID, PatientID, SurgeryDate, SurgeryType) VALUES
(1, 'Heart Bypass', 1, 1, '2024-06-01', 'Major'),
(2, 'Brain Tumor Removal', 2, 2, '2024-06-02', 'Major'),
(3, 'Breast Cancer Surgery', 3, 3, '2024-06-03', 'Major'),
(4, 'Appendectomy', 4, 4, '2024-06-04', 'Minor'),
(5, 'Knee Replacement', 5, 5, '2024-06-05', 'Major'),
(6, 'Hernia Repair', 6, 6, '2024-06-06', 'Minor'),
(7, 'Gallbladder Removal', 7, 7, '2024-06-07', 'Minor'),
(8, 'Hysterectomy', 8, 8, '2024-06-08', 'Major'),
(9, 'Cataract Surgery', 9, 9, '2024-06-09', 'Minor'),
(10, 'Thyroid Surgery', 10, 10, '2024-06-10', 'Major');


INSERT INTO Attendance (AttendanceID, StaffID, Date, InTime, OutTime) VALUES
(1, 1, '2024-06-01', '08:00:00', '16:00:00'),
(2, 2, '2024-06-01', '16:00:00', '00:00:00'),
(3, 3, '2024-06-01', '00:00:00', '08:00:00'),
(4, 4, '2024-06-01', '08:00:00', '16:00:00'),
(5, 5, '2024-06-01', '16:00:00', '00:00:00'),
(6, 6, '2024-06-01', '00:00:00', '08:00:00'),
(7, 7, '2024-06-01', '08:00:00', '16:00:00'),
(8, 8, '2024-06-01', '16:00:00', '00:00:00'),
(9, 9, '2024-06-01', '00:00:00', '08:00:00'),
(10, 10, '2024-06-01', '08:00:00', '16:00:00');


INSERT INTO Equipment (EquipmentID, EquipmentName, QuantityAvailable, Condition, DepartmentID) VALUES
(1, 'ECG Machine', 10, 'Good', 1),
(2, 'MRI Scanner', 5, 'Excellent', 2),
(3, 'X-Ray Machine', 8, 'Good', 3),
(4, 'Ultrasound Machine', 7, 'Fair', 4),
(5, 'Ventilator', 12, 'Excellent', 5),
(6, 'Defibrillator', 15, 'Good', 6),
(7, 'Surgical Table', 20, 'Excellent', 7),
(8, 'Anesthesia Machine', 6, 'Good', 8),
(9, 'Patient Monitor', 18, 'Excellent', 9),
(10, 'Infusion Pump', 25, 'Good', 10);


INSERT INTO LabTest (TestID, TestName, TestCost, Description, SampleType, DepartmentID, PatientID) VALUES
(1, 'Complete Blood Count', 500.00, 'Measures different components of blood.', 'Blood', 1, 1),
(2, 'Liver Function Test', 800.00, 'Assesses the condition of the liver.', 'Blood', 2, 2),
(3, 'Kidney Function Test', 700.00, 'Evaluates kidney performance.', 'Blood', 3, 3),
(4, 'Thyroid Profile', 600.00, 'Checks thyroid gland function.', 'Blood', 4, 4),
(5, 'Lipid Profile', 900.00, 'Measures cholesterol levels.', 'Blood', 5, 5),
(6, 'Blood Sugar', 300.00, 'Checks glucose levels.', 'Blood', 6, 6),
(7, 'Urinalysis', 200.00, 'Examines urine for various substances.', 'Urine', 7, 7),
(8, 'Stool Test', 400.00, 'Analyzes stool for infections.', 'Stool', 8, 8),
(9, 'Electrolytes Test', 500.00, 'Measures electrolyte levels.', 'Blood', 9, 9),
(10, 'Hormone Test', 1000.00, 'Checks hormone levels.', 'Blood', 10, 10);




INSERT INTO RadiologyTest (XrayID, XrayType, BodyPart, Result, DoctorID, PatientID) VALUES
(1, 'Chest X-Ray', 'Chest', 'Normal', 1, 1),
(2, 'Abdominal X-Ray', 'Abdomen', 'Inflammation detected', 2, 2),
(3, 'Skull X-Ray', 'Head', 'Fracture detected', 3, 3),
(4, 'Spinal X-Ray', 'Spine', 'Normal', 4, 4),
(5, 'Pelvic X-Ray', 'Pelvis', 'Normal', 5, 5),
(6, 'Limb X-Ray', 'Leg', 'Fracture detected', 6, 6),
(7, 'Dental X-Ray', 'Teeth', 'Cavity detected', 7, 7),
(8, 'Hand X-Ray', 'Hand', 'Normal', 8, 8),
(9, 'Foot X-Ray', 'Foot', 'Sprain detected', 9, 9),
(10, 'Neck X-Ray', 'Neck', 'Normal', 10, 10);



INSERT INTO OutpatientPrescription (PrescriptionID, PatientID, MedicineID, Quantity, DispensedDate, DispensedBy) VALUES
(1, 1, 1, 30, '2024-06-01', 1),
(2, 2, 2, 60, '2024-06-02', 2),
(3, 3, 3, 90, '2024-06-03', 3),
(4, 4, 4, 30, '2024-06-04', 4),
(5, 5, 5, 60, '2024-06-05', 5),
(6, 6, 6, 90, '2024-06-06', 6),
(7, 7, 7, 30, '2024-06-07', 7),
(8, 8, 8, 60, '2024-06-08', 8),
(9, 9, 9, 90, '2024-06-09', 9),
(10, 10, 10, 30, '2024-06-10', 10);



INSERT INTO BloodDonor (DonorID, DonorName, BloodGroup, DonationDate, DonationPlace, ContactNumber) VALUES
(1, 'Arif Khan', 'A+', '2024-06-01', 'Karachi', '03001234567'),
(2, 'Basit Ali', 'B+', '2024-06-02', 'Lahore', '03111234567'),
(3, 'Chaudhry Ahmed', 'O-', '2024-06-03', 'Islamabad', '03211234567'),
(4, 'Daniyal Qureshi', 'AB+', '2024-06-04', 'Peshawar', '03311234567'),
(5, 'Ehsan Javed', 'A-', '2024-06-05', 'Quetta', '03451234567'),
(6, 'Faisal Siddiqui', 'B-', '2024-06-06', 'Multan', '03511234567'),
(7, 'Ghazanfar Abbas', 'O+', '2024-06-07', 'Sialkot', '03611234567'),
(8, 'Hammad Sheikh', 'AB-', '2024-06-08', 'Faisalabad', '03711234567'),
(9, 'Imran Shah', 'A+', '2024-06-09', 'Hyderabad', '03811234567'),
(10, 'Junaid Khan', 'B+', '2024-06-10', 'Rawalpindi', '03911234567');


INSERT INTO WardAdmission (AdmissionID, PatientID, WardNumber, BedNumber, AdmissionDate, DischargeDate, DischargeReason) VALUES
(1, 1, 1, 'B1', '2024-06-01', '2024-06-05', 'Recovered'),
(2, 2, 2, 'B2', '2024-06-02', '2024-06-06', 'Recovered'),
(3, 3, 3, 'B3', '2024-06-03', '2024-06-07', 'Recovered'),
(4, 4, 4, 'B4', '2024-06-04', '2024-06-08', 'Transferred'),
(5, 5, 5, 'B5', '2024-06-05', '2024-06-09', 'Recovered'),
(6, 6, 6, 'B6', '2024-06-06', '2024-06-10', 'Recovered'),
(7, 7, 7, 'B7', '2024-06-07', '2024-06-11', 'Transferred'),
(8, 8, 8, 'B8', '2024-06-08', '2024-06-12', 'Recovered'),
(9, 9, 9, 'B9', '2024-06-09', '2024-06-13', 'Transferred'),
(10, 10, 10, 'B10', '2024-06-10', '2024-06-14', 'Recovered');


INSERT INTO MaintenanceLog (LogID, EquipmentID, MaintenanceDate, MaintenanceType, TechnicianID, Details) VALUES
(1, 1, '2024-06-01', 'Routine Check', 1, 'Checked ECG functionality'),
(2, 2, '2024-06-02', 'Repair', 2, 'Repaired MRI scanner'),
(3, 3, '2024-06-03', 'Routine Check', 3, 'Checked X-Ray machine functionality'),
(4, 4, '2024-06-04', 'Calibration', 4, 'Calibrated ultrasound machine'),
(5, 5, '2024-06-05', 'Routine Check', 5, 'Checked ventilator functionality'),
(6, 6, '2024-06-06', 'Repair', 6, 'Repaired defibrillator'),
(7, 7, '2024-06-07', 'Calibration', 7, 'Calibrated surgical table'),
(8, 8, '2024-06-08', 'Routine Check', 8, 'Checked anesthesia machine functionality'),
(9, 9, '2024-06-09', 'Repair', 9, 'Repaired patient monitor'),
(10, 10, '2024-06-10', 'Calibration', 10, 'Calibrated infusion pump');


INSERT INTO Diagnosis (DiagnosisID, PatientID, DoctorID, DiagnosisDate, DiagnosisDescription, TreatmentPlan) VALUES
(1, 1, 1, '2024-06-01', 'Hypertension', 'Lifestyle changes and medication'),
(2, 2, 2, '2024-06-02', 'Diabetes', 'Diet control and insulin therapy'),
(3, 3, 3, '2024-06-03', 'Migraine', 'Pain relief and lifestyle changes'),
(4, 4, 4, '2024-06-04', 'Asthma', 'Inhaler and medication'),
(5, 5, 5, '2024-06-05', 'Arthritis', 'Physical therapy and medication'),
(6, 6, 6, '2024-06-06', 'Depression', 'Counseling and medication'),
(7, 7, 7, '2024-06-07', 'Allergy', 'Avoidance and medication'),
(8, 8, 8, '2024-06-08', 'Back Pain', 'Physiotherapy and pain relief'),
(9, 9, 9, '2024-06-09', 'Flu', 'Rest and hydration'),
(10, 10, 10, '2024-06-10', 'Kidney Stone', 'Medication and hydration');


CREATE TABLE Admin (
    AdminID INT PRIMARY KEY,
	Username NVARCHAR(255),
    Password NVARCHAR(255)
);

INSERT INTO Admin (AdminID,Username,Password) VALUES
(1,'wassaf','123'),
(2,'maryam','123'),
(3,'murtaza','123'),
(4,'admin','123');

select * from Doctor;

select * from Patient;

select * from Department;

SELECT * FROM Medicine;