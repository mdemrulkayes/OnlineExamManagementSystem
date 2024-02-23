using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class CustomMessage
    {
        public static string CreateInformation(string obj)
        {
            return $"{obj} Created Successfully";
        }

        public static string UpdateInformation(string obj)
        {
            return $"{obj} Updated Successfully";
        }

        public static string DeleteInformation(string obj)
        {
            return $"{obj} Deleted Successfully";
        }

        public static string ExceptionInformation(string obj, Exception ex)
        {
            return $"Error Occured in {obj}, Message: {ex.Message}";
        }

        public static string NotFoundInformation(string obj)
        {
            return $"No {obj} Record Found";
        }

        public static string BulkOperationInformation(string obj)
        {
            return $"{obj} Bulk Operation Completed";
        }

        public static string FetchInformation(string obj)
        {
            return $"{obj} Data Fetched Successfully";
        }

        public static string AlreadyExist(string obj)
        {
            return $"{obj} Data is already exists";
        }
    }
}
