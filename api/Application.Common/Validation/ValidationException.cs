
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace App.Common.Validation
{
    public class ValidationException : Exception, IValidationException
    {
        public ValidationException(string key) : base()
        {
            this.Errors = new List<ValidationError>();
            this.Add(new ValidationError(key, string.Empty));
        }

        public ValidationException() : base()
        {
            this.Errors = new List<ValidationError>();
        }

        public ValidationException(string key, params object[] args): this()
        {
            IList<string> extParam = new List<string>();
            foreach (object param in args) {
                extParam.Add(param.ToString());
            }
            this.Add(new ValidationError(key, string.Empty, extParam));
        }

        public System.Collections.Generic.IList<ValidationError> Errors { get; set; }

        public void Add(ValidationError error)
        {
            this.Errors.Add(error);
        }

        public void Add(IList<ValidationError> errors)
        {
            foreach (var validationError in errors)
            {
                this.Add(validationError);
            }
        }
    }

    public class EntityException : Exception
    {
        public IEnumerable<ValidationResult> Errors { get; set; }

        public EntityException(IEnumerable<ValidationResult> errors)
        {
            this.Errors = errors;
        }

        public EntityException(ValidationResult error)
        {
            this.Errors = new List<ValidationResult>(){error};
        }
    }
}