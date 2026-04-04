# 🏋️ Gym Management System

## 📌 Problem Description

This project is developed to help a gym manage its daily operations efficiently.
The system handles information about members, training packages, trainers, and training schedules.

When customers register, the receptionist inputs member information and assigns a suitable training package. Each package has its own duration and price.

The system also:

* Tracks member status (Active, About to expire, Expired)
* Manages training schedules with trainers
* Records payment transactions
* Supports managers in monitoring revenue and member growth

---

## 🚀 Features

### 🔹 Basic Features

* Manage members (Add, Edit, Delete, Search)
* Manage training packages (name, duration, price)
* Manage trainers
* Register training packages for members
* Login system
* Search members by name or phone number
* Display active and expired members

---

### 🔹 Advanced Features

* Notify members whose packages are about to expire
* Generate monthly revenue statistics
* Manage training schedules (member ↔ trainer)
* Export member reports
* Dashboard showing number of members

---

## 🛠️ Technologies Used

* **Language:** C#
* **Framework:** WinForms
* **Database:** SQL Server
* **Data Access:** ADO.NET / Entity Framework

---

## 🗄️ Database Design

Main tables in the system:

* USERS
* MEMBERS
* PACKAGES
* TRAINERS
* TRAINER_PACKAGES
* TIMESLOTS
* REGISTRATIONS
* SCHEDULES

---

## 🔐 Authorization

The system supports role-based access control:

* **Admin**

  * Full access to all system features

* **Receptionist**

  * Manage members
  * Register training packages

* **Manager**

  * View reports and statistics

---

## ⚙️ How to Run

1. Clone this repository:

   ```bash
   git clone <your-repo-link>
   ```

2. Open the project in **Visual Studio**

3. Run the SQL script to create the database

4. Update the connection string in `App.config`

5. Press **F5** to run the application

---

## 📊 Screenshots

*(Add your application screenshots here)*
<img width="3190" height="1886" alt="image" src="https://github.com/user-attachments/assets/aab733d3-f347-4b3e-beef-a10123af72d5" />

* Login Screen
<img width="876" height="600" alt="image" src="https://github.com/user-attachments/assets/4710effd-659d-438f-837e-97b9d130e230" />

* Dashboard
-frmGuest
<img width="2198" height="958" alt="image" src="https://github.com/user-attachments/assets/8e02db68-7357-4b4f-a38d-52b3d922ce75" />
-frmMain
<img width="2870" height="1438" alt="image" src="https://github.com/user-attachments/assets/4d9e787c-0e53-4648-bbdc-ffb4571e79d7" />

* Member Management
-All
<img width="2974" height="1342" alt="image" src="https://github.com/user-attachments/assets/823a0e4b-25ad-49ee-8fa4-df46832f1ac6" />
-Trainer
<img width="2796" height="1170" alt="image" src="https://github.com/user-attachments/assets/7c545231-4603-4a63-9aad-3fb394714cf0" />
-Packages
<img width="2914" height="1236" alt="image" src="https://github.com/user-attachments/assets/09f723ed-ab23-483d-aacc-0fa4fc4ae522" />

* Schedule Management

---

## 📈 Future Improvements

* Online booking system
* Mobile app integration
* Payment gateway integration
* AI-based training recommendations

---

## 👤 Author

* Cao Thu Trang and AI

---
