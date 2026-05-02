# 🧾 Smart Order Processing System (SOLID Principles - C#)

## 📌 Overview
This project is a console-based Smart Order Processing System built in C#.  
It demonstrates how SOLID principles can be applied in a real-world scenario like order management.

The system allows users to:
- Enter order details
- Choose a payment method
- Process payment
- Generate an invoice

---

## 🚀 Features
- User input for Order ID and Amount
- Multiple payment methods:
  - Credit Card
  - UPI
  - Cash
- Invoice generation
- Clean and modular code structure

---

## 🧠 SOLID Principles Used

### 🔹 Single Responsibility Principle (SRP)
- `Order` → Handles only order data  
- `InvoiceGenerator` → Handles invoice printing  
- `OrderProcessor` → Handles order processing  

### 🔹 Open/Closed Principle (OCP)
- New payment methods can be added without modifying existing code.

### 🔹 Liskov Substitution Principle (LSP)
- All payment classes (`CreditCardPayment`, `UpiPayment`, `CashPayment`) can replace each other.

### 🔹 Interface Segregation Principle (ISP)
- Separate interfaces:
  - `IPayment`
  - `IInvoice`

### 🔹 Dependency Inversion Principle (DIP)
- `OrderProcessor` depends on interfaces (`IPayment`, `IInvoice`) instead of concrete classes.

---

## 🛠️ Technologies Used
- C#
- .NET Console Application

---

## ▶️ How to Run
1. Open the project in Visual Studio / VS Code
2. Build and run the program
3. Enter:
   - Order ID
   - Order Amount
   - Payment choice
4. View processed payment and invoice output



---

## 📊 PPT Included
This repository also contains a PowerPoint presentation explaining:
- SOLID Principles
- Code implementation
- Real-world examples

---

## 🎯 Conclusion
This project demonstrates how applying SOLID principles leads to clean, maintainable, and scalable code in real-world applications.

---

---

## 📷 Sample Output
