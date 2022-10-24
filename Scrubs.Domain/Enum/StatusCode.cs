namespace Scrubs.Domain.Enum; 

public enum StatusCode {
    
    // Data Not Found
    DataNotFound = 0,
    
    // Data Was Not Added
    DataWasNotAdded = 1,
    
    // Base
    OK = 200,
    PageNoFound = 404,
    InternalServerError = 500,
    
}
