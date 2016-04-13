using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiModelBindingSample2.Controllers
{
    public class ModelStateValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
        }
    }

    [ModelStateValidation]
    public class PersonController : ApiController
    {
        [HttpGet]
        public object Get(int id)
        {
            return Ok(new Person { Id = id, Name = "Bradley", BirthDate = new DateTime(1979, 2, 22), EmailAddress = EmailAddress.Parse("bradleylandis@hotmail.com") });
        }

        [HttpPost]
        public object Post([FromBody]Person person)
        {
            return Created($"/api/person/{person.Id}", person);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public int Id { get; set; }
    }

    [TypeConverter(typeof(EmailAddressConverter))]
    public class EmailAddress
    {
        private const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        private readonly string _underlyingValue;

        private EmailAddress(string value)
        {
            _underlyingValue = value;
        }

        public static EmailAddress Parse(string value)
        {
            return new EmailAddress(value);
        }

        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress._underlyingValue;
        }

        public string ToValueType()
        {
            return _underlyingValue;
        }

        public override string ToString()
        {
            return _underlyingValue;
        }

        public static bool TryParse(string value, out EmailAddress emailAddress)
        {
            if (value != null && Regex.IsMatch(value, EmailRegex, RegexOptions.IgnoreCase))
            {
                emailAddress = new EmailAddress(value);
                return true;
            }
            emailAddress = null;
            return false;
        }
    }

    public class EmailAddressConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                EmailAddress emailAddress;
                if (EmailAddress.TryParse((string)value, out emailAddress))
                    return emailAddress;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}