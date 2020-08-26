using System;
using System.Collections.Generic;
using System.Text;

namespace SmartaceEDMS.API.Application
{
    public class CommonResponseMessage
    {
        public const string GenericRecordCreate = "Your record was saved successfully";
        public const string RecordCreate = "{0} record was saved successfully";

        public const string GenericRecordUpdate = "Your record was updated successfully";
        public const string RecordUpdate = "{0} record was updated successfully";

        public const string GenericRecordFail= "Your record failed to save";
        public const string RecordFail = "{0} record failed to save";

        public const string GenericRecordExisting = "The operation was aborted, record exist";
        public const string RecordExisting = "The operation was aborted, {0} record exist";
        public const string RecordNotFound = "Record not found";

        public const string RecordUpdateFail = "{0} record failed to update";
        public const string GenericRecordUpdateFail = "Your record failed to update";

        public const string RecordDelete = "{0} record was deleted";
        public const string GenericRecordDelete = "Your record was deleted";
        public const string RecordFailDelete = "{0} record was not deleted";
        public const string GenericRecordFailDelete = "Your record was not deleted";
      
        
        public const string InternalError = "An inner error occurred while {0} your record {1}. [{2}]  ";

    }

    public class CommonModelNames
    {
        public const string DOCUMENT_LIBRARY = "Document Library";
        public const string DOCUMENT_LIBRARY_VERSION = "Document Library Version";
        public const string DOCUMENT_LINK = "Document Link";
        public const string DOCUMENT_LINK_LOG = "Document Link Log";
        public const string DOCUMENT_LINK_SETTING = "Document Link Setting";

    }

    public class    OperationType
    {

        public const string Save = "Save";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string Fetch = "Fetch";

    }
    #region This will  hold all default values needed
    public class DefaultValueMaps
    {
        public const int pageSize = 100;
        public const int pageNumber = 1;
        public const long DefaultId = 0;
        public const long parentDocumentId = 0;
        public const int StartCount = 1;


    }
    #endregion
}
