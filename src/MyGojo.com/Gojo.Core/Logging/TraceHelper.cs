using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

using Gojo.Core.Security.Attributes;

namespace Gojo.Core.Logging
{
    // See: http://blogs.msdn.com/b/carlnol/archive/2011/07/30/using-reflection-and-attributes-for-better-tracing-and-logging-data-rendering.aspx

    public static class TraceHelper
    {
        /// <summary>
        /// Null display value.
        /// </summary>
        private const string TracingResourcesNullValue = @"null";

        /// <summary>
        /// Quote for displaying.
        /// </summary>
        private const string TracingResourcesQuote = "\"";

        /// <summary>
        /// Seperator for displaying.
        /// </summary>
        private const string TracingResourcesParamSeparator = @" | ";

        /// <summary>
        /// Unknown Property String Value.
        /// </summary>
        private const string TracingResourcesUnknownValue = "Unknown Property Value";

        /// <summary>
        /// Add details of a collection of parameters to the supplied log entry.
        /// </summary>
        /// <param name="parameters">Parameters to be described in the log entry.</param>
        /// <param name="logEntry">Log entry to add parameter information to.</param>
        public static string ParameterCollectionToString(object[] parameters)
        {
            // Make sure we have a parameter array which is safe to pass to Array.ConvertAll
            if (parameters == null)
            {
                parameters = new object[] { null };
            }

            // Get a string representation of each parameter that we have been passed
            string[] paramStrings;
            paramStrings = Array.ConvertAll<object, string>(parameters, ParameterObjectToString);

            // Add details of each parameter to log entry
            string allParamStrings = string.Join(TracingResourcesParamSeparator, paramStrings);

            return allParamStrings;
        }

        /// <summary>
        /// Convert a parameter object to a string for display in the trace.
        /// </summary>
        /// <param name="parameter">Parameter object to convert.</param>
        /// <returns>A string describing the parameter object.</returns>
        public static string ParameterObjectToString(object parameter)
        {
            string paramDesc = string.Empty;

            if (parameter == null)
            {
                paramDesc = TracingResourcesNullValue;
            }
            else
            {
                // Surround string values with quotes
                if (parameter.GetType() == typeof(string))
                {
                    paramDesc = String.Concat(TracingResourcesQuote, (string)parameter, TracingResourcesQuote);
                }
                else
                {
                    paramDesc = TraceHelper.GetObjectString(parameter);
                }
            }

            return paramDesc;
        }

        /// <summary>
        /// Gets a string representation of an object and items values.
        /// </summary>
        /// <param name="item">Object Item.</param>
        /// <returns>String Value.</returns>
        public static string GetObjectString(object item)
        {
            return GetObjectString(item, false);
        }

        /// <summary>
        /// Gets a string representation of an object and items values.
        /// </summary>
        /// <param name="item">Object Item.</param>
        /// <param name="multipleLine">Indicates is the output should be on a multiple lines.</param>
        /// <returns>String Value.</returns>
        public static string GetObjectString(object item, bool multipleLine)
        {
            // first call ToString and if returns type call GetValues
            string valueString = item.ToString();

            Type objectType = item.GetType();
            if (!objectType.IsValueType && valueString == objectType.FullName)
            {
                valueString = GetObjectValues(item, multipleLine);
            }

            return valueString;
        }

        /// <summary>
        /// Gets a string representation of an object and items values.
        /// </summary>
        /// <param name="item">Object Item.</param>
        /// <param name="multipleLine">Indicates is the output should be on a multiple lines.</param>
        /// <returns>String Value.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Tracing must not thrown an exception.")]
        private static string GetObjectValues(object item, bool multipleLine)
        {
            // check object not null
            if (item == null)
            {
                return string.Empty;
            }

            // get the configuration type
            Type objectType = item.GetType();

            StringBuilder printValue = new StringBuilder();
            AddToStringBuilder(printValue, objectType.Name, multipleLine);

            // look through all the properties for strings (public only) - ensure that the property has a GetProperty
            foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                SensitiveInformationAttribute attribute = GetPiiAttribute(propertyInfo);
                if (attribute != null)
                {
                    if (!attribute.Hidden)
                    {
                        string value = GetPiiString(attribute.DisplayOverride, propertyInfo.Name);
                        AddToStringBuilder(printValue, value, multipleLine);
                    }
                }
                else
                {
                    // If the property has a get method, write the property value.
                    if (propertyInfo.CanRead)
                    {
                        string value = null;
                        try
                        {
                            value = ProcessProperty(propertyInfo.PropertyType, propertyInfo.Name, propertyInfo.GetValue(item, null));
                        }
                        catch (Exception)
                        {
                            value = TracingResourcesUnknownValue;
                        }

                        AddToStringBuilder(printValue, value, multipleLine);
                    }
                }
            }

            // look through all the fields for strings (public only)
            foreach (FieldInfo fieldInfo in objectType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                SensitiveInformationAttribute attribute = GetPiiAttribute(fieldInfo);
                if (attribute != null)
                {
                    if (!attribute.Hidden)
                    {
                        string value = GetPiiString(attribute.DisplayOverride, fieldInfo.Name);
                        AddToStringBuilder(printValue, value, multipleLine);
                    }
                }
                else
                {
                    string value = null;
                    try
                    {
                        value = ProcessProperty(fieldInfo.FieldType, fieldInfo.Name, fieldInfo.GetValue(item));
                    }
                    catch (Exception)
                    {
                        value = TracingResourcesUnknownValue;
                    }

                    AddToStringBuilder(printValue, value, multipleLine);
                }
            }

            return printValue.ToString();
        }

        /// <summary>
        /// Gets the PersonallyIdentifiableInformation Attribute.
        /// </summary>
        /// <param name="member">Member Information.</param>
        /// <returns>Personally Identifiable Information Attribute.</returns>
        private static SensitiveInformationAttribute GetPiiAttribute(MemberInfo member)
        {
            SensitiveInformationAttribute piiAttribute = null;

            foreach (Attribute attribute in member.GetCustomAttributes(typeof(SensitiveInformationAttribute), false))
            {
                piiAttribute = attribute as SensitiveInformationAttribute;
                if (piiAttribute != null)
                {
                    break;
                }
            }

            return piiAttribute;
        }

        /// <summary>
        /// Gets the string from the Attribute name.
        /// </summary>
        /// <param name="displayOverride">The display override.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>String value to display.</returns>
        private static string GetPiiString(string displayOverride, string memberName)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} = {1}", memberName, (displayOverride == null) ? string.Empty : displayOverride.ToString());
        }

        /// <summary>
        /// Appends the given string to the given builder.
        /// </summary>
        /// <param name="builder">String Builder.</param>
        /// <param name="value">String Value.</param>
        /// <param name="multipleLine">Multiple line indicator.</param>
        private static void AddToStringBuilder(StringBuilder builder, string value, bool multipleLine)
        {
            if (value != null)
            {
                if (multipleLine)
                {
                    builder.AppendLine(value);
                }
                else
                {
                    builder.Append(string.Concat(value, "; "));
                }
            }
        }

        /// <summary>
        /// Returns a string from an object Property/Field.
        /// </summary>
        /// <param name="propertyType">Property/Field type.</param>
        /// <param name="propertyName">Property/Field name.</param>
        /// <param name="propertyValue">Property/Field value.</param>
        /// <returns>String of the Property/Field.</returns>
        private static string ProcessProperty(Type propertyType, string propertyName, object propertyValue)
        {
            string value = null;

            if (propertyValue != null)
            {
                if (propertyType == typeof(string))
                {
                    // see if underlying type is a string and persist the value
                    // get the value and ensure not null
                    string objectValue = propertyValue as string;
                    if (!string.IsNullOrEmpty(objectValue))
                    {
                        value = string.Format(CultureInfo.CurrentCulture, "{0} = {2}{1}{2}", propertyName, objectValue, TracingResourcesQuote);
                    }
                }
                else if (propertyType.IsEnum)
                {
                    // look for enum types and persist the value
                    value = string.Format(CultureInfo.CurrentCulture, "Enum {0} = {1}", propertyName, Enum.GetName(propertyType, propertyValue));
                }
                else if (propertyType.IsValueType)
                {
                    // look for other value type
                    value = string.Format(CultureInfo.CurrentCulture, "{0} = {1}", propertyName, (propertyValue == null) ? string.Empty : propertyValue.ToString());
                }
                else
                {
                    // reference type so return the type name
                    value = string.Format(CultureInfo.CurrentCulture, "{0} Type = {1}", propertyName, (propertyType.Name == null) ? string.Empty : propertyType.Name);
                }
            }
            else
            {
                value = value = string.Format(CultureInfo.CurrentCulture, "{0} = {1}", propertyName, TracingResourcesNullValue);
            }

            return value;
        }

    }
}
