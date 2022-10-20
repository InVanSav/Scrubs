namespace Scrubs.Domain.Enum; 

public enum StatusCode {
    
    // User
    UserNotFound = 0,
    UserWasNotCreate = 1,
    
    // Doctor
    DoctorNotFound = 2,
    DoctorWasNotCreate = 3,
    
    // Specialization
    SpecializationNotFound = 4,
    SpecializationWasNotAdded = 5,
    
    // TimeTable
    TimeTableNotFound = 6,
    TimeTableWasNotAdded = 7,
    
    // Appointment
    AppointmentNotFound = 8,
    AppointmentWasNotAdded = 9,
    
    // Base
    OK = 200,
    PageNoFound = 404,
    InternalServerError = 500,
    
}
