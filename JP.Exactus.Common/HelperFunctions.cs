﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JP.Exactus.Common
{
    public class HelperFunctions
    {
        public static DateTime ConvertToDate(string value, string format)
        {
            DateTime date;
            if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new ArgumentException(string.Format("No puedo convertir el valor '{0}' a una fecha con este formato '{1}'", value, format));
            }
            return date;
        }

        public static string ParseException(Exception ex, bool getTrace = false)
        {
            const string Mensaje = "Lo siento, se ha presentado un error, notifique al administrador.<br/>";
            if (ex.GetType() == typeof( DbEntityValidationException))
            {
                return Mensaje + ParseDbEntityValidationException((DbEntityValidationException)ex);
            }

            if (ex.GetType() == typeof(DbUpdateException))
            {
                return Mensaje + ParseDbEntityValidationException((DbUpdateException)ex, getTrace);
            }

            if (getTrace)
            {
                return ex.ToString();
            }
            else
            {
                return Mensaje + ex.Message;
            }
        }

        /// <summary>
        /// Recopila todas las validación falladas de una DbEntityValidationException y las convierte a string.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ParseDbEntityValidationException(DbEntityValidationException ex)
        {
            var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            return string.Join("<br/>", errorMessages);
        }

        /// <summary>
        /// Recopila todas las validación falladas de una DbEntityValidationException y las convierte a string.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ParseDbEntityValidationException(DbUpdateException ex, bool getTrace = false)
        {
            var innerEx = ex.InnerException;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }

            if (getTrace)
            {
                return innerEx.ToString();
            }
            else
            {
                return innerEx.Message;
            }
        }
    }
}
