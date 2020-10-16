using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Aplicacion.Models.Validaciones
{
    public class ValidarIdentificador : ValidationAttribute
    {
        String _nombreInstitucion;
        String identificador;
        //public ValidarIdentificador(String nombreInstitucion)
        public ValidarIdentificador()
           //: base("El identificador no concuerda con la institucion {0}")
           : base("El identificador no concuerda")
        {
            //_nombreInstitucion = nombreInstitucion;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if( value!= null)
            {
                identificador = (String)value;
                var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                //if (_nombreInstitucion.Equals("Visa"))
                //{
                    if(!Regex.IsMatch(identificador, "4[0-9]{3}$"))
                    {
                        
                        return new ValidationResult(mensajeDeError);
                    }
                //}
                //if (_nombreInstitucion.Equals("Mastercard"))
                //{
                    if(!Regex.IsMatch(identificador, "5[1-5][0-9]{2}$"))
                    {
                        return new ValidationResult(mensajeDeError);
                    }
                //}
            }
            return ValidationResult.Success;


        }



    }
}