# MicroGrid – Energy Production & Consumption Subsystem Simulation

This project is developed as part of the *Applied Software Engineering – Software Development Elements* course.  
It represents a simulation of a MicroGrid system consisting of consumers, consumption subsystems, and production subsystems, with fully implemented business logic following SOLID principles and clean architecture.

## Authors
- [Katarina Kalauz](https://github.com/kalauzkatarina)
- [Julijana Ristić](https://github.com/julijanaristic)


## Project Overview

The application simulates how consumers request and use electrical energy from different production subsystems.  
The system includes:

- Consumers  
- Consumption subsystem  
- Production subsystem  
- Guaranteed and Commercial supply services  
- Logging mechanisms  
- Console interface with authentication  

The system is fully designed according to the given architecture diagram (E01.1) and includes services, models, and test coverage as required in the specification.

---

## Entities

### **Consumer**
- Unique textual identifier (GUID)
- First & last name
- Contract number (e.g., *EPS3345K*)
- Supply type (Guaranteed / Commercial)
- Total consumed energy
- Current debt

### **Consumption Subsystem**
- List of active consumers
- Subsystem name
- Subsystem code (e.g., *PSP3321-NS1*)

### **Production Subsystem**
- Production subsystem code (e.g., *PP221-NS1*)
- Production type (Hydro, EcoGreen, Solid Fuel)
- Location
- Remaining available energy (kW, randomly generated)

---

## System Logic

### **Consumption Service**
- Receives energy requests from consumers  
- Verifies consumer activity and supply type  
- Requests energy from the Production Service  
- Calculates price based on supply type  
  - **Guaranteed supply:**  
    - Price: *22.72 RSD/kW*  
    - Energy decreases by *2%* due to conductor loss  
  - **Commercial supply:**  
    - Price: *43.02 RSD/kW*  
    - Energy decreases by *1%*

- Logs consumption:  
  - Guaranteed → writes to a **text file**  
  - Commercial → stored in a **collection (list)**

### **Production Service**
- Injected with Guaranteed or Commercial supply strategy (via Singleton pattern)
- Tracks remaining energy  
- Chooses subsystem with **the highest available energy** that can satisfy the request  
- Auto-refills production:  
  - Guaranteed → +22% if below 100 kW  
  - Commercial → +14% if below 100 kW  

---

## Architecture & Design

- Full **clean architecture** separation  
- Strict adherence to **SOLID**  
- Business logic implemented **only in services**  
- Models contain **no business logic**  
- Dependency Injection used for:  
  - Supply type strategies  
  - Logging implementations  
- Supply type implementations follow the **Singleton pattern**

---

## Console Application

The console application includes:

- Authentication on startup  
- Adding a new consumer  
- Listing all consumers  
- Requesting energy for a consumer  
- Viewing the consumer's current debt  

Test data is included and additional consumers can be generated using helper methods.

---

## Testing Requirements

The implementation includes tests covering:

- **4 basic cases**
- **6 boundary cases**
- **5 arbitrary cases**

---

## Logging Format

Guaranteed supply log example:

```bash
19.04.2024 14:32: Issued 120 kW.
```
---

## Technologies

- C# / .NET  
- Console application  
- SOLID  
- Clean Architecture  
- Text file logging

##  License
This project is developed for educational purposes within the Applied Software Engineering course.

