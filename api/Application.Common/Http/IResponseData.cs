using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Common.Validation;

namespace App.Common.Http
{
    public interface IResponseData<DataType>
    {
        void SetStatus(System.Net.HttpStatusCode httpStatusCode);
        void SetErrors(IList<ValidationError> errors);
        void SetData(DataType data);
    }
}
