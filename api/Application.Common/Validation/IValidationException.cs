using System;
using System.Collections.Generic;

namespace App.Common.Validation
{
    public interface IValidationException
    {
        IList<ValidationError> Errors { get; set; }
        void Add(ValidationError error);
    }
}
